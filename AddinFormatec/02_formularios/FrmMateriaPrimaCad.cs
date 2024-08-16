using LmCorbieUI;
using LmCorbieUI.LmForms;
using LmCorbieUI.Metodos;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AddinFormatec {
  public partial class FrmMateriaPrimaCad : LmSingleForm {
    public FrmMateriaPrimaCad(int idMateriaPrima = 0) {
      InitializeComponent();

      txtID.Text = idMateriaPrima.ToString("#");
      CarregarComboMaterial();
      MateriaPrima.Carregar();
    }

    private void FrmMateriaPrimaCad_Load(object sender, EventArgs e) {
      if (!string.IsNullOrEmpty(txtID.Text))
        TxtID_Leave(txtID, new EventArgs());
      else
        BtnLimpar_Click(null, new EventArgs());
    }

    private void BtnLimpar_Click(object sender, EventArgs e) {
      txtID.ReadOnly = false;
      txtEspessura.Focus();
      txtID.Text = txtEspessura.Text =  string.Empty;
      txtMaterial.SelectedValue = null;
      ckbSituacao.Checked = true;
      MateriaPrima.model = new MateriaPrima();
    }

    private void BtnSalvar_Click(object sender, EventArgs e) {
      if (Controles.PossuiCamposInvalidos(this)) return;

      var chapa = (vw_produto)txtMaterial.SelectedItem;

      MateriaPrima.model.Espessura = Convert.ToDouble(txtEspessura.Text);
      MateriaPrima.model.ChapaID = chapa.codigo_produto;
      MateriaPrima.model.ChapaDesc = chapa.descricao_produto;
      MateriaPrima.model.MaterialDesc = chapa.subgrupo_produto_desc;
      MateriaPrima.model.Ativo = ckbSituacao.Checked;

      if (MateriaPrima.ListaMateriaPrima.Any(x => x.ID != MateriaPrima.model.ID && x.ChapaDesc == MateriaPrima.model.ChapaDesc)) {
        Toast.Warning("Já existe um registro com esta mesma descrição!");
      } else {
        MateriaPrima.Salvar(); Toast.Info("Salvo com Sucesso!");
        BtnLimpar_Click(sender, new EventArgs());
      }
    }

    private void BtnExcluir_Click(object sender, EventArgs e) {

    }

    private void TxtID_ButtonClickF7(object sender, EventArgs e) {
      FrmConsultaGeral frm = new FrmConsultaGeral(this,
        MateriaPrima.ListaMateriaPrima, "Consulta de Matéria Prima");
      if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK /*&& Modo == Modo.Novo*/)
        if (int.TryParse(frm.valor[0], out int ID)) {
          txtID.Text = frm.valor[0];
          TxtID_Leave(null, new EventArgs());
        }
    }

    private void TxtID_Leave(object sender, EventArgs e) {
      if (!string.IsNullOrEmpty(txtID.Text)) {
        int id = int.Parse(txtID.Text);

        if (MateriaPrima.model.ID == id) return;
        MateriaPrima.model = MateriaPrima.ListaMateriaPrima.FirstOrDefault(x => x.ID == id);

        txtID.Text = MateriaPrima.model.ID.ToString();
        txtEspessura.Text = MateriaPrima.model.Espessura?.ToString("0.0000");
        txtMaterial.SelectedValue = MateriaPrima.model.ChapaID.ToString();
        txtMaterial.Text = MateriaPrima.model.ChapaDesc;

        txtID.ReadOnly = true;
      }
    }

    private void CarregarComboMaterial() {
      try {
        txtMaterial.CarregarComboBox(vw_produto.SelecionarChapas());
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao carregar grid Material");
      }
    }
  }
}
