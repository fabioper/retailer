namespace PontoDeVenda.Common;

public static class CommonErrors
{
    public static NotFoundError EntityNotFound(string entityName, Guid id) =>
        new($"{entityName} with id {id} not found");
}