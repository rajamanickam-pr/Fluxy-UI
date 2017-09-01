﻿using System.ComponentModel.DataAnnotations;

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
        public string About { get; set; }
        public string Hobbies { get; set; }
        public bool CanAnyoneSendMessage { get; set; }
        public bool CanAnyoneSendVideo { get; set; }
        public bool IsMyDpPublic { get; set; }
    }
}