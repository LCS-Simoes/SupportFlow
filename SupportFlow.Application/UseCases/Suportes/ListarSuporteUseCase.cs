using SupportFlow.Application.DTOs.SuporteDTOs;
using SupportFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.UseCases.Suportes
{
    public class ListarSuporteUseCase
    {
        private readonly ISuporte _suporteRepository;

        public ListarSuporteUseCase(ISuporte repository)
        {
            _suporteRepository = repository;
        }

        public async Task<List<SuporteResponse>> Handle()
        {
            var suportes = await _suporteRepository.TodosChamados();

            return suportes.Select(s => new SuporteResponse
            {
                Id = s.Id,
                Nome = s.Nome!,
                Descricao = s.Descricao!,
                Status = s.Status,
                DataSuporte = s.DataSuporte
            }).ToList();
        }
    }
}
