using Bain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Bain.Controllers
{
    public class ProvidersController : ApiController
    { 
   
        //Get api/Providers
        public IEnumerable<Providers> Get()
        {
            List<Providers> returnList = new List<Providers>();
            String file_name = @"c:\users\bshah\documents\visual studio 2017\Projects\Bain\Bain\Content\Data.csv";
            StreamReader sr = new StreamReader(file_name);
            String line;
            sr.ReadLine();
            String data = string.Empty;
            while ((line = sr.ReadLine()) != null)
            {
                try
                {
                    String[] tokens = line.Split(',');
                    Providers c = new Providers();
                    c.DRGDefinition = tokens[0];
                    c.ProviderID = int.Parse(tokens[1]);
                    c.ProviderName = tokens[2];
                    c.ProviderStreetAddress = tokens[3];
                    c.providerCity = tokens[4];
                    c.providerState = tokens[5];
                    c.providerZipCode = tokens[6];
                    c.HospitalRefferal = tokens[7];
                    c.TotalDischarges = int.Parse(tokens[8]);
                    c.AverageCoveredCharges = tokens[9];
                    c.AverageTotalPayments = tokens[10];
                    c.AverageMedicarePayments = tokens[11];

                    string json = JsonConvert.SerializeObject(c);
                    Console.WriteLine(json); // single line JSON string

                    data = JValue.Parse(json).ToString(Formatting.Indented);

                    returnList.Add(c);
                    if (returnList.Count == 100)
                    {
                        break;
                    }
                }
                catch { }

            }
            sr.Close();

            return returnList;
        }
    
       //// /api/providers/GA
       // public IEnumerable<string> GetProductList(string state)
       // {
       //     string filename = @"c:\users\bshah\documents\visual studio 2017\Projects\Bain\Bain\Content\Data.csv";
       //     List<string> logs = (File.ReadAllLines(filename)
       //    .Where(line => !string.IsNullOrEmpty(line))
       //    .Select(line => line.Split(",;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
       //    .Where(values => values[5].Equals(state, StringComparison.CurrentCultureIgnoreCase))
       //    .Select(values => string.Join("_", values))
       //    .Distinct()
       //    .ToList<string>());

       //     return logs;

       // }

        public IEnumerable<string> GetProductList(string max_discharges, string min_discharges, string max_average_covered_charges, string min_average_covered_charges, string min_average_medicare_payments, string max_average_medicare_payments, string state)
        {
            var logs = (File.ReadAllLines(@"c:\users\bshah\documents\visual studio 2017\Projects\Bain\Bain\Content\Data.csv")
           .Where(line => !string.IsNullOrEmpty(line))
           .Select(line => line.Split(",;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
           .Where(values => values[5].Equals(state, StringComparison.CurrentCultureIgnoreCase))
           .Select(values => string.Join("_", values))
           .Distinct()
           .ToList<string>());
            
            return logs;
        }
    }
}
