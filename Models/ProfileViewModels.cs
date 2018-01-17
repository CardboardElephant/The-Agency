using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheAgency.Models
{
    public class ProfileViewModels
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CompanyName { get; set; }
        public string Image { get; set; }
        public string Address_Line_01 { get; set; }
        public string Address_Line_02 { get; set; }
        public string TownCity { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Headline { get; set; }
        public string Content { get; set; }
        public byte[] PrimaryImage { get; set; }
        public string ContentType { get; set; }
        public int FileType { get; set; }
        public int Professionalism { get; set; }
        public int ValueForMoney { get; set; }
        public int Enjoyment { get; set; }
        public int Attire { get; set; }
        public string Comments { get; set; }
    }
}