using System.Runtime.CompilerServices;

public record InternalServerError(string Detail) : Error(ErrorType.InternalServer.ToString(), nameof(InternalServerError));