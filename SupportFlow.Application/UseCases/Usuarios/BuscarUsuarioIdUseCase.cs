using SupportFlow.Application.DTOs;
using SupportFlow.Application.DTOs.SuporteDTOs;
using SupportFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.UseCases.Usuarios
{
    public class BuscarUsuarioIdUseCase
    {
        private readonly IUsuario _usuarioRepositorio;

        public BuscarUsuarioIdUseCase(IUsuario repository)
        {
            _usuarioRepositorio = repository;
        }

        public async Task<UsuarioResponse> Handle(int id)
        {
            var usuario = await _usuarioRepositorio.BuscarId(id);
            if (usuario == null) return null;

            return new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Username = usuario.Username,
                Senha = usuario.Senha,
                perfil = usuario.Perfil,
                setor = usuario.Setor
            };
        }
    }
}
