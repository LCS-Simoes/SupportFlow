using SupportFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.UseCases.Suportes
{
    public class DeletarSuporteUseCase
    {
        private readonly ISuporte _suporteRepository;

        public DeletarSuporteUseCase(ISuporte repository)
        {
            _suporteRepository = repository;
        }

        public async Task<bool> Handle(int id)
        {
            return await _suporteRepository.Deletar(id);
        }
    }
}
