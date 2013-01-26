using System;
using System.ComponentModel.DataAnnotations;
using WebApiBlog.Core.DataAccess;

namespace WebApiBlog.Models
{
    public class Contact : IModelId
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