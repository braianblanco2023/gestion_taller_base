using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TallerAppRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace TallerAppRazor.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; } = "";
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        private readonly ILogger<IndexModel> _logger;
        /*
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        */
        [TempData]
        public string usuarioTaller { get; set; }

        [BindProperty]
        public Talleres Talleres { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPostLogin()
        {
            if (ValidaUser(Talleres.Id) == true && ValidaPassword(Talleres.Password) == true)
            {
                usuarioTaller = Talleres.Id;
                return RedirectToPage("./Menu");
            }
            else
            {
                Message = ">>> ID de Usuario o Contraseña inválida <<<";
                return Page();
            }
        }
        private bool ValidaUser(string user)
        {
            return _context.Talleres.Any(e => e.Id == user);
        }
        private bool ValidaPassword(string password)
        {
            return _context.Talleres.Any(e => e.Password == password);
        }
    }
}
