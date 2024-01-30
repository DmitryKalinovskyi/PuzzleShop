using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PuzzleShop.Models
{
    public class User: IdentityUser
    {
        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(50)]
        public string? Surname { get; set; }

        public string Address { get; set; }

        DateTime CreatedTime { get; set; }
    }
}
