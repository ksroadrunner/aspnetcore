using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Domain
{
    public class User : BaseEntity
    {
        public string  Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}