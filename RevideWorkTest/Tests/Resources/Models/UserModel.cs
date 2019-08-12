using System;

namespace RevideWorkTest.Tests.Resources.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string MobilePhone { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ExternalId { get; set; }
        public Guid Id { get; set; }
        public string ContactType { get; set; }
        public UserModel()
        {
        }
    }
}
