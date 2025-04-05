using System.Net;
using RentingAPI.Domain.Exceptions;

namespace RentingAPI.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    /// <summary>
    /// Diccionario para mapear todas las excepciones y los status code de cada excepción
    /// </summary>
    private static readonly Dictionary<Type, HttpStatusCode> ExceptionStatusCodes = new()
    {
        { typeof(AlquilerNoEncontradoException), HttpStatusCode.NotFound },
        { typeof(ClienteNoEncontradoException), HttpStatusCode.NotFound },
        { typeof(VehiculoNoEncontradoException), HttpStatusCode.BadRequest },
        { typeof(MatriculaExistenteException), HttpStatusCode.BadRequest },
        { typeof(MatriculaVaciaException), HttpStatusCode.BadRequest },
        { typeof(ClienteAlquilerVigenteException), HttpStatusCode.BadRequest },
        { typeof(VehiculoAlquiladoException), HttpStatusCode.BadRequest },
        { typeof(VehiculoAntiguoException), HttpStatusCode.BadRequest },
        { typeof(VehiculoDevueltoException), HttpStatusCode.BadRequest },
        { typeof(VehiculoExistenteException), HttpStatusCode.BadRequest }
    };

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        
        var statusCode = ExceptionStatusCodes.TryGetValue(exception.GetType(), out var code) ? (int)code : (int)HttpStatusCode.InternalServerError;
        context.Response.StatusCode = statusCode;

        var response = new
        {
            error = exception.Message,
            statusCode
        };
        
        return context.Response.WriteAsJsonAsync(response);
    }
}
