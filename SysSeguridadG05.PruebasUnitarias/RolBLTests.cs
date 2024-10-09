using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysSeguridadG05.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SysSeguridadG05.EN;

namespace SysSeguridadG05.BL.Tests
{
    [TestClass()]
    public class RolBLTests
    {
        private static Rol rolinicial = new Rol { Id = 22};//Rol existente 
        private RolBL rolBl = new RolBL();

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var rol = new Rol();
            rol.Nombre = "Admin 3";
            int result = await rolBl.CrearAsync(rol);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolinicial.Id;
            rol.Nombre = "Admin33";
            int result = await rolBl.ModificarAsync(rol);
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public void DeleteAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObtenerPorIdAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObtenerTodosAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarAsyncTest()
        {
            Assert.Fail();
        }
    }
}