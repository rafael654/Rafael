using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ByteBank
{
    public class Cliente
    {

        private string _cpf;

        public string profissao { get; set; }
        public string nome { get; set; }
        public string cpf{ get
            {
                return _cpf;
            }
            set
            {
                _cpf = value;
            }

        }
        

    }
}
