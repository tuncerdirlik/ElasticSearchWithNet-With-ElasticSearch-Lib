using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace ElasticSearchWithNet.Api.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddElastic(this IServiceCollection services, IConfiguration configuration)
        {
            string username = configuration["Elastic:Username"]!;
            string password = configuration["Elastic:Password"]!;
            var settings = new ElasticsearchClientSettings(new Uri(configuration["Elastic:Url"]!)).Authentication(new BasicAuthentication(username, password));

            var client = new ElasticsearchClient(settings);

            services.AddSingleton(client);
        }
    }
}
