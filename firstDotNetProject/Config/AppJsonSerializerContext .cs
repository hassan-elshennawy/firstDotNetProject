using firstDotNetProject.Entities.DTOs;
using System.Text.Json.Serialization;

namespace firstDotNetProject.Config
{
    [JsonSerializable(typeof(CreateUserRequestDTO))]
    public partial class AppJsonSerializerContext : JsonSerializerContext
    {

    }
}
