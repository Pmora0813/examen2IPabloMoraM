namespace examen2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("compraCine")]
    public partial class compraCine
    {
        [Key]
        public int idCompra { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date, ErrorMessage = "Debe ser tipo Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }

        [Display(Name = "Ticket")]
        public int idTicket { get; set; }

        [Display(Name = "Cantidad de Tickets Niños")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Solo números sin decimales")]
        public int cantidadNinos { get; set; }

        [Display(Name = "Cantidad de Tickets Regular")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Solo números sin decimales")]
        public int cantidadRegular { get; set; }

        [Display(Name = "Descuento")]
        [DisplayFormat(DataFormatString = "{0}", ApplyFormatInEditMode = true)]
        public decimal descuento { get; set; }

        [Display(Name = "Cargo Servicio")]
        [DisplayFormat(DataFormatString = "{0}", ApplyFormatInEditMode = true)]
        public decimal cargoServicio { get; set; }

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0}", ApplyFormatInEditMode = true)]
        public decimal total { get; set; }

        [Display(Name = "Ticket")]
        public virtual ticket ticket { get; set; }
    }
}
