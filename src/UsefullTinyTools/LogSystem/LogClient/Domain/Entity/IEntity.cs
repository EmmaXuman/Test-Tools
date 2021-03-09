using System;
using System.Collections.Generic;
using System.Text;

namespace LogClient.Domain.Entity
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
    public class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
    }
}
