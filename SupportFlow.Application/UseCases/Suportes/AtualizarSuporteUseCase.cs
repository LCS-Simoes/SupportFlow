using SupportFlow.Application.DTOs;
using SupportFlow.Domain.Enums;
using SupportFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.UseCases.Suportes
{
    public class AtualizarSuporteUseCase
    {
        private readonly ISuporte _suporteRepository;

        public AtualizarSuporteUseCase(ISuporte repository)
        {
            _suporteRepository = repository;
        }

        public async Task<SuporteResponse?> Handle(int id, AtualizarSuporteRequest request)
        {
            var suporte = await _suporteRepository.BuscarID(id);
            if(suporte == null) return null;

            if (!string.IsNullOrEmpty(request.Nome))
            {
                suporte.Nome = request.Nome;
            }

            if(!string.IsNullOrEmpty(request.Descricao))
            {
                suporte.Descricao = request.Descricao;
            }

            if (!string.IsNullOrEmpty(request.Status) && Enum.TryParse<Status>(request.Status, out var novoStatus))
            {
                suporte.Status = novoStatus;
            }

            var atualizado = await _suporteRepository.Atualizar(suporte, id);

            return new SuporteResponse
            {
                Id = atualizado.Id,
                Nome = atualizado.Nome!,
                Descricao = atualizado.Descricao!,
                Status = atualizado.Status,
                DataSuporte = atualizado.DataSuporte
            };
        }
    }

}
