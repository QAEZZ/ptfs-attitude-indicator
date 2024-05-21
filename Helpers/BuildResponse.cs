using System;

namespace PtfsAi.Helpers;

public static class BuildResponse
{
    public static string Build(string msg, string data)
    {
        return $"{{\"msg\": \"{msg}\", \"data\": {data}}}";
    }
}