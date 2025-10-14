using SupportFlow.Application.DTOs.SuporteDTOs;
using SupportFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.UseCases.Suportes
{
    public class BuscarSuporteIdUseCase
    {
        private readonly ISuporte _suporteRepository;

        public BuscarSuporteIdUseCase(ISuporte repository)
        {
            _suporteRepository = repository;
        }

        public async Task<SuporteResponse?> Handle(int id)
        {
            var suporte = await _suporteRepository.BuscarID(id);
            if (suporte == null) return null;

            return new SuporteResponse
            {
                Id = suporte.Id,
                Nome = suporte.Nome!,
                Descricao = suporte.Descricao!,
                Status = suporte.Status,
                DataSuporte = suporte.DataSuporte
            };
        }
    }
}
