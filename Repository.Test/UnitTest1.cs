using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using Moq;
using Repository.Usuarios;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Domain;
using System.Data.Common;

namespace Repository.Test
{
    [TestClass]
    public class UnitTest1
    {
        DbConnection connection;
        MockAppContext databaseContext;
        UsuarioRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            connection = Effort.DbConnectionFactory.CreateTransient();
            databaseContext = new MockAppContext(connection);
            objRepo = new UsuarioRepository(databaseContext);

        }

        [TestMethod]
        public void BuscaPeloLogin_Test()
        {
            // Try finding a product by id
            var usuario = objRepo.BuscaPeloLogin("renan");

            Assert.AreEqual("123456", usuario.Senha);
            Assert.AreEqual("renan.augusto18@gmail.com", usuario.Email);

        }
    }
}
