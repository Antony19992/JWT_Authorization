using System.Text.Json.Serialization;

namespace jwt_authorization.Models
{
    public class User
    {
            public string Guid { get; set; }
            public string Username { get; set; }
            public string Role { get; set; }

            [JsonIgnore]
            public string Password { get; set; }
    }
}
