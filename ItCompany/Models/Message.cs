using System;
using System.ComponentModel.DataAnnotations;

namespace ItCompany.Models
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Subject { get; set; }

        public string Text { get; set; }

        public DateTime RecordDate { get; set; }
    }
}
