using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TallerAppRazor.Models
{
    public class Registro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Taller { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Combustible { get; set; }
        public int Kilometraje { get; set; }
        public string Titular_Duenio { get; set; }
        public string condicionIngreso { get; set; }
        public string servicioRealizado { get; set; }
        public string tipoServicio { get; set; }
        public int costoServicio { get; set; }
        public int costoRepuestos { get; set; }
        public int costoTotal { get; set; }
        public DateTime fecha { get; set; }
    }
}
