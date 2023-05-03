using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualisha.iCommunity.Data.Models.Dtos
{
    public class MailData
    {
        public string MailTo { get; set; }
        public string MailName { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }

        public MailData()
        {
            MailTo = string.Empty;
            MailName = string.Empty;
            MailSubject = string.Empty;
            MailBody = string.Empty;

        }


    }
}
