using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbShopingList.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; } = "User";

        public ICollection<Book> BorrowedBooks { get; set; }
    }
}
