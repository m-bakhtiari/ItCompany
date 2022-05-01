using System;

namespace ItCompany.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RecordDate { get; set; }
        public string Name { get; set; }
    }
}
