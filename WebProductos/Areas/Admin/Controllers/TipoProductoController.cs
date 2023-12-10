using WebProductos.AccesoDatos.Repositorio.IRepositorio;
using WebProductos.Modelos;
using WebProductos.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Bosque.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TipoProductoController : Controller
    {

        private readonly IUnidadTrabajo _unidadTrabajo;

        public TipoProductoController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            TipoProducto tipoproducto = new TipoProducto();

            if (id == null)
            {
                // Crear un nuevo item              
                return View(tipoproducto);
            }
            // Actualizamos
            tipoproducto = await _unidadTrabajo.TipoProducto.Obtener(id.GetValueOrDefault());
            if (tipoproducto == null)
            {
                return NotFound();
            }
            return View(tipoproducto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(TipoProducto tipoproducto)
        {
            if (ModelState.IsValid)
            {
                if (tipoproducto.Id == 0)
                {
                    await _unidadTrabajo.TipoProducto.Agregar(tipoproducto);
                    TempData[DS.Exitosa] = "Tipo producto creado Exitosamente";
                    
                }
                else
                {
                    _unidadTrabajo.TipoProducto.Actualizar(tipoproducto);
                    TempData[DS.Exitosa] = "Tipo producto actualizado Exitosamente";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al grabar Tipo producto";
            return View(tipoproducto);
        }

        #region API

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.TipoProducto.ObtenerTodos();
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoproductoDb = await _unidadTrabajo.TipoProducto.Obtener(id);
            if (tipoproductoDb == null)
            {
                return Json(new { success = false, message = "Error al borrar Tipo Producto" });
            }
            _unidadTrabajo.TipoProducto.Remover(tipoproductoDb);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Tipo Producto borrado exitosamente" });
        }        

        #endregion

    }
}
