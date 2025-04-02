using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PSPsychological.WebApp.Services
{
    public interface IGraphQLExecutor
    {
        Task<T> ExecuteQuery<T>(string query);
        Task<T> ExecuteMutation<T>(string mutation);
    }

    public class GraphQLExecutor : IGraphQLExecutor
    {
        private readonly GraphQLHttpClient _client;

        public GraphQLExecutor()
        {
            // Sử dụng đúng serializer từ thư viện GraphQL.Client.Serializer.Newtonsoft
            var client = new GraphQLHttpClient("http://localhost:5296/graphql", new NewtonsoftJsonSerializer());
            _client = client;
        }

        public async Task<T> ExecuteQuery<T>(string query)
        {
            var request = new GraphQLRequest { Query = query };
            var response = await _client.SendQueryAsync<T>(request);
            return response.Data;
        }

        public async Task<T> ExecuteMutation<T>(string mutation)
        {
            var request = new GraphQLRequest { Query = mutation };
            var response = await _client.SendMutationAsync<T>(request);
            return response.Data;
        }
    }
}
