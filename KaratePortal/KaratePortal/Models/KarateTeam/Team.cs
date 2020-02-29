using KaratePortal.Models.PersonKarate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaratePortal.Models.KarateTeam
{
    public class Team
    {
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if ((value == string.Empty) || (value == null))
                {
                    name = "Empty";
                }
                else
                {
                    name = value;
                }
            }
        }

        private string coach;
        public string Coach
        {
            get { return coach; }
            set
            {
                if ((value == string.Empty) || (value == null))
                {
                    coach = "Empty";
                }
                else
                {
                    coach = value;
                }
            }
        }
        private string organization;
        public string Organization
        {
            get { return organization; }
            set
            {
                if ((value == string.Empty) || (value == null))
                {
                    organization = "Empty";
                }
                else
                {
                    organization = value;
                }
            }
        }

        public ICollection<KarateStudent> KarateStudents { get; set; }
        public Team()
        {
            KarateStudents = new List<KarateStudent>();
        }
    }
}