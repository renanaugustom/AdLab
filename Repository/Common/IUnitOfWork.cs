using Domain.Models;
using Repository.Usuarios;
using System;

namespace Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository UsuarioRepository { get; }
        int Commit();
    }
}