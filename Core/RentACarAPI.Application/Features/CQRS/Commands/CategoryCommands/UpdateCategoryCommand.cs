﻿namespace RentACarAPI.Application.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        public int CategoryID { get; set; }
        public string? Name { get; set; }
    }
}
