using System.Text.Json.Serialization;
using System.Web;
using SQLite;

namespace vkProj.Models;

public class VkFile
{


    public string url { get; set; }

    public string title { get; set; }
    
    public string ext { get; set; }


}