using System;

namespace BirthCertificateRegistrationSystem.Models
{
    public class BirthCertificate
    {
        public int Id { get; set; }
        public string CertificateNumber { get; set; }
        public string ChildName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime DateIssued { get; set; }
        public int RegisteredByUserId { get; set; }
    }

}