using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Configure Database Connection (Monster MSSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=db22415.public.databaseasp.net; Database=db22415; User Id=db22415; Password=Y+e45F=gq%7S; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True"));

// ✅ Register Razor Pages
builder.Services.AddRazorPages();

// ✅ Register HttpContextAccessor for accessing cookies and request in _Layout
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// ✅ Global Error Handling & Fallback
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // Handles unhandled exceptions
    app.UseStatusCodePagesWithReExecute("/Error"); // Handles 404, 403, etc.
    app.UseHsts();
}
else
{
    // Shows detailed errors in development mode
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
