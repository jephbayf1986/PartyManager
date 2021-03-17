using System.Collections.Generic;

namespace PartyManager.DAL.Helpers
{
    internal class ParamBuilder
    {
        private Dictionary<string, object> parameters;

        public ParamBuilder()
        {
            parameters = new Dictionary<string, object>();
        }

        public ParamBuilder WithParam(string paramName, object value)
        {
            if (!paramName.StartsWith("@"))
            {
                paramName = "@" + paramName;
            }

            parameters.Add(paramName, value);

            return this;
        }

        public ParamBuilder WithId(object value)
        {
            return WithParam("Id", value);
        }

        public ParamBuilder WithPartyId(object value)
        {
            return WithParam("PartyId", value);
        }

        public ParamBuilder WithPersonId(object value)
        {
            return WithParam("PersonId", value);
        }

        public ParamBuilder WithPartyGuestId(object value)
        {
            return WithParam("PartyGuestId", value);
        }

        public ParamBuilder WithDrinkId(object value)
        {
            return WithParam("DrinkId", value);
        }

        public static Dictionary<string, object> None
            => new Dictionary<string, object>();

        public static implicit operator Dictionary<string, object>(ParamBuilder paramBuilder)
        {
            return paramBuilder.parameters;
        }
    }
}