using KaratePortal.Models.KarateTeam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaratePortal.Models.PersonKarate
{
    public class KarateStudent : KaratePerson
    {
        private int yearsTraining;
        public int YearsTraining
        {
            get { return yearsTraining; }
            set
            {
                if (value < 0)
                {
                    yearsTraining = 0;
                }
                else
                {
                    yearsTraining = value;
                }
            }
        }
        private int countCoach;
        public int CountCoach
        {
            get { return countCoach; }
            set
            {
                if (value < 0)
                {
                    countCoach = 0;
                }
                else
                {
                    countCoach = value;
                }
            }
        }
        private string sportsmanStatus;
        public string SportsmanStatus
        {
            get { return sportsmanStatus; }
            set
            {
                if ((value==string.Empty)||(value==null))
                {
                    sportsmanStatus = "Empty";
                }
                else
                {
                    sportsmanStatus = value;
                }
            }
        }
        private string likeCompetition;
        public string LikeCompetition
        {
            get { return likeCompetition; }
            set
            {
                if ((value==string.Empty)||(value==null))
                {
                    likeCompetition = "Empty";
                }
                else
                {
                    likeCompetition = value;
                }
            }
        }
        public virtual ICollection<Coach>Coaches { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }
        public KarateStudent()
        {
            Coaches = new List<Coach>();
    
        }
        public int CountPeople(int[] selectedCoaches)
        {
            if (selectedCoaches == null)
            {
                return 0;
            }
            return selectedCoaches.Count();
        }
      

    }
}