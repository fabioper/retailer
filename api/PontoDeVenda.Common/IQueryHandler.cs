namespace PontoDeVenda.Common;

public interface IQueryHandler<in TQuery, TResult>
{
    Task<Result<TResult>> Execute(TQuery query);
}

public interface IQueryHandler<TResult>
{
    Task<Result<TResult>> Execute();
}