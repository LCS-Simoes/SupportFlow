using SupportFlow.Application.DTOs;
using SupportFlow.Domain.Entities;
using SupportFlow.Domain.Enums;
using SupportFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.UseCases.Usuarios
{
    public class CriarUsuarioUseCase
    {
        private readonly IUsuario _usuarioRepository;

        public CriarUsuarioUseCase(IUsuario usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioResponse> ExecuteAsync(CriarUsuarioRequest request)
        {
            var usuario = new Usuario
            {
                Nome = request.Nome,
                Username = request.Username,
                Senha = request.Senha,
                Perfil = (Perfil)Enum.Parse(typeof(Perfil), request.perfil),
                Setor = (Setor)Enum.Parse(typeof(Setor), request.setor)
            };

            var criado = await _usuarioRepository.Cadastrar(usuario);

            return new UsuarioResponse
            {
                Id = criado.Id,
                Nome = criado.Nome,
                Username = criado.Username,
                Senha = criado.Senha,
                perfil = criado.Perfil,
                setor = criado.Setor
            };
        }
    }
}

/*
 * Problemas a ser corrigido: Implementação do usuario e Setor elas deveriam ser a escolha 
 * do usuario, não algo padrão.
*/