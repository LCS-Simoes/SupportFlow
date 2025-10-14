using SupportFlow.Application.DTOs;
using SupportFlow.Domain.Entities;
using SupportFlow.Domain.Enums;
using SupportFlow.Domain.Interfaces;

namespace SupportFlow.Application.UseCases.Usuarios
{
    public class AtualizarUsuarioUseCase
    {
        private readonly IUsuario _usuarioRepository;

        public AtualizarUsuarioUseCase(IUsuario repository)
        {
            _usuarioRepository = repository;
        }

        public async Task<UsuarioResponse?> Handle(int id, AtualizarUsuarioRequest request)
        {
            var usuario = await _usuarioRepository.BuscarId(id);
            if (usuario == null) return null;

            //Fazer uma classe de validações posteriormente
            if (!string.IsNullOrEmpty(request.Nome))
            {
                usuario.Nome = request.Nome;
            }

            if (!string.IsNullOrEmpty(request.Username))
            {
                usuario.Username = request.Username;

            }

            if (!string.IsNullOrEmpty(request.Senha))
            {
                usuario.Senha = request.Senha;
            }

            if (!string.IsNullOrEmpty(request.perfil) && Enum.TryParse<Perfil>(request.perfil, out var novoPerfil))
            {
                usuario.Perfil = novoPerfil;
            }

            if (!string.IsNullOrEmpty(request.setor) && Enum.TryParse<Setor>(request.setor, out var novoSetor))
            {
                usuario.Setor = novoSetor;
            }

            var atualizado = await _usuarioRepository.Atualizar(usuario, id);

            return new UsuarioResponse
            {
                Id = atualizado.Id,
                Nome = atualizado.Nome,
                Username = atualizado.Username,
                Senha = atualizado.Senha,
                perfil = atualizado.Perfil,
                setor = atualizado.Setor
            };
        }
    }
}
