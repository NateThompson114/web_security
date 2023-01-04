using System.Reflection;
using System.Xml.Linq;

namespace WebApplication1.Fun;

public sealed class XDocumentModel
{
    public XDocumentModel(XDocument document) => Document = document;

    public XDocument Document { get; init; }

    public static async ValueTask<XDocumentModel?> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        if (!context.Request.HasXmlContentType())
            throw new BadHttpRequestException(
                message: "Request content type was not a recognized Xml content type.",
                StatusCodes.Status415UnsupportedMediaType);

        return new XDocumentModel(await XDocument.LoadAsync(context.Request.Body, LoadOptions.None, CancellationToken.None));
    }
} 