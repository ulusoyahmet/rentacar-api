﻿using MediatR;

namespace RentACarAPI.Application.Features.Mediator.Commands.TagCommands
{
    public class RemoveTagCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveTagCommand(int id)
        {
            Id = id;
        }
    }
}
