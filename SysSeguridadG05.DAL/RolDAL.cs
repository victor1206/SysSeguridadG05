using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*****************************
using Microsoft.EntityFrameworkCore;
using SysSeguridadG05.EN;

namespace SysSeguridadG05.DAL
{
    public class RolDAL
    {
        public static async Task<int> CrearAsync(Rol pRol)
        { 
            int result = 0;
            using (var dbContexto = new DBContexto())
            { 
                dbContexto.Add(pRol);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Rol pRol)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var rol = await dbContexto.Rol.FirstOrDefaultAsync(s => s.Id == pRol.Id);
                rol.Nombre = pRol.Nombre;
                dbContexto.Update(rol);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> DeleteAsync(Rol pRol)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var rol = await dbContexto.Rol.FirstOrDefaultAsync(x => x.Id == pRol.Id);
                //Borrar por medio de cambio de estado
                //rol.Top_Aux = 2;//Se coloca el campo de Estado que coloco en su clases
                //dbContexto.Update(rol);
                //result = await dbContexto.SaveChangesAsync();
                //fin de codigo para eliminar por cambio de estado
                dbContexto.Rol.Remove(rol);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Rol> ObtenerPorIdAsync(Rol pRol)
        { 
            Rol rol = new Rol();
            using (var dbContexto = new DBContexto())
            { 
                rol = await dbContexto.Rol.FirstOrDefaultAsync(s => s.Id == pRol.Id);
            }
            return rol;
        }

        public static async Task<List<Rol>> ObtenerTodosAsync()
        {
            List<Rol> roles = new List<Rol>();
            using (var dbContexto = new DBContexto())
            {
                roles = await dbContexto.Rol.ToListAsync();
            }
            return roles;
        }
        /*
         * 
         */
        internal static IQueryable<Rol> QuerySelect(IQueryable<Rol> pQuery, Rol pRol)
        {
            if (pRol.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pRol.Id);
            if (!string.IsNullOrWhiteSpace(pRol.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pRol.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if(pRol.Top_Aux > 0)
                pQuery = pQuery.Take(pRol.Top_Aux).AsQueryable();
            return pQuery;
        }
        /// <summary>
        /// Victor Duran
        /// 19/02/2024
        /// Este metodo se ocupa para hacer la busqueda de un rol 
        /// por medio de condociones 
        /// </summary>
        /// <param name="pRol">Parametro con los datos a buscar</param>
        /// <returns></returns>
        public static async Task<List<Rol>> BuscarAsync(Rol pRol)
        { 
            var roles = new List<Rol>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Rol.AsQueryable();
                select = QuerySelect(select, pRol);
                roles = await select.ToListAsync();
            }
            return roles;
        }
    }
}
