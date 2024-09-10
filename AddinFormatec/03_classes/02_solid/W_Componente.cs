using LmCorbieUI.Metodos.AtributosCustomizados;
using LmCorbieUI.Metodos;
using LmCorbieUI;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace AddinFormatec {
  internal class W_Componente {
    [DisplayName("NOME")]
    [LarguraColunaGrid(120)]
    public string NomeComponente { get; set; }

    [LarguraColunaGrid(80)]
    [DisplayName("QTD")]
    [AlinhamentoColunaGrid(DataGridViewContentAlignment.MiddleCenter)]
    public int Quantidade { get; set; }

    [LarguraColunaGrid(350)]
    [DisplayName("DESCRIÇÃO")]
    public string Denominacao { get; set; }

    [Browsable(false)]
    public string PathName { get; set; }

    #region Metodos

    public static SortableBindingList<W_Componente> GetComponents() {
      var _listaFinal = new SortableBindingList<W_Componente>();

      try {
        FormatoFolha.Carregar();
        SldWorks swApp = new SldWorks();
        var swModel = (ModelDoc2)swApp.ActiveDoc;
        ModelDocExtension swModelDocExt;
        CustomPropertyManager swCustPropMgr;

        ConfigurationManager swConfMgr;
        Configuration swConf;
        // Component2 swRootComp;

        swModelDocExt = swModel.Extension;
        swConfMgr = swModel.ConfigurationManager;
        swConf = swConfMgr.ActiveConfiguration;
        // swRootComp = swConf.GetRootComponent3(true);
        string valOut;
        string resolvedValOut;

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY) {
          MsgBox.ShowWaitMessage("Lendo componentes da montagem...");

          swCustPropMgr = swModelDocExt.get_CustomPropertyManager(swConf.Name);

          var componente = new W_Componente();

          componente.PathName = swModel.GetPathName();
          componente.NomeComponente = Path.GetFileNameWithoutExtension(componente.PathName);
          componente.Quantidade = 1;

          var directoryPath = Path.GetDirectoryName(componente.PathName);
          var backupPrefix = "~$";

          string[] files = Directory.GetFiles(directoryPath);

          foreach (string file in files.Where(x => Path.GetFileNameWithoutExtension(x).StartsWith(backupPrefix))) {
            //if (Path.GetFileName(file).StartsWith(backupPrefix)) {
            try {
              File.Delete(file);
              Console.WriteLine($"Arquivo excluído: {file}");
            } catch (Exception ex) {
              Console.WriteLine($"Erro ao excluir o arquivo {file}: {ex.Message}");
            }
            //}
          }

          swCustPropMgr.Get2("sgl_DescricaoEspecifica", out valOut, out resolvedValOut);
          componente.Denominacao = resolvedValOut;

          _listaFinal.Add(componente);

          // Inserir lista de material e pegar dados
          string templateGeral = $"{Application.StartupPath}\\01 - Addin Formatec\\ListaComponentes.sldbomtbt";
          int BomTypeGeral = (int)swBomType_e.swBomType_Indented;
          int NumberingType = (int)swNumberingType_e.swNumberingType_Detailed;
          var swBOMAnnotationGeral = swModelDocExt.InsertBomTable3(templateGeral, 0, 1, BomTypeGeral, swConf.Name, Hidden: false, NumberingType, DetailedCutList: true);
          PegaDadosListaGeral(swApp, swBOMAnnotationGeral, _listaFinal);
          ListaCorte.ExcluirLista(swModel);

        } else {
          var componente = new W_Componente();
          string ptNm = swModel.GetPathName();

          componente.PathName = ptNm;
          componente.NomeComponente = Path.GetFileNameWithoutExtension(componente.PathName);

          CustomPropertyManager swCustPropMngr = swModelDocExt.get_CustomPropertyManager(swConf.Name);

          swCustPropMngr.Get2("sgl_DescricaoEspecifica", out valOut, out resolvedValOut);
          componente.Denominacao = resolvedValOut;

          componente.Quantidade = 1;

          _listaFinal.Add(componente);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao ler componente para Processos\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return _listaFinal;
    }

    private static void PegaDadosListaGeral(SldWorks swApp, BomTableAnnotation swBOMAnnotation, SortableBindingList<W_Componente> listaComponentes) {
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
            var componente = new W_Componente();
            string ptNm = vModelPathNames[0];

            componente.PathName = ptNm;
            componente.NomeComponente = Path.GetFileNameWithoutExtension(ptNm).ToUpper();

            if (string.IsNullOrEmpty(componente.NomeComponente))
              continue;

            if (int.TryParse(swTableAnnotation.get_Text(i, 1).Trim(), out int qtd)) {
              componente.Quantidade = qtd;
              componente.Denominacao = swTableAnnotation.get_Text(i, 4).Trim();

              //bool isSheetMetal = IsSheetMetal(swApp, componente.PathName, fecharPeca: true);
              if (!listaComponentes.Any(x => x.NomeComponente == componente.NomeComponente))
                listaComponentes.Add(componente);
              else
                listaComponentes.FirstOrDefault(x => x.NomeComponente == componente.NomeComponente).Quantidade += componente.Quantidade;
            }
          }
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar dados da Lista\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    #endregion
  }
}
