using System;

namespace User.Api.Model {
    public class Users {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

        public Users (Guid id, string firstname, string lastname, int age) {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
        }

    }
}