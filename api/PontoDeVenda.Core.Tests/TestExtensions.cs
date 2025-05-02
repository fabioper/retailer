using FluentResults;

namespace PontoDeVenda.Core.Tests;

public static class TestExtensions
{
    public static bool HasError(this Result result, Error error)
    {
        return result.HasError(err => err.Message == error.Message);
    }
}