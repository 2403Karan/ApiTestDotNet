using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Office
    {
        public Guid OfficeId { get; set; }

        public string? Name { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? ZipCode { get; set; }

        public string? PhoneNumber { get; set; }

        public string? BillTo { get; set; }

        public string? PayToName { get; set; }

        public string? PayToAddress1 { get; set; }

        public string? PayToAddress2 { get; set; }

        public string? PayToCity { get; set; }

        public string? PayToState { get; set; }

        public string? PayToZipCode { get; set; }

        public string? PlaceOfServiceCode { get; set; }

        public bool IsDefault { get; set; } = false;
    }
}