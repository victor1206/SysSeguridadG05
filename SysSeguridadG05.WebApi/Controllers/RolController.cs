using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysSeguridadG05.BL;
using SysSeguridadG05.EN;
using System.Text.Json;

namespace SysSeguridadG05.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private RolBL rolBl = new RolBL();

        [HttpGet]
        public async Task<IEnumerable<Rol>> Get()
        {
            return await rolBl.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Rol> Get(int id)
        {
            Rol rol = new Rol();
            rol.Id = id;
            return await rolBl.ObtenerPorIdAsync(rol);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] object pRol)
        {
            try
            {
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                string strRol = JsonSerializer.Serialize(pRol);
                Rol rol = JsonSerializer.Deserialize<Rol>(strRol, option);
                await rolBl.CrearAsync(rol);
                return Ok();
            }
            catch (Exception Ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pRol)
        {
            try
            {
                var option = new JsonSerializerOptions
                { 
                    PropertyNameCaseInsensitive = true
                };
                string strRol = JsonSerializer.Serialize(pRol);
                Rol rol = JsonSerializer.Deserialize<Rol>(strRol, option);
                if (rol.Id == id)
                {
                    await rolBl.ModificarAsync(rol);
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await rolBl.DeleteAsync(new Rol { Id = id});
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Rol>> Buscar([FromBody] object pRol)
        {
            try
            {
                var option = new JsonSerializerOptions
                { 
                    PropertyNameCaseInsensitive = true
                };
                var strRol = JsonSerializer.Serialize(pRol);
                Rol rol = JsonSerializer.Deserialize<Rol>(strRol, option);
                return await rolBl.BuscarAsync(rol);
            }
            catch (Exception ex)
            {
                return new List<Rol>();
            }
        }

    }
}
