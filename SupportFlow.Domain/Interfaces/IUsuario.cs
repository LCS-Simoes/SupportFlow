using SupportFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Domain.Interfaces
{
    public interface IUsuario
    {
        Task<List<Usuario>> TodosUsuarios();
        Task<Usuario> BuscarId(int id);
        Task<Usuario> BuscarLogin(string Login);
        Task<Usuario> Cadastrar(Usuario usuario);
        Task<Usuario> Atualizar(Usuario usuario, int id);
        Task<bool> Deletar(int id);
    }
}
