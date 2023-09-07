using Demo.Utilities;
using System;
using System.Collections.Generic;

namespace Demo.PageObjects
{
    class ClientsRandomSelectionPage : TestBase
    {
        int index;

        public string ClientSelectionrandomly()
        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            var random = new Random();
            var list = new List<string> {"Check All",
                "Adobe Systems Incorporated",
                "Australian Institute of Professional Counselors",
                "College Board - Accuplacer",
                "Dynatrace",
                "EPIC Training",
                "Examity QA14 AUS",
                "Examity QA14 CAN",
                "Examity QA14 EU",
                "ExamityDemo",
                "QA Automation",
                "QA Automation",
                "QA Automation",
                "Questionmark - AppDynamics",
                "Training & Development",
                "Examity",
                "Fort Hays State University",
                "FRY-Glasgow",
                "Gardner Webb",
                "GMAC",
                "IUBH",
                "Loyalist",
                "LoyalistCTC",
                "LoyalistQualtrics",
                "LoyalistTableau",
                "National Consortium of Breast Centers",
                "NC State",
                "NMAT",
                "Penn College",
                "Partner Proctoring QA14 EU",
                "Rowan College",
                "SalesForce",
                "Speedwell Software Ltd",
                "Tennessee Board of Regents",
                "Tiger",
                "Tusculum University",
                "UNC Online",
                "University of Arizona",
                "University of California",
                "Riverside",
                "University of Mary",
                "University of Missouri",
                "West Chester University",
                "Western Governors University",
                "Wiley Education",
                "Wiley Georgetown"};
            index = random.Next(list.Count);
            if (expClient == "random")
            {
                return list[index];
            }
            else
            {
                return expClient;
            }
        }
    }
}
