using RentACarAPI.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACarAPI.Application.Features.CQRS.Handlers.BannerHandlers;
using RentACarAPI.Application.Features.CQRS.Handlers.BrandHandlers;
using RentACarAPI.Application.Features.CQRS.Handlers.CarHandlers;
using RentACarAPI.Application.Features.CQRS.Handlers.CategoryHandlers;
using RentACarAPI.Application.Features.CQRS.Handlers.ContactHandlers;
using RentACarAPI.Application.Features.Mapping;
using RentACarAPI.Application.Features.RepositoryPattern;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Application.Interfaces.CarRentingInterfaces;
using RentACarAPI.Application.Interfaces.StatisticsInterfaces;
using RentACarAPI.Application.Services;
using RentACarAPI.Persistence.Context;
using RentACarAPI.Persistence.Repositories;
using RentACarAPI.Persistence.Repositories.CarRentingRepositories;
using RentACarAPI.Persistence.Repositories.CommentRepositories;
using RentACarAPI.Persistence.Repositories.StatisticsRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CarBookContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));
builder.Services.AddScoped(typeof(ICarRentingRepository), typeof(CarRentingRepository));

// CQRS
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();

builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();

builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetCarWithDeepIncludesQueryHandler>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();

// Medaitor
builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddControllers();
    //.AddJsonOptions(options =>
    //{
    //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    //    options.JsonSerializerOptions.WriteIndented = true;
    //});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllers();

app.Run();
