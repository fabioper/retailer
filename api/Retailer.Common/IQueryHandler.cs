namespace Retailer.Common;

public interface IQueryHandler<in TQuery, TResult>
{
    Task<Result<TResult>> Execute(TQuery saleId);
}

public interface IQueryHandler<TResult>
{
    Task<Result<TResult>> Execute();
}