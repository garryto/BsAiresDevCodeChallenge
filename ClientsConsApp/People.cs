﻿using System;
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
        int rating;

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
            setRating();
        }
        

        public int Rating
        {
            get
            {
                return rating;
            }

        }

        public int Connections
        {
            get
            {
                return connections;
            }
        }


        public int Recomendations
        {
            get
            {
                return recomendations;
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

        private void setRating()
        {
            string[] roles = new string[] { "chief", "owner", "chair", "president", "manager", "director", "executive", "supervisor" };

            foreach (string rol in roles)
            {
                if (currentRole.Contains(rol))
                {
                    if (currentRole.Contains("chief executive officer"))
                    {
                        rating += 10;
                        break;
                    }

                    rating += 8;
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

                    if (currentRole.Contains("Argentina"))
                    {
                        rating += 6;
                        break;
                    }

                    rating += 5;
                    break;
                }

            }

            foreach (string countryElement in usaAndCanada)
            {
                if (country.Contains(countryElement))
                {

                    rating += 4;
                    break;
                }

            }

            foreach (string countryElement in european)
            {
                if (country.Contains(countryElement))
                {

                    rating += 3;
                    break;
                }

            }

            foreach (string countryElement in asian)
            {
                if (country.Contains(countryElement))
                {

                    rating -= 3;
                    break;
                }

            }

            foreach (string countryElement in african)
            {
                if (country.Contains(countryElement))
                {

                    rating -= 3;
                    break;
                }

            }

            string[] targetIndustries = new string[] { "Financial Services", "Telecomunications", "retail", "Supermarkets", "Banking" };

            foreach (string targetIndustry in targetIndustries)
            {
                if (industry.Contains(targetIndustry))
                {

                    rating += 5;
                    break;
                }

            }
        }
    }
    

    public class MyOrderingPeopleCriteria : IComparer<People>
    {
        public int Compare(People x, People y)
        {
            int compareRanking = x.Rating.CompareTo(y.Rating);
            if (compareRanking == 0)
            {
                    //If it is a draw I would like to give more importance to more influent people, therefore with more connections.
                    int compareConnections = x.Connections.CompareTo(y.Connections);
                    if (compareConnections==0)
                    {
                        //If it is still a draw I would like to give more importance trusted and reconigzed people, therefore with more recomendations.
                        return -1 * x.Recomendations.CompareTo(y.Recomendations);
                    }
                return -1* compareConnections;
            }
            return -1* compareRanking;
        }
    }
}
