using Domain.Models;
using Repository.Usuarios;
using System;
using System.Data.Entity;

namespace Repository.Common
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;

        private IUsuarioRepository usuarioRepository;


        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }

        public IUsuarioRepository UsuarioRepository
        {
            get
            {

                if (this.usuarioRepository == null)
                {
                    this.usuarioRepository = new UsuarioRepository(_dbContext);
                }
                return usuarioRepository;
            }
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    } 
}
