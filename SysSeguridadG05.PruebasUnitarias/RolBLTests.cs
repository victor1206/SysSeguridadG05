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
        private static Rol rolinicial = new Rol { Id = 24};//Rol existente 
        private RolBL rolBl = new RolBL();

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var rol = new Rol();
            rol.Nombre = "Admin 23";
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
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolinicial.Id;
            var result = await rolBl.ObtenerPorIdAsync(rol);
            Assert.AreEqual(rol.Id, result.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var result = await rolBl.ObtenerTodosAsync();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var rol = new Rol();
            rol.Nombre = "Ad";
            rol.Top_Aux = 10;
            var resultRoles = await rolBl.BuscarAsync(rol);
            Assert.AreNotEqual(0, resultRoles.Count);
        }

        [TestMethod()]
        public async Task T6DeleteAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolinicial.Id;
            var result = await rolBl.DeleteAsync(rol);
            Assert.AreNotEqual(0, result);
        }
    }
}