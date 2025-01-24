using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol.Plugins;
using TallerAppRazor.Models;

namespace TallerAppRazor.Pages
{
    public class AtencionFormModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AtencionFormModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public string Taller { get; set; }
        public string patenteBuscada { get; set; }
        [BindProperty]
        public string condicionIngreso { get; set; }
        [BindProperty]
        public string servicioRealizado { get; set; }
        [BindProperty]
        public string tipoServicio { get; set; }
        [BindProperty]
        public int costoServicio { get; set; }
        [BindProperty]
        public int costoRepuestos { get; set; }
        [BindProperty]
        public int costoTotal { get; set; }
        public string Message { get; set; } = "";
        [BindProperty]
        public Registro Registro { get; set; }
        public IList<Registro> Registros { get; set; }
        public void OnGet()
        {
            Taller = TempData.Peek("usuarioTaller") as string;
            patenteBuscada = TempData.Peek("Patente") as string;
            //if reg 'patente' not exist 
            Registro = new Registro();
            try { Registros = _context.Registros.ToList(); }
            catch (NullReferenceException)
            {
                Message = "No se encontraron Registros aùn";
            }
            
            if (RegistroExists(patenteBuscada, Taller) == false)
            {

            }
            else if (RegistroExists(patenteBuscada, Taller) == true)
            {
                //Trae el registro buscado con su ultimo version al formulario 
                Registro.Marca = _context.Registros.Where(r => r.Patente == patenteBuscada && r.Taller == Taller).Max(r => r.Marca);
                Registro.Modelo = _context.Registros.Where(r => r.Patente == patenteBuscada && r.Taller == Taller).Max(r => r.Modelo);
                Registro.Anio = _context.Registros.Where(r => r.Patente == patenteBuscada && r.Taller == Taller).Max(r => r.Anio);
                Registro.Combustible = _context.Registros.Where(r => r.Patente == patenteBuscada && r.Taller == Taller).Max(r => r.Combustible);
                Registro.Titular_Duenio = _context.Registros.Where(r => r.Patente == patenteBuscada).Max(r => r.Titular_Duenio);
                //Modifica el kilotraje al ultimo o mayor
                Registro.Kilometraje = _context.Registros.Where(r => r.Patente == patenteBuscada).Max(r => r.Kilometraje);
                //Trae todos los registros para esa patente para el historial al pie
                Registros = _context.Registros.Where(m => m.Patente == patenteBuscada && m.Taller == Taller).ToList();
                //Registros = _context.Registros.ToList();
            }
        }
        public IActionResult OnPostCompleto()
        {
            // Obtener los valores de TempData
            Registro.Taller = TempData.Peek("usuarioTaller") as string;
            Registro.Patente = TempData.Peek("Patente") as string;
            // Asignar los valores a las propiedades de Registro
            Registro.fecha = DateTime.Now.Date;
            Registro.condicionIngreso = condicionIngreso;
            Registro.servicioRealizado = servicioRealizado;
          //Registro.tipoServicio = tipoServicio;
            Registro.costoServicio = costoServicio;
            Registro.costoRepuestos = costoRepuestos;
            Registro.costoTotal = costoTotal;
            _context.Registros.Add(Registro);
            _context.SaveChanges();
            //TempData.Remove("Patente");
            return RedirectToPage("/RegistroForm");
        }
        private bool RegistroExists(string patente, string taller)
        {
            bool validaPatente = _context.Registros.Any(e => e.Patente == patente && e.Taller == taller);
            return validaPatente;
        }
    }
}
