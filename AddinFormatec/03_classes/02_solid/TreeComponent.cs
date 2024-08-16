using LmCorbieUI;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace AddinFormatec {
  internal class TreeComponent {

    public string codigo { get; set; }
    public string descricao { get; set; }
    public string pathName { get; set; }
    public string configName { get; set; }
    public string grupo { get; set; }
    public string subGrupo { get; set; }
    public string um { get; set; }
    public string operacao { get; set; }
    public TipoComponente tipoComponente { get; set; }

    //public bool possuiProps { get; set; }
    //public bool possuiProcess { get; set; }

    public static void GetComponents(TreeView treeView) {
      try {
        treeView.Nodes.Clear();

        ImageList il = new ImageList();
        il.Images.Add(0.ToString(), Properties.Resources.trv_assembly);
        il.Images.Add(1.ToString(), Properties.Resources.trv_part);
        il.Images.Add(2.ToString(), Properties.Resources.trv_material);

        treeView.ImageList = il;
        treeView.ItemHeight = 21;

        FormatoFolha.Carregar();
        SldWorks swApp = new SldWorks();
        var swModel = (ModelDoc2)swApp.ActiveDoc;
        var tipoDoc = (swDocumentTypes_e)swModel.GetType();
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
        TreeNode rootNode = new TreeNode();

        swCustPropMgr = swModelDocExt.get_CustomPropertyManager(swConf.Name);

        swCustPropMgr.Get2("sgl_DescricaoEspecifica", out valOut, out resolvedValOut);
        var descRoot = resolvedValOut;

        var cod = Path.GetFileNameWithoutExtension(swModel.GetPathName());

        swCustPropMgr = swModelDocExt.get_CustomPropertyManager("");

        swCustPropMgr.Get2("sgl_operacao", out valOut, out resolvedValOut);
        var process = resolvedValOut;

        swCustPropMgr.Get2("sgl_GrupoProduto", out valOut, out resolvedValOut);
        var grupoProduto = resolvedValOut;

        swCustPropMgr.Get2("sgl_SubgrupoProduto", out valOut, out resolvedValOut);
        var subgrupoProduto = resolvedValOut;

        swCustPropMgr.Get2("sgl_UM", out valOut, out resolvedValOut);
        var um = resolvedValOut;

        if (swConf.UseAlternateNameInBOM == true) {
          if (!string.IsNullOrEmpty(swConf.AlternateName))
            cod = swConf.AlternateName;
          else
            cod = swConf.Name;
        }

        swCustPropMgr = swModelDocExt.get_CustomPropertyManager(swConf.Name);
        var tipo = tipoDoc == swDocumentTypes_e.swDocASSEMBLY ? TipoComponente.Montagem : TipoComponente.Peca;
        TreeComponent componente = new TreeComponent {
          codigo = cod,
          descricao = descRoot,
          pathName = swModel.GetPathName(),
          configName = swConf.Name,
          tipoComponente = tipo,
          grupo = grupoProduto,
          subGrupo = subgrupoProduto,
          um = um,
          operacao = process,
        };

        rootNode = treeView.Nodes.Add("Root", $"{cod} - {descRoot}");
        rootNode.Tag = componente;

        if (string.IsNullOrEmpty(componente.grupo) ||
          string.IsNullOrEmpty(componente.subGrupo) ||
          string.IsNullOrEmpty(componente.um) ||
          string.IsNullOrEmpty(componente.operacao)) {
          rootNode.ForeColor = Color.Red;
        }

        if (tipoDoc == swDocumentTypes_e.swDocASSEMBLY) {
          MsgBox.ShowWaitMessage("Lendo componentes da montagem...");

          // Inserir lista de material e pegar dados
          string templateGeral = $"{Application.StartupPath}\\01 - Addin Formatec\\ListaComponentes.sldbomtbt";
          int BomTypeGeral = (int)swBomType_e.swBomType_Indented;
          int NumberingType = (int)swNumberingType_e.swNumberingType_Detailed;
          var swBOMAnnotationGeral = swModelDocExt.InsertBomTable3(templateGeral, 0, 1, BomTypeGeral, swConf.Name, Hidden: false, NumberingType, DetailedCutList: true);
          PegaDadosListaGeral(swApp, swBOMAnnotationGeral, treeView, rootNode);
          ListaCorte.ExcluirLista(swModel);
        } else {
          FeatureManager swFeatMgr = swModel.FeatureManager;
          Feature swFeat = swModel.FirstFeature();

          while ((swFeat != null)) {
            var FeatTypeName = swFeat.GetTypeName2();

            if (FeatTypeName == "CutListFolder") {
              BodyFolder swBodyFolder = (BodyFolder)swFeat.GetSpecificFeature2();
              int bodyCount = swBodyFolder.GetBodyCount();

              if (bodyCount > 0) {
                var boolstatus = swModel.Extension.SelectByID2(swFeat.Name, "SUBWELDFOLDER", 0, 0, 0, false, 0, null, 0);
                SelectionMgr swSelMgr = (SelectionMgr)swModel.SelectionManager;
                swFeat = (Feature)swSelMgr.GetSelectedObject6(1, 0);

                CustomPropertyManager swCustPropMngr = swFeat.CustomPropertyManager;
                object[] custPropNames = (object[])swCustPropMngr.GetNames();

                if (custPropNames != null) {
                  string sValue, sResolvedvalue;

                  swBodyFolder.SetAutomaticCutList(true);
                  swBodyFolder.UpdateCutList();

                  var namePropCod = custPropNames.FirstOrDefault(x => x.ToString().Trim() == "CÓDIGO MATERIAL");
                  swCustPropMngr.Get2((string)namePropCod, out sValue, out sResolvedvalue);
                  var codMat = sResolvedvalue.ToString();

                  var namePropDesc = custPropNames.FirstOrDefault(x => x.ToString().Trim() == "DESCRIÇÃO MATERIAL");
                  swCustPropMngr.Get2((string)namePropDesc, out sValue, out sResolvedvalue);
                  var descMat = sResolvedvalue.ToString();

                  var nameProcess = custPropNames.FirstOrDefault(x => x.ToString().Trim() == "sgl_operacao");
                  swCustPropMngr.Get2((string)nameProcess, out sValue, out sResolvedvalue);
                  var processList = sResolvedvalue.ToString();

                  TreeComponent componenteLista = new TreeComponent {
                    codigo = codMat,
                    descricao = descMat,
                    pathName = swModel.GetPathName(),
                    configName = swConf.Name,
                    tipoComponente = TipoComponente.ListaMaterial,
                    grupo = string.Empty,
                    subGrupo = string.Empty,
                    um = string.Empty,
                    operacao = processList,
                  };

                  var childNode = new TreeNode($"{codMat} - {descMat}") {
                    ImageIndex = 2,
                    SelectedImageIndex = 2,
                    Tag = componenteLista,
                  };

                  if (string.IsNullOrEmpty(componente.operacao)) {
                    childNode.ForeColor = Color.Red;
                  }

                  rootNode.Nodes.Add(childNode);
                }
              }
            }
            swFeat = (Feature)swFeat.GetNextFeature();
          }
        }

        rootNode.ExpandAll();

      } catch (Exception ex) {
        MsgBox.Show($"Erro ao ler componente para Processos\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private static void PegaDadosListaGeral(SldWorks swApp, BomTableAnnotation swBOMAnnotation, TreeView treeView, TreeNode rootNode) {
      try {
        string[] vModelPathNames = null;
        string strItemNumber = null;
        string strPartNumber = null;
        var swTableAnnotation = (TableAnnotation)swBOMAnnotation;

        var swBOMFeature = swBOMAnnotation.BomFeature;

        Dictionary<string, TreeNode> nodes = new Dictionary<string, TreeNode>();

        for (int i = 0; i < swTableAnnotation.TotalRowCount; i++) {
          vModelPathNames = (string[])swBOMAnnotation.GetModelPathNames(i, out strItemNumber, out strPartNumber);

          if (vModelPathNames != null) {
            string pathName = vModelPathNames[0];

            var nivel = swTableAnnotation.get_Text(i, 0).Trim();
            var codigo = swTableAnnotation.get_Text(i, 2).Trim();
            var codigoMaterial = swTableAnnotation.get_Text(i, 3).Trim();
            var descricao = swTableAnnotation.get_Text(i, 4).Trim();
            var descricaoMaterial = swTableAnnotation.get_Text(i, 5).Trim();
            var nomeConfig = swTableAnnotation.get_Text(i, 6).Trim();
            var processo = swTableAnnotation.get_Text(i, 7).Trim();
            var grupoProduto = swTableAnnotation.get_Text(i, 8).Trim();
            var subgrupoProduto = swTableAnnotation.get_Text(i, 9).Trim();
            var um = swTableAnnotation.get_Text(i, 10).Trim();
            TipoComponente tipo = pathName.ToLower().EndsWith("sldasm")
              ? TipoComponente.Montagem
              : !string.IsNullOrEmpty(codigo) ? TipoComponente.Peca
              : TipoComponente.ListaMaterial;

            TreeComponent componente = new TreeComponent {
              codigo = tipo == TipoComponente.ListaMaterial ? codigoMaterial : codigo,
              descricao = tipo == TipoComponente.ListaMaterial ? descricaoMaterial : descricao,
              tipoComponente = tipo,
              pathName = pathName,
              configName = nomeConfig,
              grupo = grupoProduto,
              subGrupo = subgrupoProduto,
              um = um,
              operacao = processo,
            };

            var node = new TreeNode($"{componente.codigo} - {componente.descricao}");

            if (!string.IsNullOrEmpty(codigo))
              node.Tag = componente;

            var iconIndex = tipo == TipoComponente.Montagem ? 0 : tipo == TipoComponente.Peca ? 1 : 2;

            node.ImageIndex = iconIndex;
            node.SelectedImageIndex = iconIndex;

            if (tipo != TipoComponente.ListaMaterial && (
              string.IsNullOrEmpty(componente.grupo) ||
              string.IsNullOrEmpty(componente.subGrupo) ||
              string.IsNullOrEmpty(componente.um) )) {
              node.ForeColor = Color.Red;
            } else if (tipo == TipoComponente.ListaMaterial && string.IsNullOrEmpty(componente.operacao)) {
              node.ForeColor = Color.Red;
            }

            nodes[nivel] = node;

            if (nivel.Contains('.')) {
              var parentLevel = nivel.Substring(0, nivel.LastIndexOf('.'));
              nodes[parentLevel].Nodes.Add(node);
            } else {
              rootNode.Nodes.Add(node);
            }
          }
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao pegar dados da Lista\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

  }
}
