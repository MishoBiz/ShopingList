using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbShopingList.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Required]
        [StringLength(50)]
        public string Genre { get; set; }

        public int PublishedYear { get; set; }

        [Required]
        public string Status { get; set; } = "Available";

        public int? BorrowedById { get; set; }

        [ForeignKey(nameof(BorrowedById))]
        public User? BorrowedBy { get; set; }
    }
}
