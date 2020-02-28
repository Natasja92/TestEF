using System;
using System.Collections.Generic;
using System.Text;

namespace testef.models
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public int CitizenServiceNumber { get; set; }
        public string Email { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public IList<PersonEducation> PersonEducations { get; set; }
    }
}
