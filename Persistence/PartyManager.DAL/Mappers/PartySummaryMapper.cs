using PartyManager.Application.Shared.DataAccess.Models;
using PartyManager.DAL.Mappers.Extensions;
using System;
using System.Data;

namespace PartyManager.DAL.Mappers
{
    internal static class PartySummaryMapper
    {
        public static Func<IDataReader, PartySummary> Mapper =>
            reader => new PartySummary()
            {
                Party = PartyMapper.Mapper(reader),
                NumberOfGuests = reader["NumberOfGuests"].ToInt(),
                NumberOfVIPs = reader["NumberOfVIPs"].ToInt(),
                NumberOfDrinkChoicesOutstanding = reader["NumberOfDrinkChoicesOutstanding"].ToInt()
            };
    }
}