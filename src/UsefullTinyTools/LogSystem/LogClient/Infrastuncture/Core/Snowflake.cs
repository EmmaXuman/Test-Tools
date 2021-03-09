using System;
using System.Collections.Generic;
using System.Text;

namespace LogClient.Infrastuncture.Core
{
   public static  class Snowflake
    {
        public static long GenerateId( bool useGRpc = true )
        {
            var instance = SnowflakeGenerator.Instance;
            return instance.GenerateId();
        }

    }
}
