using SupportFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Domain.Entities
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public Setor Setor {  get; set; }
        public Perfil Perfil { get; set; }
    }
}
