﻿using System.Configuration;

namespace Fluxy.Core.Constants
{
    public static class Configurations
    {
        public static string FacebookUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["facebookUrl"].ToString();
            }
        }

        public static string YoutubeUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["youtubeUrl"].ToString();
            }
        }

        public static string TwitterUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["twitterUrl"].ToString();
            }
        }
    }
}