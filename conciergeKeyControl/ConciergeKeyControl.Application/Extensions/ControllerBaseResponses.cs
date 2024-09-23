using Microsoft.AspNetCore.Mvc;
using OneOf;

public static class ControllerBaseResponses{
    public static IActionResult RegisterUserResponse (this ControllerBase controllerBase, OneOf<ResponseUserRegisterSuccess, Error> response){
        return response.Match(
            response => controllerBase.Created("http://localhost:5055",response),
            error => {
                if(error.TypeError == ErrorType.Validation.ToString()){
                    return controllerBase.BadRequest(error);
                }
                return controllerBase.StatusCode(500, error);
            }
        );
    }
}