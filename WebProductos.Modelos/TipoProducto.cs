using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProductos.Modelos
{
    public class TipoProducto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Tipo de producto es requerido")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Tipo { get; set; }              

        [Required(ErrorMessage = "La Descripcion es requerida")]
        [MaxLength(100, ErrorMessage = "La Descripcion ser máximo 100 caracteres")]
        public string Descripcion { get; set; }

        //[Required(ErrorMessage = "Detalles es requerido")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Detalles { get; set; }
    }
}
