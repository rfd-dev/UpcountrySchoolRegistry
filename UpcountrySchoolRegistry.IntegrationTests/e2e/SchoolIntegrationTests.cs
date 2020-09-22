using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UpcountrySchoolRegistry.API;
using UpcountrySchoolRegistry.API.DataContracts.Requests;
using UpcountrySchoolRegistry.Business.Domain;
using UpcountrySchoolRegistry.IntegrationTests.Helpers;
using UpcountrySchoolRegistry.Repository;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace UpcountrySchoolRegistry.IntegrationTests.e2e
{    
    public class SchoolIntegrationTests : IClassFixture<InMemoryDbWebApplicationFactory<UpcountrySchoolRegistry.API.Startup>>
    {        
        private readonly InMemoryDbWebApplicationFactory<Startup> _factory;
        private readonly HttpClient client;

        #region Constructor
        public SchoolIntegrationTests(InMemoryDbWebApplicationFactory<UpcountrySchoolRegistry.API.Startup> factory)
        {
            this._factory = factory;

            // Repopulando o DB antes de cada testes para garantir que vai funcionar independente da ordem.
            client = this._factory.WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var serviceProvider = services.BuildServiceProvider();
                        using (var scope = serviceProvider.CreateScope())
                        {
                            var scopedServices = scope.ServiceProvider;
                            var db = scopedServices.GetRequiredService<UpcountrySchoolRegistryContext>();
                            var logger = scopedServices.GetRequiredService<ILogger<SchoolIntegrationTests>>();

                            try
                            {
                                Utilities.ReinitializeDbForTests(db);
                            }
                            catch (Exception ex)
                            {
                                logger.LogError(ex, "An error occurred seeding " +
                                    "the database with test messages. Error: {Message}",
                                    ex.Message);
                            }
                        }
                    });
                })
                .CreateClient();
        }
        #endregion

        [Theory]
        [InlineData("", 3)]
        [InlineData("Cambuci", 2)]
        [InlineData("Aplicação", 1)]
        [InlineData("UERJ", 0)]
        public async Task GetAsync_InformaQueryString_RecebeListaEscolas(string queryString, int qtdExpectedMatches)
        {
            // Act
            var response = await client.GetAsync($"/api/school?filter={queryString}");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseResult = await response.Content.ReadAsAsync<List<School>>();
            Assert.Equal(qtdExpectedMatches, responseResult.Count);
        }

        [Fact]
        public async Task GetAsync_InformaID_RecebeEscola()
        {
             // Act
            var response = await client.GetAsync($"/api/school/1");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseResult = await response.Content.ReadAsAsync<School>();

            Assert.Equal(1, responseResult.ID);
            Assert.Equal("Colégio de Aplicação da UFPE", responseResult.Name);
            Assert.Equal("Recife", responseResult.Address);
        }

        [Fact]
        public async Task PostAsync_SubmiteNovaEscola_RecebeEntityPreenchida()
        {
            // Arrange
            var newSchool = new SchoolRequest
            {
                Name = "Escola Santa Clara",
                Address = "Rua Sete de Setembro, 79"
            };
            string serializedBody = JsonSerializer.Serialize(newSchool);
            var postContent = new StringContent(serializedBody, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync($"/api/school/", postContent);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseResult = await response.Content.ReadAsAsync<School>();

            Assert.True(responseResult.ID > 0);
            // TODO: Adicionar consultar ao InMemoryDB para validar insert.
        }

        [Fact]
        public async Task PutAsync_AtualizaEscola_RecebeDadosAtualizados()
        {
            // Arrange
            var newSchool = new SchoolRequest
            {
                Name = "Escola REDACTED",
                Address = "REDACTED"
            };
            string serializedBody = JsonSerializer.Serialize(newSchool);
            var postContent = new StringContent(serializedBody, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync($"/api/school/2", postContent);

            // Assert
            response.EnsureSuccessStatusCode();
            // TODO: Adicionar consultar ao InMemoryDB para evidênciar a alteração
        }

        [Fact]
        public async Task DeleteAsync_RecebeID_DeletaEscola()
        {
            // Act
            var response = await client.DeleteAsync($"/api/school/1");

            // Assert
            response.EnsureSuccessStatusCode();
            // TODO: Adicionar consultar ao InMemoryDB para evidênciar a deleção
        }
    }
}
