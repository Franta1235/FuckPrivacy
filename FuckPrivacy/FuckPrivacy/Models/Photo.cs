using FuckPrivacy.Users;
using Newtonsoft.Json;

namespace FuckPrivacy.Models
{
    public class Photo
    {
        [JsonProperty("ImageSource")] public string Image { get; set; }
        [JsonProperty("Text")] public string Text { get; set; }
        [JsonProperty("Caption")] public string Caption { get; set; }
        [JsonProperty("UserFrom")] public AUser UserFrom { get; set; }
        [JsonProperty("UserTo")] public AUser UserTo { get; set; }
        [JsonProperty("Time")] public string Time { get; set; }
    }
}