using System;

namespace PartyManager.Application.Shared.DataAccess.Requests
{
    public class UpdatePartyRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime? StartTime { get; set; }
    }
}