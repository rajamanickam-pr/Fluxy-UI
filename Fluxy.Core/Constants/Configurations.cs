using System.Configuration;

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

        public static string DomainName
        {
            get
            {
                return ConfigurationManager.AppSettings["domainName"].ToString();
            }
        }

        public static string Version
        {
            get
            {
                return ConfigurationManager.AppSettings["version"].ToString();
            }
        }

        public static string PinterestUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["pinterestUrl"].ToString();
            }
        }
    }
}
