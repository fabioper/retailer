namespace PontoDeVenda.Common;

public class CommonError(string message) : Error(message);

public class ValidationError(string message) : CommonError(message);

public class NotFoundError(string message) : CommonError(message);