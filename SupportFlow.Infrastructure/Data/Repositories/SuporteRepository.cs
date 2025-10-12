using Microsoft.EntityFrameworkCore;
using SupportFlow.Domain.Entities;
using SupportFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Infrastructure.Data.Repositories
{
    public class SuporteRepository : ISuporte
    {
        private readonly SupportFlowDbContext _dbcontext;
        public SuporteRepository(SupportFlowDbContext supportFlowDbContext) 
        { 
            _dbcontext = supportFlowDbContext;
        }

        public async Task<List<Suporte>> TodosChamados()
        {
            return await _dbcontext.Suportes
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<Suporte> BuscarID(int id)
        {
            return await _dbcontext.Suportes
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
       
        public async Task<Suporte> Criar(Suporte suporte)
        {
            await _dbcontext.Suportes.AddAsync(suporte);
            await _dbcontext.SaveChangesAsync();
            return suporte;
        }

        public async Task<Suporte> Atualizar(Suporte suporte, int id)
        {
            Suporte suporteID = await BuscarID(id);

            if (suporteID == null)
            {
                throw new Exception($"Tarefa ID: {id} não foi encontrado no banco de dados");
            }

            suporteID.Nome = suporte.Nome;
            suporteID.Descricao = suporte.Descricao;
            suporteID.Status = suporte.Status;
            suporteID.UsuarioID = suporte.UsuarioID;

            _dbcontext.Suportes.Update(suporteID);
            await _dbcontext.SaveChangesAsync();
            return suporteID;
        }

        public async Task<bool> Deletar(int id)
        {
            Suporte suporteID = await BuscarID(id);

            if (suporteID == null)
            {
                throw new Exception($"Suporte: {id} não foi encontrado no banco de dados");
            }

            _dbcontext.Suportes.Remove(suporteID);
            await _dbcontext.SaveChangesAsync();
            return true;
        }  
    }
}
