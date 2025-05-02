namespace PontoDeVenda.Common;

public interface IUseCase<in TCommand, TResult>
{
    Task<Result<TResult>> Execute(TCommand command);
}

public interface IUseCase<TResult>
{
    Task<Result<TResult>> Execute();
}

public interface IUseCase
{
    Task<Result> Execute();
}