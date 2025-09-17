using System;

namespace BirthCertificateRegistrationSystem.Models
{
    public class Application
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BirthCertificateId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
    }
}