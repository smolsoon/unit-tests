using System;

namespace Persons.Api.Model
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

        public Person(Guid id, string firstname, string lastname, int age)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Age = age;                
        }
    }
}