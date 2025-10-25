using SupportFlow.Application.DTOs.SuporteDTOs;
using SupportFlow.Domain.Entities;
using SupportFlow.Domain.Enums;
using SupportFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.UseCases.Suportes
{
    public class CriarSuporteUseCase
    {
        public readonly ISuporte _suporteRepository;
        public readonly IUsuario _usuarioRepository;

        public CriarSuporteUseCase(ISuporte suporteRepository, IUsuario usuarioRepository)
        {
            _suporteRepository = suporteRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<SuporteResponse> ExecuteAsync(CriarSuporteResquest request)
        {
            var usuario = await _usuarioRepository.BuscarId(request.UsuarioID);
            if (usuario == null) throw new Exception("Usuário não encontrado");

            var suporte = new Suporte
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                Status = Status.Aberta,
                DataSuporte = DateTimeOffset.UtcNow,
                UsuarioID = request.UsuarioID,
                Usuario = usuario
            };

            var criado = await _suporteRepository.Criar(suporte);

            return new SuporteResponse
            {
                Id = criado.Id, 
                Nome = criado.Nome!,
                Descricao = criado.Descricao!,
                Status = criado.Status,
                DataSuporte = criado.DataSuporte,
                UsuarioID= usuario.Id,
                NomeUsuario = usuario.Nome
            };
        }
    }
}
