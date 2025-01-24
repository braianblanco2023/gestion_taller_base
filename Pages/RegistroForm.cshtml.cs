using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TallerAppRazor.Models;

namespace TallerAppRazor.Pages
{
    public class RegistroFormModel : PageModel
    {
        [TempData]
        public string Patente { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(string campoPatente)
        {
            Patente = campoPatente;
            return RedirectToPage("AtencionForm");
        }
    }
}
