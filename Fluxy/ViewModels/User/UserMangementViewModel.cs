using Fluxy.Data;
using Fluxy.ViewModels.Video;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fluxy.ViewModels.User
{
    public class UserMangementViewModel
    {
        [Key]
        public string Id { get; set; }
        public byte[] DisplayPicture { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }  
        public int Age { get; set; }
        public string About { get; set; }
        public string Hobbies { get; set; }
        public bool CanAnyoneSendMessage { get; set; }
        public bool CanAnyoneSendVideo { get; set; }
        public bool IsMyDpPublic { get; set; }
        public string DisplayPictureString
        {
            get
            {
                return Convert.ToBase64String(this.DisplayPicture);
            }
        }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public int TotalVideo { get; set; }
    }
}