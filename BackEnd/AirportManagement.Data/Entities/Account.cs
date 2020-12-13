using System;
using System.ComponentModel.DataAnnotations;

namespace AirportManagement.Data
{
    public class Account : BaseEntity
    {
        [Required]
        public string UserName { get; private set; }
        [Required]
        public string Password { get; private set; }
        [Required]
        public string Email { get; private set; }
        public string Name { get; private set; } = default;
        public string SurName { get; private set; } = default;
        public string Sex { get; private set; } = default;
        public int Age { get; private set; } = default;

        public static Account Create(string username, string password, string email) => new Account()
        {
            Id = new Guid(),
            UserName = username,
            Password = password,
            Email = email
        };

    }

}