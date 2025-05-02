using PontoDeVenda.Common;

namespace PontoDeVenda.Api;

public record ErrorDetails(int Status, string Message);

public static class ApiResultExtensions
{
    public static ActionResult ToActionResult(this Result result)
    {
        return result.IsSuccess ? new OkResult() : MapError(result.Errors);
    }

    public static ActionResult ToActionResult<T>(this Result<T> result)
    {
        return result.IsSuccess ? new OkObjectResult(result.Value) : MapError(result.Errors);
    }

    private static ObjectResult MapError(List<IError> errors)
    {
        var error = errors.First();

        var statusCode = error switch
        {
            ValidationError => 400,
            NotFoundError => 404,
            _ => 500
        };

        var details = new ErrorDetails(statusCode, error.Message);

        return new ObjectResult(details)
        {
            StatusCode = statusCode
        };
    }
}