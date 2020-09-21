using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.API;
using Xunit;

namespace UpcountrySchoolRegistry.IntegrationTests.e2e
{
    public class SchoolIntegrationTests : IClassFixture<WebApplicationFactory<UpcountrySchoolRegistry.API.Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        #region Constructor
        public SchoolIntegrationTests(WebApplicationFactory<UpcountrySchoolRegistry.API.Startup> factory)
        {
            this._factory = factory;
        }
        #endregion

        [Fact]
        public async Task Get_InformaID_RecebeEntidade()
        {
            // Arrange
            var client = this._factory.CreateClient();

            // Act
            var response = await client.GetAsync(@"/school");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
