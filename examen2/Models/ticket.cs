namespace examen2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ticket")]
    public partial class ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ticket()
        {
            compraCine = new HashSet<compraCine>();
        }

        [Key]
        public int idTicket { get; set; }
        
        [StringLength(150)]
        public string nombrePelicula { get; set; }

        [Column(TypeName = "text")]      
        public string detalle { get; set; }

        public decimal precioNino { get; set; }

        public decimal precioRegular { get; set; }

        public int cantidaTicketsdDescuento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compraCine> compraCine { get; set; }
    }
}
