using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProductos.AccesoDatos.Data;
using WebProductos.AccesoDatos.Repositorio.IRepositorio;

namespace WebProductos.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public ITipoProductoRepositorio TipoProducto { get; private set; }        
        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            TipoProducto = new TipoProductoRepositorio(_db);

        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
