using LmCorbieUI;
using System;
using System.Collections.Generic;

namespace AddinFormatec {
  internal class cadireta {
    /// <summary>
    /// Esse atributo deve ser criado pelo PDM, sem interferência de  usuário.O controle deve mudar a cada mudança de produto pai. 
    /// Deve ser verificado o último controle da tabela para iniciar a 
    /// exportação
    /// </summary>
    public long cadcont { get; set; }

    /// <summary>
    /// Esse atributo deve ser exportado pelo PDM, onde, essa 
    /// informação já estará reservada ou pode ser um código fantasma, 
    /// que será atualizado na importação, se existirem templates cadastrados.
    /// </summary>
    public string cadpai { get; set; } = "";

    /// <summary>
    /// Esse atributo deve receber o código do filho da estrutura.
    /// </summary>
    public string cadfilho { get; set; } = "";

    /// <summary>
    /// Ao exportar a estrutura deve ser gravado fixo com ‘N’, visto que,     
    /// ficará pendente de importação.Caso ocorrer algum problema e 
    /// for necessário cancelar a estrutura, deve ser gravado um ‘C’. O 
    /// ERP importará e gravará o campo com ‘I’, de importado. 
    /// </summary>
    public string cadstatus { get; set; } = "";

    /// <summary>
    /// Deve ser apenas gravado o usuário que fez a confirmação da 
    /// estrutura no PDM
    /// </summary>
    public int cadsuscad { get; set; } = 0;

    /// <summary>
    /// eve ser apenas gravada a descrição do item pai.
    /// </summary>
    public string cadpainome { get; set; } = "";

    /// <summary>
    /// Mesma coisa que o produto pai, deve ser exportada a descrição 
    /// do item filho
    /// </summary>
    public string cadfilnome { get; set; } = "";

    /// <summary>
    /// Neste campo deve ser possível informar a Unidade de Medida do 
    /// item Pai.Essa informação será fornecida por view.
    /// </summary>
    public string cadpaium { get; set; } = "";

    /// <summary>
    /// Neste campo deve ser possível informar a Unidade de Medida do 
    /// item filho.Essa informação será fornecida por view
    /// </summary>
    public string cadfilum { get; set; } = "";

    /// <summary>
    /// Deve ser exportada a quantidade da ligação da estrutura, Pai x Filho. 
    /// Este campo está em tela apenas para o item filho.
    /// </summary>
    public decimal caduso { get; set; } = 0;

    /// <summary>
    /// Comprimento final do produto filho da ligação. É usado em outra tabela. Exportar 0.
    /// </summary>
    public decimal cadcomp { get; set; } = 0;

    /// <summary>
    /// Largura fina do produto filho da ligação. É usado em outra tabela. Exportar 0
    /// </summary>
    public decimal cadlarg { get; set; } = 0;

    /// <summary>
    /// Espessura final do produto filho da ligação. É usado em outra tabela. Exportar 0.
    /// </summary>
    public decimal cadespe { get; set; } = 0;

    /// <summary>
    /// Peso do Produto Pai da Ligação. Fica em tela apenas para o produto pai
    /// </summary>
    public decimal cadpeso { get; set; } = 0;

    /// <summary>
    /// Fase de Produção da Ligação de Estrutura. Em tela para itens filhos e pais, menos para o nível 0.
    /// </summary>
    public short cadfase { get; set; } = 0;

    /// <summary>
    /// Deve respeitar o formato 0001-01-01  Data(AAAA-MM-DD)
    /// </summary>
    public DateTime cadgrav { get; set; } = DateTime.Now;

    /// <summary>
    /// Deve respeitar o formato 00:00:00 Hora(HH:mm:ss)
    /// </summary>
    public string cadhora { get; set; } = "";

    /*
    /// <summary>
    /// nformação preenchida no momento da importação da estrutura. 
    /// Na exportação, pode deixar o campo em branco
    /// </summary>
    public DateTime cadimpdt { get; set; } = DateTime.Now;

    /// <summary>
    ///  Informação preenchida no momento da importação da estrutura. 
    /// Na exportação, pode deixar o campo em branco
    /// </summary>
    public string cadimphr { get; set; } = "";

    /// <summary>
    /// Informação preenchida no momento da importação da estrutura. 
    /// Na exportação, pode deixar o campo em branco
    /// </summary>
    public string cadusuimp { get; set; } = "";

    /// <summary>
    /// Localização nas Prateleiras do item da Ligação. Esse campo pode 
    /// ser exportado em branco e não será usado pelo cliente no 
    /// momento.
    /// </summary>
    public string cadlocal { get; set; } = "";
    */

    /// <summary>
    /// Será o grupo do produto pai da ligação. 
    /// Essa informação pode ser alterada no CAD e será fornecida por view.
    /// </summary>
    public short cadgrpai { get; set; } = 0;

    /// <summary>
    /// Será o subgrupo do produto pai da ligação. 
    /// Essa informação pode ser alterada no CAD e será fornecida por view.
    /// </summary>
    public short cadsgpai { get; set; } = 0;

    /// <summary>
    /// SubGRupo do Produto Filho. Essa informação não pode ser 
    /// alterada para os materiais e itens não gráficos, apenas para filhos fabricados
    /// </summary>
    public short cadgrfil { get; set; } = 0;

    /// <summary>
    /// Grupo do Produto Filho da Ligação Grupo do Produto Filho. Essa 
    /// informação não pode ser alterada para os materiais e itens não
    /// gráficos, apenas para filhos fabricados.
    /// </summary>
    public short cadsgfil { get; set; } = 0;

