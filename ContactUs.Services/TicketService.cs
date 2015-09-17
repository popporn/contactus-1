using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GFX.Core;
using ContactUs.Models;

namespace ContactUs.Services
{
    public class TicketService : ServiceBase<App, Ticket>
    {

        public override IRepository<Ticket> Repository
        {
            get;
            set;
        }

        public override Ticket Find(params object[] keys)
        {
            string id = (string)keys[0];
            return Query(t => t.Id == id).SingleOrDefault();
        }

        public override Ticket Add(Ticket item)
        {
            item.Id = generateTicketId();
            item.LastActivityDate = SystemTime.Now();
            return base.Add(item);
        }

        private string generateTicketId()
        {
            var r = new Random();
            var chars = "0123456789abcdef";
            var sb = new StringBuilder(6);

            for(int i=0;i<6;i++)
            {
                sb.Append(chars[r.Next(chars.Length)]);
            }
            return sb.ToString();
        }
    }
}
