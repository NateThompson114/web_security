namespace WebApplication1.Fun;

internal static class HttpRequestXmlExtensions
{
    public static bool HasXmlContentType(this HttpRequest request)
        => request.Headers.TryGetValue("Content-Type", out var contentType)
           && string.Equals(contentType, "application/xml", StringComparison.InvariantCulture);
}