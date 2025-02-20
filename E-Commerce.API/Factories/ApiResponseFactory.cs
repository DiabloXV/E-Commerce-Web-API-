﻿using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModels;
using System.Net;

namespace E_Commerce.API.Factories
{
    public class ApiResponseFactory
    {
        public static IActionResult CustomValidationErrorResponse (ActionContext context) 
        {
            //Get All errors in model state
            var errors = context.ModelState.Where(error => error.Value.Errors.Any()).Select(error => new ValidationError
            {
                Field = error.Key,
                Errors = error.Value.Errors.Select(e => e.ErrorMessage)
            });
            //Create Custom Response
            var response = new ValidationErrorResponse
            {
                Errors = errors,
                StatusCode = (int) HttpStatusCode.BadRequest,
                ErrorMessage = "Validation Failed"
            };

            //return
            return new BadRequestObjectResult(response);
        }
    }
}
