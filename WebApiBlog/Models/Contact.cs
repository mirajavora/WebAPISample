using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiBlog.Models
{
    public class Contact
    {
        public Contact()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}