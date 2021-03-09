using LogClient.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogClient.Infrastuncture.Core
{
    public static class EntityExtentions
    {
        public static long GenerateId( this IEntity<long> entity )
        {
            return Snowflake.GenerateId();
        }
        public static long SetId( this IEntity<long> entity )
        {
            entity.Id = Snowflake.GenerateId();
            return entity.Id;
        }
    }
}
