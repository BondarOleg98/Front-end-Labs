using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaratePortal.Models.PersonKarate
{
    public class KaratePerson
    {
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if ((value==string.Empty)||(value==null))
                    name = "Empty";
                else
                    name = value;
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if ((value==string.Empty)||(value==null))
                    lastName = "Empty";
                else
                    lastName = value;
            }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    age = 0;
                else
                    age = value;
            }
        }
        private string coutry;
        public string Country
        {
            get { return coutry; }
            set
            {
                if ((value==string.Empty)||(value==null))
                    coutry = "Empty";
                else
                    coutry = value;
            }
        }
        private string city;
        public string City
        {
            get { return city; }
            set
            {
                if ((value==string.Empty)||(value==null))
                    city = "Empty";
                else
                    city = value;
            }
        }
        private string belt;
        public string Belt
        {
            get { return belt; }
            set
            {
                if ((value == string.Empty) || (value == null))
                    belt = "Empty";
                else
                    belt = value;
            }
        }
        public int CountPeople(IEnumerable<object> currentPeople)
        {
            if (currentPeople == null)
                return 0;

            return currentPeople.Count();
        }
    }
}