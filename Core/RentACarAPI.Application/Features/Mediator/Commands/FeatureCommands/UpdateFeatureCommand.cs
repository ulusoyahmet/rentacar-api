﻿using MediatR;

namespace RentACarAPI.Application.Features.Mediator.Commands.FeatureCommands
{
    public class UpdateFeatureCommand : IRequest
    {
        public int FeatureID { get; set; }
        public string? Name { get; set; }
    }
}
