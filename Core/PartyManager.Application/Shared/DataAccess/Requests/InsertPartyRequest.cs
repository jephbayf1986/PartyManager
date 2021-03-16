using System;

namespace PartyManager.Application.Shared.DataAccess.Requests
{
    public class InsertPartyRequest
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime? StartTime { get; set; }
    }
}