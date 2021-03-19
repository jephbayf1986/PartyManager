using System;

namespace PartyManager.Application.Main.People.Queries.Models
{
    public class PersonDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FullName 
        {
            get
            {
                return $"{FirstName} {LastName}";
            } 
        }

        public int Age
        {
            get
            {
                var today = DateTime.Today;

                var age = today.Year - DateOfBirth.Year;

                //Ensure Correct
                if (DateOfBirth.Date > today.AddYears(-age)) age--;

                return age;
            }
        }
    }
}