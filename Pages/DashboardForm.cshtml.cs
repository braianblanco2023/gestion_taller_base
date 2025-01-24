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
        public int svcDistribución { get; set; }
        [BindProperty]
        public int svcMotor { get; set; }
        [BindProperty]
        public int svcInyección { get; set; }
        [BindProperty]
        public int svcFrenos { get; set; }
        [BindProperty]
        public int svcSuspensión { get; set; }
        [BindProperty]
        public int svcAlineaciónBalanceo { get; set; }
        [BindProperty]
        public int svcElectricidad { get; set; }
        [BindProperty]
        public int svcOtros { get; set; }

        [BindProperty]
        public int pDistribución { get; set; }
        [BindProperty]
        public int pMotor { get; set; }
        [BindProperty]
        public int pInyección { get; set; }
        [BindProperty]
        public int pFrenos { get; set; }
        [BindProperty]
        public int pSuspensión { get; set; }
        [BindProperty]
        public int pAlineaciónBalanceo { get; set; }
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
            svcDistribución = Registros.Where(r => r.tipoServicio == "Distribución").Count();
            svcMotor = Registros.Where(r => r.tipoServicio == "Motor").Count();
            svcInyección = Registros.Where(r => r.tipoServicio == "Inyección").Count();
            svcFrenos = Registros.Where(r => r.tipoServicio == "Frenos").Count();
            svcSuspensión = Registros.Where(r => r.tipoServicio == "Suspensión").Count();
            svcAlineaciónBalanceo = Registros.Where(r => r.tipoServicio == "Alineación y Balanceo").Count();
            svcElectricidad = Registros.Where(r => r.tipoServicio == "Electricidad").Count();
            svcOtros = Registros.Where(r => r.tipoServicio == "Otros").Count();
            */
            /*Calcula el total de registros para obtener el 100%
            sumaSvcs = Registros.Count();
            */
            /*Calcula los %
            pDistribución = (svcDistribución * 100) / sumaSvcs;
            pMotor = (svcMotor * 100) / sumaSvcs;
            pInyección = (svcInyección * 100) / sumaSvcs;
            pFrenos = (svcFrenos * 100) / sumaSvcs;
            pSuspensión = (svcSuspensión * 100) / sumaSvcs;
            pAlineaciónBalanceo = (svcAlineaciónBalanceo * 100) / sumaSvcs;
            pElectricidad = (svcElectricidad * 100) / sumaSvcs;
            pOtros = (svcOtros * 100) / sumaSvcs;
            */
        }
    }
}
