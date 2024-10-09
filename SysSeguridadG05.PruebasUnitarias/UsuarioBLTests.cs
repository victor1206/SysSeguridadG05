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
    public class UsuarioBLTests
    {
        private Usuario usuarioInicial = new Usuario { Id = 6, IdRol = 1, Login = "RGonzalez", Password = "123456"};
        private UsuarioBL usuarioBL = new UsuarioBL();
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            Usuario usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "Robertito";
            usuario.Apellido = "Gonzalez";
            usuario.Login = "RGonzalez";
            usuario.Password = "123456";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            int result = await usuarioBL.CrearAsync(usuario);
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            Usuario usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "Roberto";
            usuario.Apellido = "Gonsales";
            usuario.Login = "RGonzalez";
            usuario.Estatus = (byte)Estatus_Usuario.INACTIVO;
            var result = await usuarioBL.ModificarAsync(usuario);
            Assert.IsTrue(result == 1);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            Usuario usuario = new Usuario();
            usuario.Id = usuarioInicial.Id;
            var result = await usuarioBL.ObtenerPorIdAsync(usuario);
            Assert.IsTrue(result.Id == usuario.Id);
        }

        [TestMethod()]
        public async Task ObtenerTodosAsyncTest()
        {
            var result = await usuarioBL.ObtenerTodosAsync();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public async Task BuscarAsyncTest()
        {
            Usuario usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "a";
            usuario.Apellido = "a";
            usuario.Login = "a";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            usuario.Top_Aux = 10;
            var result = await usuarioBL.BuscarAsync(usuario);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod()]
        public async Task BuscarIncluirRolAsyncTest()
        {
            Usuario usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "i";
            usuario.Apellido = "a";
            usuario.Login = "ViDuran";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            usuario.Top_Aux = 10;
            var resultUsuarios = await usuarioBL.BuscarIncluirRolAsync(usuario);
            var ultimoUsuario = resultUsuarios.FirstOrDefault();
            Assert.IsTrue(ultimoUsuario.Rol != null && usuario.IdRol == ultimoUsuario.Rol.Id);
        }

        [TestMethod()]
        public async Task LoginAsyncTest()
        {
            Usuario usuario = new Usuario();
            usuario.Login = "ViDuran";
            usuario.Password = "1234567";
            var result = await usuarioBL.LoginAsync(usuario);
            Assert.AreEqual(usuario.Login, "ViDuran");
        }

        [TestMethod()]
        public void CambiarPasswordAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteAsyncTest()
        {
            Assert.Fail();
        }
    }
}