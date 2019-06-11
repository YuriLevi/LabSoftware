using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvedorDeServicos.Models
{
    public class AlertaModel
    {
        public string Tipo { get; set; }

        public string Descricao { get; set; }

        public DateTime data { get; set; }
    }
}
