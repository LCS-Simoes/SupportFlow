using SupportFlow.Application.DTOs;
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

        public CriarSuporteUseCase(ISuporte suporteRepository)
        {
            _suporteRepository = suporteRepository;
        }

        public async Task<SuporteResponse> ExecuteAsync(CriarSuporteResquest request)
        {
            var suporte = new Suporte
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                UsuarioID = request.UsuarioID,
                Status = Status.Aberta,
                DataSuporte = DateTimeOffset.UtcNow
            };

            var criado = await _suporteRepository.Criar(suporte);

            return new SuporteResponse
            {
                Id = criado.Id, 
                Nome = criado.Nome!,
                Descricao = criado.Descricao!,
                Status = criado.Status,
                DataSuporte = criado.DataSuporte
            };
        }
    }
}
