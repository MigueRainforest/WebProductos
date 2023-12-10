using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProductos.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        ITipoProductoRepositorio TipoProducto { get; }       

        Task Guardar();
    }
}
