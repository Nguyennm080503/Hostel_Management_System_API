using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Mail;

namespace Service.Interface
{
    public interface IMailService
    {
        void SendMail(MailContent mailContent);
    }
}
