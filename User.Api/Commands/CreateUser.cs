using System;

namespace User.Api.Commands
{
    public class CreateUser
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
    }
}