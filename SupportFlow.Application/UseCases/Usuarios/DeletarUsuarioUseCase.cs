using SupportFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.UseCases.Usuarios
{
    public class DeletarUsuarioUseCase
    {
        private readonly IUsuario _usuarioRepository;

        public DeletarUsuarioUseCase(IUsuario repository)
        {
            _usuarioRepository = repository;
        }

        public async Task<bool> Handle(int id)
        {
            return await _usuarioRepository.Deletar(id);
        }
    }
}
