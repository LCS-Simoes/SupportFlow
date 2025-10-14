using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.DTOs.SuporteDTOs
{
    public class CriarSuporteResquest
    {
        public string? Nome {  get; set; }
        public string? Descricao { get; set; }
        public int? UsuarioID  { get; set; }
    }
}
