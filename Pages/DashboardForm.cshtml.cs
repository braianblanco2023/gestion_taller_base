using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol.Plugins;
using TallerAppRazor.Models;

namespace TallerAppRazor.Pages
{
    public class DashboardFormModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DashboardFormModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public string Taller { get; set; }
        public IList<Registro> Registros { get; set; }
        /*
        public Registro Registro { get; set; }
        [BindProperty]
        public int svcDistribuci�n { get; set; }
        [BindProperty]
        public int svcMotor { get; set; }
        [BindProperty]
        public int svcInyecci�n { get; set; }
        [BindProperty]
        public int svcFrenos { get; set; }
        [BindProperty]
        public int svcSuspensi�n { get; set; }
        [BindProperty]
        public int svcAlineaci�nBalanceo { get; set; }
        [BindProperty]
        public int svcElectricidad { get; set; }
        [BindProperty]
        public int svcOtros { get; set; }

        [BindProperty]
        public int pDistribuci�n { get; set; }
        [BindProperty]
        public int pMotor { get; set; }
        [BindProperty]
        public int pInyecci�n { get; set; }
        [BindProperty]
        public int pFrenos { get; set; }
        [BindProperty]
        public int pSuspensi�n { get; set; }
        [BindProperty]
        public int pAlineaci�nBalanceo { get; set; }
        [BindProperty]
        public int pElectricidad { get; set; }
        [BindProperty]
        public int pOtros { get; set; }

        [BindProperty]
        public int sumaSvcs { get; set; }
        */
        public void OnGet()
        {
            Taller = TempData.Peek("usuarioTaller") as string;
            Registros = _context.Registros.Where(r => r.Taller == Taller).ToList();
            int costoServicio = _context.Registros.Where(r => r.Taller == Taller).Sum(r => r.costoServicio);
            int costoTotal = _context.Registros.Where(r => r.Taller == Taller).Sum(r => r.costoTotal);
            //Obtener Datos del Cuadro para Piechart
            /*
            //Calcula las cantidades
            svcDistribuci�n = Registros.Where(r => r.tipoServicio == "Distribuci�n").Count();
            svcMotor = Registros.Where(r => r.tipoServicio == "Motor").Count();
            svcInyecci�n = Registros.Where(r => r.tipoServicio == "Inyecci�n").Count();
            svcFrenos = Registros.Where(r => r.tipoServicio == "Frenos").Count();
            svcSuspensi�n = Registros.Where(r => r.tipoServicio == "Suspensi�n").Count();
            svcAlineaci�nBalanceo = Registros.Where(r => r.tipoServicio == "Alineaci�n y Balanceo").Count();
            svcElectricidad = Registros.Where(r => r.tipoServicio == "Electricidad").Count();
            svcOtros = Registros.Where(r => r.tipoServicio == "Otros").Count();
            */
            /*Calcula el total de registros para obtener el 100%
            sumaSvcs = Registros.Count();
            */
            /*Calcula los %
            pDistribuci�n = (svcDistribuci�n * 100) / sumaSvcs;
            pMotor = (svcMotor * 100) / sumaSvcs;
            pInyecci�n = (svcInyecci�n * 100) / sumaSvcs;
            pFrenos = (svcFrenos * 100) / sumaSvcs;
            pSuspensi�n = (svcSuspensi�n * 100) / sumaSvcs;
            pAlineaci�nBalanceo = (svcAlineaci�nBalanceo * 100) / sumaSvcs;
            pElectricidad = (svcElectricidad * 100) / sumaSvcs;
            pOtros = (svcOtros * 100) / sumaSvcs;
            */
        }
    }
}
