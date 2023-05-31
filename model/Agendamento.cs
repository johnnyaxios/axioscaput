using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiosCaput.model
{
    public class Agendamento
    {
        public int id { get; set; }
        public int id_cliente { get; set; }
        public string data_agendamento { get; set; }
        public string hora_agendamento { get; set; }
        public string observacao { get; set; }
        public string status { get; set; }
        public string data_cad { get; set; }
       
    }
}
