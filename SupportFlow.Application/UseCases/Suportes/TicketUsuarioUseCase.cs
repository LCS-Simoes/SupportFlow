using SupportFlow.Application.DTOs.SuporteDTOs;
using SupportFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.UseCases.Suportes
{
    public class TicketUsuarioUseCase
    {

        private readonly ISuporte _suporteRepository;

        public TicketUsuarioUseCase(ISuporte repository)
        {
            _suporteRepository = repository;
        }

        public async Task<List<SuporteResponse>> Handle(int usuarioID)
        {
            var suportes = await _suporteRepository.TicketUsuario(usuarioID);

            return suportes.Select(s => new SuporteResponse
            {
                Id = s.Id,
                Nome = s.Nome,
                Descricao = s.Descricao,
                Status = s.Status,
                DataSuporte = s.DataSuporte,
                UsuarioID = s.UsuarioID,
                NomeUsuario = s.Usuario != null ? s.Usuario.Nome : null
            }).ToList();
        }
    }
}
