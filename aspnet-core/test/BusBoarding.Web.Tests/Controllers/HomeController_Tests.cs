using System.Threading.Tasks;
using BusBoarding.Models.TokenAuth;
using BusBoarding.Web.Controllers;
using Shouldly;
using Xunit;

namespace BusBoarding.Web.Tests.Controllers
{
    public class HomeController_Tests: BusBoardingWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}