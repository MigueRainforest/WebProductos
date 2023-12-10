using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProductos.AccesoDatos.Data;
using WebProductos.AccesoDatos.Repositorio.IRepositorio;
using WebProductos.Modelos;

namespace WebProductos.AccesoDatos.Repositorio
{
    public class TipoProductoRepositorio : Repositorio<TipoProducto>, ITipoProductoRepositorio  //"Repositorio es genérico, así que le podemos pasar cualquier objeto"
    {
        private readonly ApplicationDbContext _db;

        public TipoProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(TipoProducto tipoproducto)
        {
            var tipoproductoBD = _db.TipoProductos.FirstOrDefault(b => b.Id == tipoproducto.Id);
            if (tipoproductoBD != null)
            {
                tipoproductoBD.Tipo = tipoproducto.Tipo;
                tipoproductoBD.Descripcion = tipoproducto.Descripcion;
                tipoproductoBD.Detalles = tipoproducto.Detalles;                
                _db.SaveChanges();
            }
        }
    }
}
