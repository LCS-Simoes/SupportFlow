using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.DTOs.UsuarioDTOs
{
    public class BuscarLoginRequest
    {
        public string Username { get; set; }
        public string Senha {  get; set; }
        public bool LembrarMe { get; set; }
    }
}
