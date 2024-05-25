﻿
using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;
using System.Net.WebSockets;

namespace BuildingBlocks.Behaviour;

public class ValidationBehaviour<TRequest, TResponse>
      (IEnumerable<IValidator<TRequest>> validators) 
    : IPipelineBehavior<TRequest, TResponse> 
    where TRequest: ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(validators.Select
            (v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults.
            SelectMany(r => r.Errors).
            Where(f => f != null)
           .ToList();

        if(failures.Any())
        {
            throw new ValidationException(failures);
        }

        return await next();
    }
}
