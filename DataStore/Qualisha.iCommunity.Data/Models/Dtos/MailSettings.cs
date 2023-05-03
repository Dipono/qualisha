﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.Data.Models.Dtos
{
    public class MailSettings
    {
        public string EmailId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }

        public MailSettings()
        {
            EmailId = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            Host = string.Empty;
        }


    }
}
