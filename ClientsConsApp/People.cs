using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsConsApp
{
    public class People
    {
        int personId;
        string name;
        string lastName;
        string currentRole;
        string country;
        string industry;
        int recomendations;
        int connections;
        int ranking;

        public People(string line)
        {
            string[] data = line.Split('|');
            personId = int.Parse(data[0]);
            name = data[1];
            lastName = data[2];
            currentRole = data[3];
            country = data[4];
            industry = data[5];
            recomendations = data[6] == "" ? 0 : int.Parse(data[6]);
            connections = data[7] == "" ? 0 : int.Parse(data[7]);
            setRanking();
        }

        private void setRanking()
        {
            string[] roles = new string[] { "chief", "owner", "chair","president","manager", "director", "executive", "supervisor" };
           
            foreach (string rol in roles)
            {
                if (currentRole.Contains(rol))
                {
                    if (currentRole.Contains("chief executive officer"))
                    {
                        ranking += 15;
                        break;
                    }

                    ranking += 10;
                    break;
                } 
                
            }

            string[] latamCountries = new string[] { "Costa Rica", "Mexico", "Argentina", "Chile", "Brazil", "Colombia", "Peru", "Puerto Rico", "Ecuador", "Panama" };
            string[] usaAndCanada = new string[] { "United States", "Canada" };
            string[] european = new string[] { "Spain", "Germany", "Italy", "France", "Sweden", "Portugal", "Greece", "Netherland", "Switzerland", "Finland", "Denmark", "Ireland" };
            string[] eastern = new string[] { "Turkey", "Singapore", "Malta", "Czech Republic", "Cyprus", "Croatia", "Russian Federation" };
            string[] asian = new string[] { "China", "India", "Japon", "korea", "Maylasia" };
            string[] african = new string[] { "South Africa", "kuwait" };


            foreach (string countryElement in latamCountries)
            {
                if (country.Contains(countryElement))
                {
                   
                    ranking += 5;
                    break;
                }

            }

            foreach (string countryElement in usaAndCanada)
            {
                if (country.Contains(countryElement))
                {

                    ranking += 4;
                    break;
                }

            }

            foreach (string countryElement in european)
            {
                if (country.Contains(countryElement))
                {

                    ranking += 3;
                    break;
                }

            }

            string[] targetIndustries = new string[] { "Financial Services", "Telecomunications", "retail", "Supermarkets" };

            foreach (string targetIndustry in targetIndustries)
            {
                if (industry.Contains(targetIndustry))
                {

                    ranking += 5;
                    break;
                }

            }
        }

        public int Ranking
        {
            get
            {
                return ranking;
            }

        }

        public int Connections
        {
            get
            {
                return connections;
            }
        }
        public int Id
        {
            get
            {
                return personId;
            }
        }

        public string CurrentRole
        {
            get
            {
                return currentRole;
            }
        }

        public string Industry {
            get
            {
                return industry;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
        }
    }
    

    public class MyOrderingPeopleCriteria : IComparer<People>
    {
        public int Compare(People x, People y)
        {
            int compareRanking = x.Ranking.CompareTo(y.Ranking);
            if (compareRanking == 0)
            {
                    //If it is a draw I would like to give more importance to more influent people, therefore with more connections.
                    return -1*x.Connections.CompareTo(y.Connections);
            }
            return -1* compareRanking;
        }
    }
}
