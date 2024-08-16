using System.Collections.Generic;

namespace AddinFormatec {
  public class ComponenteEstrutura
    {
        public string Nivel { get; set; }

        public string Denominacao { get; set; }

        public string NomeComponente { get; set; }

        public string PathName { get; set; }

        public string ConfigName { get; set; }

        public string Check { get; set; }

        public bool EhItemPai { get; set; }

        public int Quantidade { get; set; }

        // public bool FoiAdicionado { get; set; } 

        public List<ComponenteEstrutura> CompFilhos = new List<ComponenteEstrutura>();
    }
}
