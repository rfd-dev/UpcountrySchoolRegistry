using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.API;
using Xunit;

namespace UpcountrySchoolRegistry.IntegrationTests.e2e
{
    public class SchoolIntegrationTests : IClassFixture<InMemoryDbWebApplicationFactory<UpcountrySchoolRegistry.API.Startup>>
    {
        private readonly InMemoryDbWebApplicationFactory<Startup> _factory;

        #region Constructor
        public SchoolIntegrationTests(InMemoryDbWebApplicationFactory<UpcountrySchoolRegistry.API.Startup> factory)
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
            var response = await client.GetAsync(@"/api/school?");

            // Assert
            response.EnsureSuccessStatusCode();
            var contentStr = await response.Content.ReadAsStringAsync();
            Assert.NotNull(contentStr);
        }
    }
}
