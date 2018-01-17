using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TheAgency.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Headline", Prompt = "Headline")]
        [DataType(DataType.Text)]
        [StringLength(255)]
        public string Headline { get; set; }

        [Display(Name = "Content", Prompt = "Content")]
        [DataType(DataType.Text)]
        [StringLength(2500)]
        public string Content { get; set; }

        [Display(Name = "Click to add Primary Image", Prompt = "Primary Image")]
        [DataType(DataType.Text)]
        public byte[] PrimaryImage { get; set; }

        [Display(Name = "Click to add Image 01", Prompt = "Image 01")]
        [DataType(DataType.Text)]
        public byte[] Image_01 { get; set; }

        [Display(Name = "Click to add Image 02", Prompt = "Image 02")]
        [DataType(DataType.Text)]
        public byte[] Image_02 { get; set; }

        [Display(Name = "Click to add Image 03", Prompt = "Image 03")]
        [DataType(DataType.Text)]
        public byte[] Image_03 { get; set; }

        [Display(Name = "Click to add Image 04", Prompt = "Image 04")]
        [DataType(DataType.Text)]
        public byte[] Image_04 { get; set; }

        [Display(Name = "Click to add Image 05", Prompt = "Image 05")]
        [DataType(DataType.Text)]
        public byte[] Image_05 { get; set; }

        [Display(Name = "Click to add Image 06", Prompt = "Image 06")]
        [DataType(DataType.Text)]
        public byte[] Image_06 { get; set; }

        [Display(Name = "Click to add Image 07", Prompt = "Image 07")]
        [DataType(DataType.Text)]
        public byte[] Image_07 { get; set; }

        [Display(Name = "Click to add Image 08", Prompt = "Image 08")]
        [DataType(DataType.Text)]
        public byte[] Image_08 { get; set; }

        [Display(Name = "Click to add Image 09", Prompt = "Image 09")]
        [DataType(DataType.Text)]
        public byte[] Image_09 { get; set; }

        public string UserId { get; set; }
    }
}