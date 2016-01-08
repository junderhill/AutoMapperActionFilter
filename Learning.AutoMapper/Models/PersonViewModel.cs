using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Learning.AutoMapper.Models
{
    public class PersonViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        [Compare("Email")]
        [Required]
        public string ConfirmEmail { get; set; }
    }
}