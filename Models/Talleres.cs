using System.ComponentModel.DataAnnotations;

namespace TallerAppRazor.Models
{
    public class Talleres
    {
        [Key]
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
