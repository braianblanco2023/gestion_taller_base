using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using TallerAppRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace TallerAppRazor.Pages
{

    public class MenuModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MenuModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<Registro> Registros { get; set; }

        public async Task OnGetAsync()
        {
            Registros = await _context.Registros.ToListAsync();
        }
    }
}