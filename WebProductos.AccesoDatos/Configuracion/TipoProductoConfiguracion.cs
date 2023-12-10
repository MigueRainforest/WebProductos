using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProductos.Modelos;

namespace WebProductos.AccesoDatos.Configuracion
{
    public class TipoProductoConfiguracion : IEntityTypeConfiguration<TipoProducto>
    {
        public void Configure(EntityTypeBuilder<TipoProducto> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Tipo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Detalles).IsRequired(false).HasMaxLength(100);
            
        }
    }
}
