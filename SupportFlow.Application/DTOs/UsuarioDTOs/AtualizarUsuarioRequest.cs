using SupportFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.DTOs
{
    public class AtualizarUsuarioRequest
    {
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string? setor { get; set; }
        public string? perfil { get; set; }
    }
}
