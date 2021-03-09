using System;
using System.Collections.Generic;
using System.Text;

namespace LogClient.Infrastuncture.Core
{
    public class SnowflakeGenerator
    {
        private static SnowflakeGenerator _generator;
        private static readonly object _idLock;
        private static readonly object GeneratorLock = new object();

        private const long TwEpoch = 1543765593681L; //2018-12-2 15:47:06 +00:00

        private const int SequenceBits = 12;
        private const int WorkerIdBits = 5;
        private const int DatacenterIdBits = 5;
        private const int WorkerIdShift = SequenceBits;
        private const int DatacenterIdShift = SequenceBits + WorkerIdBits;
        private const int TimestampLeftShift = SequenceBits + WorkerIdBits + DatacenterIdBits;
        private long _lastTimestamp = -1L;
        /// <summary>
        /// 初始序列
        /// </summary>
        private long _sequence = 0L;
        public long WorkerId { get; set; } = 1;
        public long DatacenterId { get; set; } = 1;

        private const long SequenceMask = -1L ^ (-1L << SequenceBits);


        private SnowflakeGenerator()
        {

        }

        public static SnowflakeGenerator Instance
        {
            get
            {
                if (_generator == null)
                {
                    lock (GeneratorLock)
                    {
                        if (_generator == null)
                        {
                            _generator = new SnowflakeGenerator();
                        }
                    }
                }
                return _generator;
            }
        }

        public long GenerateId()
        {
            lock (_idLock)
            {
                var timestamp = TimeGen();
                if (timestamp < _lastTimestamp)
                {
                    //TODO 是否可以考虑直接等待？
                    throw new Exception(
                        $"Clock moved backwards or wrapped around. Refusing to generate id for {_lastTimestamp - timestamp} ticks");
                }

                if (_lastTimestamp == timestamp)
                {
                    _sequence = (_sequence + 1) & SequenceMask;
                    if (_sequence == 0)
                    {
                        timestamp = TilNextMillis(_lastTimestamp);
                    }
                }
                else
                {
                    _sequence = 0;
                }

                _lastTimestamp = timestamp;
                return ((timestamp - TwEpoch) << TimestampLeftShift) |
                       (DatacenterId << DatacenterIdShift) |
                       (WorkerId << WorkerIdShift) | _sequence;

            }
        }
        private long TilNextMillis( long lastTimestamp )
        {
            var timestamp = TimeGen();
            while (timestamp <= lastTimestamp)
            {
                timestamp = TimeGen();
            }

            return timestamp;
        }

        private long TimeGen()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }
}
