using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobilBor.Models
{
    public class Info
    {   
        [Required]
        public string title { get; set; }
        [Required]
        public int? brand { get; set; }
        [Required]
        public int? pricetype { get; set; }
        public int? price { get; set; }
        public int? moneytype { get; set; }
        public int? contact { get; set; }
        [Required]
        public int? state { get; set; }
        [Required]
        public int? face { get; set; }
        [Required]
        public string text { get; set; }
        public string picture1 { get; set; }
        public string picture2 { get; set; }
        public string picture3 { get; set; }
        public string picture4 { get; set; }
        public string picture5 { get; set; }
        public string picture6 { get; set; }
        public DateTime datetime { get; set; }
        public int? statusid { get; set; }
        public int? contactid { get; set; }
        public string fullname { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}