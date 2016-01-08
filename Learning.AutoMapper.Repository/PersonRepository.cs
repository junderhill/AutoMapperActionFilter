using System;
using System.Collections.Generic;

namespace Learning.AutoMapper.Repository
{
    public class PersonRepository : IDisposable
    {
        public List<Person> Get()
        {
            return new List<Person>()
            {
                new Person()
                {
                    Name = "John Smith",
                    Email = "john.smith@microsoft.com"
                },
                new Person()
                {
                    Name = "Sarah Jane",
                    Email = "sarah.jane@microsfot.ciom"
                }
            };
        }

        public void Dispose()
        {
        }
    }
}