using K9.Base.DataAccessLayer.Models;
using System.Globalization;
using System.Threading;
using Xunit;

namespace K9.DataAccessLayer.Tests.Unit
{
    public class DescriptionAttributeTests
    {

        [Fact]
        public void GetLocalisedDescription_ShouldRespondToAttribute_AndLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr");

            var role = new Role
            {
                Name = "PowerUser"
            };

            var user = new User
            {
                FirstName = "Simon",
                LastName = "Glantz"
            };

            Assert.Equal("Utilisateur Puissant", role.Description);
            Assert.Equal("Simon Glantz", user.Description);
        }

	}
}
