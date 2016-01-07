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
                    Name = "John Smith"
                },
                new Person()
                {
                    Name = "Sarah Jane"
                }
            };
        }

        public void Dispose()
        {
        }
    }
}