    /// <summary>
    /// Prioridade de embarque do item.
    /// </summary>
    public short cadpriemb { get; set; } = 0;

    /// <summary>
    /// Nome do projetista da estrutura
    /// </summary>
    public string cadproj { get; set; } = "";

    /// <summary>
    /// Diretório do projeto Pai.
    /// </summary>
    public string cadarquivo { get; set; } = "";
    
    /*
    /// <summary>
    /// Deve ser exportado o comprimento bruto do item, se existir. É usado em outra tabela. Exportar 0
    /// </summary>
    public decimal cadcobr { get; set; } = 0;

    /// <summary>
    /// Deve ser exportada a largura bruta do produto, se existir. É usado em outra tabela. Exportar 0.
    /// </summary>
    public decimal cadlabr { get; set; } = 0;

    /// <summary>
    /// Deve ser exportada a espessura bruta do produto, se existir. É usado em outra tabela. Exportar 0.
    /// </summary>
    public decimal cadesbr { get; set; } = 0;

    /// <summary>
    /// Pode ser exportado em branco
    /// </summary>
    public string cadclass { get; set; } = "";
    */

    /// <summary>
    /// Habilitado apenas para os itens com medidas. S/N
    /// </summary>
    public string cadplcor { get; set; } = "";

    /// <summary>
    /// Define se o item usa medidas. Se sim, deve ser inserida as 
    /// medidas, se não, não deve ser inserida medida, exportando 0 
    /// para os campos de dimensões.Válido apenas para materiais
    /// </summary>
    public string cadusamed { get; set; } = "";

    /// <summary>
    /// Exportar fixo N
    /// </summary>
    public string cadborint { get; set; } = "";

    /// <summary>
    /// Exportar fixo N
    /// </summary>
    public string cadborsup { get; set; } = "";

    /// <summary>
    /// Exportar fixo N
    /// </summary>
    public string cadborinf { get; set; } = "";

    /// <summary>
    /// Exportar fixo N
    /// </summary>
    public string cadboresq { get; set; } = "";

    /// <summary>
    /// Exportar fixo N
    /// </summary>
    public string cadbordir { get; set; } = "";

    /// <summary>
    /// Deve ser exportada a área do produto pai da ligação
    /// </summary>
    public decimal cadpaiarea { get; set; } = 0;

    /*
    /// <summary>
    /// Pode ser exportado em branco
    /// </summary>
    public string cadtipfil { get; set; } = "";
    */

    /// <summary>
    /// Campo para o item Pai
    /// </summary>
    public long cadpembpr { get; set; } = 0;

    /// <summary>
    /// Campo para o item Filho
    /// </summary>
    public long cadpembpp { get; set; } = 0;

    /// <summary>
    /// Campo com as opções N e S, onde, definirá se o produto será 
    /// industrializado.Válido apenas para itens fabricados
    /// </summary>
    public string cadindter { get; set; } = "";

    /*
    /// <summary>
    /// Percentual de Quebra. Não é mais usado, busca da tabela CADIREDI. Gravar 0.00.
    /// </summary>
    public decimal caddimper { get; set; } = 0;
    */

    /// <summary>
    /// Aplicativo que fez a exportação da estrutura. Pode exportar a informação ‘ADDIN’.
    /// </summary>
    public string cadapp { get; set; } = "";

    /// <summary>
    /// Diretório do projeto Filho.
    /// </summary>
    public string cadarqfil { get; set; } = "";

    /*
    /// <summary>
    /// 
    /// </summary>
    public decimal cadpesbru { get; set; } = 0;

    /// <summary>
    /// 
    /// </summary>
    public string cadpaifan { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    public string cadfilfan { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    public string cadmarca { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    public string cadusuma { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    public long cadmcontp { get; set; } = 0;

    /// <summary>
    /// 
    /// </summary>
    public string cadmpai { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    public long cadidlote { get; set; } = 0;

    /// <summary>
    /// 
    /// </summary>
    public string cadreap { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    public string cadligfan { get; set; } = "";
    */

    public static List<cadireta> SelecionarProdutos() {
      var _return = new List<cadireta>();
      try {
        using (var connection = ConexaoPgSql.GetConexao()) {
          connection.Open();
          using (var cmd = connection.CreateCommand()) {

            cmd.CommandText = $"SELECT * FROM cadireta";
            using (var dr = cmd.ExecuteReader()) {
              while (dr.Read()) {
                _return.Add(new cadireta {
                  cadcont = dr.GetInt64(dr.GetOrdinal("codigo_produto")),
                  //descricao_produto = dr.GetString(dr.GetOrdinal("descricao_produto")).Trim(),
                  //grupo_produto = dr.GetInt32(dr.GetOrdinal("grupo_produto")),
                  //subgrupo_produto = dr.GetInt32(dr.GetOrdinal("subgrupo_produto")),
                  //um_produto = dr.GetString(dr.GetOrdinal("um_produto")).Trim(),
                  //origem_produto = dr.GetString(dr.GetOrdinal("origem_produto")).Trim(),
                  //status_produto = dr.GetString(dr.GetOrdinal("status_produto")).Trim(),
                  //fase_padrao_consumo = dr.GetInt32(dr.GetOrdinal("fase_padrao_consumo")),
                });
              }
            }
          }
        }
      } catch (Exception ex) {
        MsgBox.Show(ex.Message, "Erro ao Selecionar Produtos",
          System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
      }
      return _return;
    }

  }
}
