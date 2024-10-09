using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
//************************
using Microsoft.EntityFrameworkCore;
using SysSeguridadG05.EN;

namespace SysSeguridadG05.DAL
{
    public class DBContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=DBSeguridadG05;Integrated Security=True"); 
            //optionsBuilder.UseSqlServer(@"workstation id = DbApiSysSeguridadG05.mssql.somee.com; packet size = 4096; user id = victorD2024_SQLLogin_1; pwd = rnt37f9ycm; data source = DbApiSysSeguridadG05.mssql.somee.com; persist security info = False; initial catalog = DbApiSysSeguridadG05; TrustServerCertificate = True");
        }
    }
}
