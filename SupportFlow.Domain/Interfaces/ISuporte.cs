using SupportFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Domain.Interfaces
{
    public interface ISuporte
    {
        Task<List<Suporte>> TodosChamados();
        //Task<Suporte> BuscarporSetor(string setor);
        Task<Suporte> BuscarID(int id);
        Task<Suporte> Criar(Suporte suporte);
        Task<Suporte> Atualizar(Suporte suporte, int id);
        Task<bool> Deletar(int id);
    }
}
