using System;
using System.Collections.Generic;
using System.Text;

namespace testef.models
{
    public class PersonEducation
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }        
        public Guid EducationId { get; set; }
        public Education Education { get; set; }
    }
}
