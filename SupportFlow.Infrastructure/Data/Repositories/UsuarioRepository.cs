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
    public class UsuarioRepository : IUsuario
    {
        private readonly SupportFlowDbContext _dbcontext;
        public UsuarioRepository(SupportFlowDbContext supportFlowDbContext)
        {
            _dbcontext = supportFlowDbContext;
        }

        public async Task<List<Usuario>> TodosUsuarios()
        {
            //Fazer depois
            return await _dbcontext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> BuscarId(int id)
        {
            return await _dbcontext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Usuario> BuscarLogin(string Login)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Cadastrar(Usuario usuario)
        {
            await _dbcontext.Usuarios.AddAsync(usuario);
            await _dbcontext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Atualizar(Usuario usuario, int id)
        {
            Usuario usuarioId = await BuscarId(id);
            if(usuarioId == null)
            {
                throw new Exception($"Usuário {id} não foi encontrado no banco de dados");
            }

            usuarioId.Nome = usuario.Nome;
            usuarioId.Username = usuario.Username;
            usuarioId.Setor = usuario.Setor;
            usuarioId.Perfil = usuario.Perfil;

            _dbcontext.Usuarios.Update(usuarioId);
            await _dbcontext.SaveChangesAsync();

            return usuarioId;
        }

        public async Task<bool> Deletar(int id)
        {
            Usuario usuarioID = await BuscarId(id);

            if (usuarioID == null)
            {
                throw new Exception($"Usuário {id} não foi encontrado no banco de dados");
            }

            _dbcontext.Usuarios.Remove(usuarioID);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
