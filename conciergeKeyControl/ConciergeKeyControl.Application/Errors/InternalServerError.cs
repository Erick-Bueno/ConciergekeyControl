using System.Runtime.CompilerServices;

public record InternalServerError(string detail) : Error(ErrorType.InternalServer.ToString(), nameof(InternalServerError));