using LmCorbieUI;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace AddinFormatec {
  internal class Produto {
    [DataObjectField(true, false)]
    public string codigoProduto { get; set; } 
    [DataObjectField(false, true)]
    public string sgl_DescricaoEspecifica { get; set; }
    public int sgl_GrupoProduto { get; set; }
    public int sgl_SubgrupoProduto { get; set; }
    public string sgl_UM { get; set; }
    public string pathName { get; set; }

    public static vw_produto vw_Produto { get; set; } = new vw_produto();

    public static Produto GetProduct(ModelDoc2 swModel) {
      Produto _return = new Produto();

      try {
        object[] ativeConfiguration = null;
        string valOut;
        string resolvedValOut;
        double[] massProp;

        var swModelDocExt = swModel.Extension;

        swModel.Rebuild((int)swRebuildOptions_e.swRebuildAll);

        ConfigurationManager swConfMgr;
        Configuration swConf;

        swConfMgr = swModel.ConfigurationManager;
        swConf = swConfMgr.ActiveConfiguration;
        ativeConfiguration = (object[])swModel.GetConfigurationNames();

        var swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");

        _return.pathName = swModel.GetPathName();
        _return.codigoProduto = Path.GetFileNameWithoutExtension(_return.pathName);

        if (swConf.UseAlternateNameInBOM == true) {
          if (!string.IsNullOrEmpty(swConf.AlternateName))
            _return.codigoProduto = swConf.AlternateName;
          else
            _return.codigoProduto = swConf.Name;
        }

        swCustPropMngr.Get2("sgl_GrupoProduto", out valOut, out resolvedValOut);
        _return.sgl_GrupoProduto = !string.IsNullOrEmpty(resolvedValOut) ? Convert.ToInt32(resolvedValOut) : 0;

        swCustPropMngr.Get2("sgl_SubgrupoProduto", out valOut, out resolvedValOut);
        _return.sgl_SubgrupoProduto = !string.IsNullOrEmpty(resolvedValOut) ? Convert.ToInt32(resolvedValOut) : 0;

        swCustPropMngr.Get2("sgl_UM", out valOut, out resolvedValOut);
        _return.sgl_UM = resolvedValOut;

        swCustPropMngr = swModelDocExt.get_CustomPropertyManager(swConf.Name);

        swCustPropMngr.Get2("sgl_DescricaoEspecifica", out valOut, out resolvedValOut);
        _return.sgl_DescricaoEspecifica = resolvedValOut;

        massProp = (double[])swModelDocExt.GetMassProperties(1, 0);

        // vw_Produto = vw_produto.GetProduto(_return.codigoProduto);

        //_return.itens_corte = ListaCorte.GetCutList(swModel);
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao Caregar Produto");
      }

      return _return;
    }
  }
}
