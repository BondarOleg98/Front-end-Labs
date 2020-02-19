using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaratePortal.Models.PersonKarate
{
    public class Coach : KaratePerson
    {
        

        public virtual ICollection<KarateStudent> KarateStudents { get; set; }

    }
}