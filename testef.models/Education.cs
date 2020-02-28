using System;
using System.Collections.Generic;
using System.Text;

namespace testef.models
{
    public class Education
    {
        public Guid EducationId { get; set; }
        public string EducationalInstitute { get; set; }
        public string Course { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Level { get; set; }
        public string Category { get; set; }
        public IList<PersonEducation> PersonEducations { get; set; }
    }
}
