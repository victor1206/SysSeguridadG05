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
    }
}
