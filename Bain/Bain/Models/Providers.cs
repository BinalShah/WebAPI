using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bain.Models
{
  
    public class Providers
    {
        public string DRGDefinition { get; set; }
        public int ProviderID { get; set; }

        [Display(Name = "Provider Name")]
        public string ProviderName { get; set; }

        [Display(Name = "Provider Street Address")]
        public string ProviderStreetAddress { get; set; }

        [Display(Name = "Provider City")]
        public string providerCity { get; set; }

        [Display(Name = "Provider State")]
        public string providerState { get; set; }

        [Display(Name = "Provider Zip Code")]
        public string providerZipCode { get; set; }

        [Display(Name = "Hospital Referral Region Description")]
        public string HospitalRefferal { get; set; }

        [Display(Name = "Total Discharges")]
        public int TotalDischarges { get; set; }

         [Display(Name = "Average Covered Charges")]
        public string AverageCoveredCharges { get; set; }

        [Display(Name = "Average Total Payments")]
        public string AverageTotalPayments { get; set; }

        [Display(Name = "Average Medicare Payments")]
        public string AverageMedicarePayments { get; set; }


    }
}