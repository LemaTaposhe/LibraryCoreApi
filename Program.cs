//using LibraryCoreApi.DAL.Interfaces;
//using LibraryCoreApi.DAL.Repositories;
//using LibraryCoreApi.Data;
//using LibraryCoreApi.Entities;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();


//// 

//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));

//// 
//builder.Services.AddTransient<IRepository<Category>, CategoryRepository>();
// builder.Services.AddTransient<IRepository<Author>, AuthorRepository>();
//builder.Services.AddTransient<IRepository<Publisher>, PublisherRepository>();
//builder.Services.AddTransient<IBookRepository, BookRepository>();

//builder.Services.AddCors(c =>
//{
//    c.AddPolicy("AllowOrigin", options => options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
//});
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseAuthorization();

//// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


//// Add other services if needed
//// builder.Services.AddAuthentication();
//// builder.Services.AddAuthorization();



//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}



////app.UseCors(); // Ensure this is placed between UseRouting() and UseEndpoints()

//app.UseRouting();
// app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
//app.UseAuthorization();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});


//app.Run();
using LibraryCoreApi.DAL.Interfaces;
using LibraryCoreApi.DAL.Repositories;
using LibraryCoreApi.Data;
using LibraryCoreApi.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));

// Register repositories
builder.Services.AddTransient<IRepository<Category>, CategoryRepository>();
builder.Services.AddTransient<IRepository<Author>, AuthorRepository>();
builder.Services.AddTransient<IRepository<Publisher>, PublisherRepository>();
builder.Services.AddTransient<IBookRepository, BookRepository>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", policy =>
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

// Apply CORS policy
app.UseCors("AllowOrigin");

app.UseAuthorization();

// Map controllers
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

