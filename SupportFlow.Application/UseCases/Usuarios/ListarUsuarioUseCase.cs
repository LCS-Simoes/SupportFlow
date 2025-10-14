using SupportFlow.Application.DTOs;
using SupportFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.UseCases.Usuarios
{
    public class ListarUsuarioUseCase
    {
        private readonly IUsuario _usuarioReposity;

        public ListarUsuarioUseCase(IUsuario reposity)
        {
            _usuarioReposity = reposity;
        }

        public async Task<List<UsuarioResponse>> Handle()
        {
            var usuarios = await _usuarioReposity.TodosUsuarios();

            return usuarios.Select(s => new UsuarioResponse
            {
                Id = s.Id,
                Nome = s.Nome,
                Username = s.Username,
                Senha = s.Senha,
                perfil = s.Perfil,
                setor = s.Setor,
            }).ToList();
        }
    }
}
