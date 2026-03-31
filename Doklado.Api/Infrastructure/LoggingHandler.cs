namespace Doklado.Api.Infrastructure;

public class LoggingHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (request.Content != null)
        {
            var body = await request.Content.ReadAsStringAsync(cancellationToken);
            Console.WriteLine("=== REQUEST BODY ===");
            Console.WriteLine(body);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}