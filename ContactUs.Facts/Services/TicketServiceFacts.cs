using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ContactUs.Services;
using ContactUs.Models;
using System.Text.RegularExpressions;
using GFX.Core;

namespace ContactUs.Facts.Services
{
    public class TicketServiceFacts
    {
        public class Add
        {
            [Fact]
            public void NewTicket_HasCorrectId()
            {
                using (var app = new App(testing: true))
                {
                    var t = new Ticket();
                    t.Title = "Test Ticket";
                    t.Body = "Blah blah";

                    var ticket = app.Tickets.Add(t);
                    app.SaveChanges();

                    Assert.NotNull(ticket.Id);
                    Assert.True(ticket.Id.Length == 6);
                    Assert.True(Regex.IsMatch(ticket.Id, "[0-9a-f]{6}"));
                }
            }
            [Fact]
            public void NewTicket_LastActivityDateShouldBeCreatedDate()
            {
                using (var app = new App(testing: true))
                {
                    var t = new Ticket();
                    var dt = new DateTime(2015, 1, 1, 9, 0, 0);
                    SystemTime.SetDateTime(dt);

                    var ticket = app.Tickets.Add(t);
                    app.SaveChanges();

                    Assert.Equal(dt, ticket.LastActivityDate);
                }
            }
        }
    }
}
