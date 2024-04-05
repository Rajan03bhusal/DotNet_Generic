﻿namespace GenericProject.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
