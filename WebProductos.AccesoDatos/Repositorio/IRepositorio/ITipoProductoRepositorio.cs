using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProductos.Modelos;

namespace WebProductos.AccesoDatos.Repositorio.IRepositorio
{
    public interface ITipoProductoRepositorio : IRepositorio<TipoProducto>
    {
        void Actualizar(TipoProducto tipoproducto);
    }
}
