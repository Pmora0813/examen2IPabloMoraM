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
        [Display(Name = "Película")]
        [Required]
        [StringLength(150)]
        public string nombrePelicula { get; set; }

        [Display(Name = "Detalle")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "text")]
        [Required]
        public string detalle { get; set; }

        [Display(Name = "Precio Niño")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Solo números sin decimales")]
        [DisplayFormat(DataFormatString  = "{0}", ApplyFormatInEditMode = true)]
        [Required]
        public decimal precioNino { get; set; }

        [Display(Name = " Precio Regular")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Solo números sin decimales")]
        [Required]
        [DisplayFormat(DataFormatString = "{0}", ApplyFormatInEditMode = true)]
        public decimal precioRegular { get; set; }

        [Display(Name = "Cantidad de Tickets para descuento ")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Solo números sin decimales")]
        [Required]
        [DisplayFormat(DataFormatString = "{0}", ApplyFormatInEditMode = true)]
        public int cantidaTicketsdDescuento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compraCine> compraCine { get; set; }
    }
}
