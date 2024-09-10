using LmCorbieUI;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddinFormatec {
  public class ProcessoFabricacao {
    [DisplayName("CÓDIGO")]
    public string IdProcesso { get; set; }

    [DisplayName("PROCESSO")]
    public string DescricaoProcesso { get; set; } = string.Empty;

    //[DisplayName("CÓDIGO")]
    //public string CodigoItem { get; set; } = string.Empty;

    [DisplayName("DESCRIÇÃO")]
    public string DescricaoItem { get; set; } = string.Empty;

    //[DisplayName("CONFIGURAÇÃO")]
    //public string ConfigName { get; set; } = string.Empty;

    [DisplayName("QTD")]
    public int QtdItem { get; set; } = 0;

    //public List<string> DesenhosFilhos { get; set; }

    [Browsable(false)]
    public string NomeComponente { get; set; }

    [Browsable(false)]
    public string PathName { get; set; }

    #region Metodos

    public static List<ProcessoFabricacao> GetProcessoFabricacao() {
      var listaProcessoFabricacao = new List<ProcessoFabricacao>();

      try {
        SldWorks swApp = new SldWorks();
        var swModel = (ModelDoc2)swApp.ActiveDoc;
        ModelDocExtension swModelDocExt;

        ConfigurationManager swConfMgr;
        Configuration swConf;

        swModelDocExt = swModel.Extension;
        swConfMgr = swModel.ConfigurationManager;
        swConf = swConfMgr.ActiveConfiguration;

        string pathName = swModel.GetPathName();

        var processoFabricacao = new ProcessoFabricacao();

        if (PossuiProcesso(swModel, swConf.Name, processoFabricacao) == true) {
          var idProcs = processoFabricacao.DescricaoProcesso.Split('/');
          foreach (var idProc in idProcs) {
            var descrProc = vw_operacao.GetProcessoDescricao(idProc);

            processoFabricacao.IdProcesso = idProc;
            processoFabricacao.DescricaoProcesso = descrProc;
            processoFabricacao.PathName = pathName;
            processoFabricacao.NomeComponente = Path.GetFileNameWithoutExtension(pathName);

            listaProcessoFabricacao.Add(processoFabricacao);
          }
        }

        // Inserir lista de material e pegar dados
        string templateGeral = $"{Application.StartupPath}\\01 - Addin Formatec\\ListaComponentes.sldbomtbt";
        int BomTypeGeral = (int)swBomType_e.swBomType_Indented;
        int NumberingType = (int)swNumberingType_e.swNumberingType_Detailed;
        var swBOMAnnotationGeral = swModelDocExt.InsertBomTable3(templateGeral, 0, 1, BomTypeGeral, swConf.Name, Hidden: false, NumberingType, DetailedCutList: true);
        PegaDadosListaGeral(swApp, swBOMAnnotationGeral, listaProcessoFabricacao);
        ListaCorte.ExcluirLista(swModel);
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao retornar Processo de Fabricacao\n\n{ex.Message}", "Addin LM Projetos",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      listaProcessoFabricacao = listaProcessoFabricacao.OrderBy(x => x.IdProcesso).ToList();
      return listaProcessoFabricacao;
    }

    private static void PegaDadosListaGeral(SldWorks swApp, BomTableAnnotation swBOMAnnotation, List<ProcessoFabricacao> listaProcessoFabricacao) {
      string nameShort = "";
      try {
        string[] vModelPathNames = null;
        string strItemNumber = null;
        string strPartNumber = null;
        var swTableAnnotation = (TableAnnotation)swBOMAnnotation;

        int lStartRow = swTableAnnotation.TotalRowCount - 1;

        var swBOMFeature = swBOMAnnotation.BomFeature;

        for (int i = 0; i < swTableAnnotation.TotalRowCount; i++) {
          vModelPathNames = (string[])swBOMAnnotation.GetModelPathNames(i, out strItemNumber, out strPartNumber);

          if (vModelPathNames != null) {
            string pathName = vModelPathNames[0];
            string nomeComp = swTableAnnotation.get_Text(i, 2).Trim();

            if (string.IsNullOrEmpty(nomeComp))
              continue;

            ModelDoc2 swModel = default(ModelDoc2);
            if (Path.GetExtension(pathName).ToLower() == ".sldprt")
              swModel = (ModelDoc2)swApp.OpenDoc(pathName, (int)swDocumentTypes_e.swDocPART);
            else
              swModel = (ModelDoc2)swApp.OpenDoc(pathName, (int)swDocumentTypes_e.swDocASSEMBLY);

            if (swModel != null) {
              ModelDocExtension swModelDocExt;

              ConfigurationManager swConfMgr;
              Configuration swConf;

              swModelDocExt = swModel.Extension;
              swConfMgr = swModel.ConfigurationManager;
              swConf = swConfMgr.ActiveConfiguration;

              if (int.TryParse(swTableAnnotation.get_Text(i, 1).Trim(), out int qtd)) {
                if (listaProcessoFabricacao.Any(x => x.NomeComponente == nomeComp)) {
                  var item = listaProcessoFabricacao.Where(x => x.NomeComponente == nomeComp).FirstOrDefault();
                  item.QtdItem += qtd;
                } else {
                  var processoFabricacao = new ProcessoFabricacao();

                  if (PossuiProcesso(swModel, swConf.Name, processoFabricacao) == true) {
                    var idProcs = processoFabricacao.DescricaoProcesso.Split('/');
                    foreach (var idProc in idProcs) {
                      var descrProc = vw_operacao.GetProcessoDescricao(idProc);

                      processoFabricacao.IdProcesso = idProc;
                      processoFabricacao.QtdItem = qtd;
                      processoFabricacao.DescricaoProcesso = descrProc;
                      processoFabricacao.PathName = pathName;
                      processoFabricacao.NomeComponente = nomeComp;

                      listaProcessoFabricacao.Add(processoFabricacao);
                    }
                  }
                }
              }
              swApp.CloseDoc(pathName);
            }
          }
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar dados da Lista\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private static bool PossuiProcesso(ModelDoc2 swModel, string activeConfig, ProcessoFabricacao processoFabricacao) {
      bool _return = false;

      try {
        ModelDocExtension swModelDocExt = default(ModelDocExtension);
        Configuration swConfig = default(Configuration);
        ConfigurationManager swConfMgr = default(ConfigurationManager);
        CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

        string valOut;
        string resolvedValOut;
        string codigoOperacao = "";
        string descr = "";

        swConfMgr = swModel.ConfigurationManager;
        swModelDocExt = swModel.Extension;

        swCustPropMngr = swModelDocExt.get_CustomPropertyManager(activeConfig);
        swCustPropMngr.Get2("sgl_DescricaoEspecifica", out valOut, out resolvedValOut);
        descr = resolvedValOut;

        swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");
        swCustPropMngr.Get2("sgl_operacao", out valOut, out resolvedValOut);
        codigoOperacao = resolvedValOut;

        if ((swModel.GetType() == (int)swDocumentTypes_e.swDocPART)) {
          var opTmp = codigoOperacao;
          codigoOperacao = GetOpFromCutList(swModel, processoFabricacao);
          if (codigoOperacao == "")
            codigoOperacao = opTmp;
        }


        if (codigoOperacao != "") {
          _return = true;
          processoFabricacao.DescricaoProcesso = codigoOperacao;
          processoFabricacao.DescricaoItem = descr.Trim();
          processoFabricacao.QtdItem = 1;
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao verificar CheckList\n\n{ex.Message}", "Addin LM Projetos",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return _return;
    }

    private static string GetOpFromCutList(ModelDoc2 swModel, ProcessoFabricacao processoFabricacao) {
      string _return = string.Empty;
      bool boolstatus;

      try {
        FeatureManager swFeatMgr = default(FeatureManager);
        Feature swFeat = default(Feature);
        string FeatType = null;
        string FeatTypeName = null;
        int bodyCount = 0;

        BodyFolder swBodyFolder = default(BodyFolder);

        Feature[] featureArr = new Feature[3];

        swFeatMgr = swModel.FeatureManager;

        swFeat = (Feature)swModel.FirstFeature();


        while ((swFeat != null)) {
          FeatType = swFeat.Name;
          FeatTypeName = swFeat.GetTypeName2();


          if (FeatTypeName == "CutListFolder") {
            swBodyFolder = (BodyFolder)swFeat.GetSpecificFeature2();
            bodyCount = swBodyFolder.GetBodyCount();

            if (bodyCount > 0) {
              boolstatus = swModel.Extension.SelectByID2(FeatType, "SUBWELDFOLDER", 0, 0, 0, false, 0, null, 0);

              SelectionMgr swSelMgr = (SelectionMgr)swModel.SelectionManager;
              swFeat = (Feature)swSelMgr.GetSelectedObject6(1, 0);

              CustomPropertyManager swCustPropMngr = swFeat.CustomPropertyManager;

              object[] custPropNames = (object[])swCustPropMngr.GetNames();

              if (custPropNames != null) {
                string sValue, sResolvedvalue;

                swBodyFolder = (BodyFolder)swFeat.GetSpecificFeature2();
                boolstatus = swBodyFolder.SetAutomaticCutList(true);
                boolstatus = swBodyFolder.UpdateCutList();

                var name = custPropNames.FirstOrDefault(x => x.ToString().Trim() == "sgl_operacao");
                swCustPropMngr.Get2((string)name, out sValue, out sResolvedvalue);
                _return = sResolvedvalue;
              }
            }
          }
          swFeat = (Feature)swFeat.GetNextFeature();
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar lista corte\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      if (_return.EndsWith("^"))
        _return = _return.Substring(0, _return.Length - 1);

      return _return;
    }

    public static List<Z_Padrao> GetDescricaoProcesso(List<ProcessoFabricacao> listaProcessoFabricacao) {
      var _return = new List<Z_Padrao>();

      try {
        foreach (var processo in listaProcessoFabricacao) {
          if (!_return.Any(x => x.Descricao == processo.DescricaoProcesso))
            _return.Add(new Z_Padrao { Codigo = Convert.ToInt32(processo.IdProcesso), Descricao = processo.DescricaoProcesso });
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao retornar descrição volume\n\n{ex.Message}", "Addin LM Projetos",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return _return;
    }

    #endregion
  }
}
