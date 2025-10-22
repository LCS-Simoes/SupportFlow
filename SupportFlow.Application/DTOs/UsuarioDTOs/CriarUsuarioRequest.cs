using SupportFlow.Application.Utils;
using SupportFlow.Domain.Entities;
using SupportFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.DTOs
{
    public class CriarUsuarioRequest
    {
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string setor { get; set; }
        public string perfil { get; set; }

        public Usuario ToEntity()
        {
            return new Usuario
            {
                Nome = Nome,
                Username = Username,
                Senha = SenhaHelper.GerarHash(Senha),
                Perfil = (Perfil)Enum.Parse(typeof(Perfil), perfil),
                Setor = (Setor)Enum.Parse(typeof(Setor), setor)
            };
        }
    }
}
