using Microsoft.AspNetCore.Mvc;
using SysSeguridadG05.BL;
using SysSeguridadG05.EN;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SysSeguridadG05.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioBL usuarioBl = new UsuarioBL();
        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await usuarioBl.ObtenerTodosAsync();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<Usuario> Get(int id)
        {
            return await usuarioBl.ObtenerPorIdAsync(new Usuario { Id = id});
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] object pUsuario)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var strUsuario = JsonSerializer.Serialize(pUsuario);
                Usuario usuario = JsonSerializer.Deserialize<Usuario>(strUsuario,option);
                await usuarioBl.CrearAsync(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pUsuario)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string srtUsuario = JsonSerializer.Serialize(pUsuario);
                Usuario usuario = JsonSerializer.Deserialize<Usuario>(srtUsuario, option);
                if (usuario.Id == id)
                {
                    await usuarioBl.ModificarAsync(usuario);
                    return Ok(usuario);
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await usuarioBl.DeleteAsync(new Usuario { Id = id});
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Usuario>> Buscar([FromBody] object pUsuario)
        {
            try
            {
                var option = new JsonSerializerOptions 
                { 
                    PropertyNameCaseInsensitive = true
                };
                var strUsuario = JsonSerializer.Serialize(pUsuario);
                Usuario usuario = JsonSerializer.Deserialize<Usuario>(strUsuario,option);
                var usuarios = await usuarioBl.BuscarAsync(usuario);
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<Usuario> Login([FromBody] object pUsuario)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var strUsuario = JsonSerializer.Serialize(pUsuario);
                Usuario usuario = JsonSerializer.Deserialize<Usuario>(strUsuario, option);
                var usuario_auth = await usuarioBl.LoginAsync(usuario);
                if (usuario_auth != null && usuario_auth.Id > 0 && usuario_auth.Login == usuario.Login)
                { 
                    return usuario_auth;
                }
                else
                    return new Usuario();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost("CambiarPassword")]
        public async Task<ActionResult> CambiarPassword([FromBody] object pUsuario)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var strUsuario = JsonSerializer.Serialize(pUsuario);
                Usuario usuario = JsonSerializer.Deserialize<Usuario>(strUsuario, option);
                await usuarioBl.CambiarPasswordAsync(usuario, usuario.ConfirmPassword_aux);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
