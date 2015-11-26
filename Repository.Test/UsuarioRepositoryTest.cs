using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Usuarios;
using System.Data.Common;

namespace Repository.Test
{
    [TestClass]
    public class UsuarioRepositoryTest
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
            var usuario = objRepo.BuscaPeloLogin("renan");

            Assert.AreEqual("123456", usuario.Senha);
            Assert.AreEqual("renan.augusto18@gmail.com", usuario.Email);
        }
    }
}
