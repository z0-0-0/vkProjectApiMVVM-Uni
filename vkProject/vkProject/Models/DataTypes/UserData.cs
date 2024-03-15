using System.Runtime.InteropServices.JavaScript;
using System.Web;
using Microsoft.CodeAnalysis.Scripting;

namespace vkProj.Models;

public sealed class UserData
{
    private static UserData instance;

    public string? user_id { get; private set; }
    public string? access_token { get; private set; }
    public string? expires_in { get; private set; }

    private static object syncRoot = new();

    protected UserData(string userId, string accessToken, string expires_in)
    {
        user_id = userId;
        access_token = accessToken;
        this.expires_in = expires_in;
    }

    public static UserData getInstance(string userId, string accessToken, string expires_in)
    {
        if (instance != null) return instance;
        lock (syncRoot)
        {
            if (instance == null)
                instance = new UserData(userId, accessToken, expires_in);
        }

        return instance;
    }

    public static UserData readDataFromUrlEncoded(string urlMessage)
    {
        var decodedMessage = HttpUtility.ParseQueryString(urlMessage);
        return getInstance(decodedMessage["user_id"]!, decodedMessage["access_token"]!, decodedMessage["expires_in"]!);
    }
}