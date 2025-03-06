using System.Text.Json.Serialization;

namespace EmployeeApps.Api.Models
{
    public class ApiResponse
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("result")]
        public ServiceResult Result { get; set; } = new ServiceResult();
    }

    public class ApiResponse<T>
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("result")]
        public T? Result;
    }

}
