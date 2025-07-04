﻿using MediatR;
using RentACarAPI.Application.Features.Mediator.Results.AuthorResults;

namespace RentACarAPI.Application.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorByIdQuery : IRequest<GetAuthorByIdQueryResult>
    {
        public int Id { get; set; }

        public GetAuthorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
