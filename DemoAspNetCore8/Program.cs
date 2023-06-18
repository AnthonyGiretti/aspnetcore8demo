using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://login.microsoftonline.com/136544d9-038e-4646-afff-10accb370679/v2.0";
    options.Audience = "257b6c36-1168-4aac-be93-6f2cd81cec43";
    //options.TokenValidationParameters.ValidateLifetime = true;
    options.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
});
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/auth", (IHttpContextAccessor context) =>
{
    return Results.Ok("You are authenticated");
}).RequireAuthorization();

app.Run();

/*
Example of JWT issued by Azure AD
eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ii1LSTNROW5OUjdiUm9meG1lWm9YcWJIWkdldyJ9.eyJhdWQiOiIyNTdiNmMzNi0xMTY4LTRhYWMtYmU5My02ZjJjZDgxY2VjNDMiLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vMTM2NTQ0ZDktMDM4ZS00NjQ2LWFmZmYtMTBhY2NiMzcwNjc5L3YyLjAiLCJpYXQiOjE2ODcwOTMxNjksIm5iZiI6MTY4NzA5MzE2OSwiZXhwIjoxNjg3MDk0MDY5LCJhaW8iOiJBYlFBUy84VEFBQUE3R0JtNHVjeHVzQ1l5anJQRHRmZGVvS3p4WFBLdVl6QVJ6bis2b2MzeS9EYU5tS25wbG1rTmlZM1FTK2UzNE9yVjlkOHo4VGNKbS96WjZCYmN0ME1jOCsxZkNOZXk2YTlzYWU5dVVjQXgrd2tiZmNoTzI0RFAvU2paNWNmbUd3R1JCN1FIM3JsOHJUdkZ1YlpmUmhaSmJiMVEyS2FYaWhCcStFT1dta1BzMTlIWFNvTHhaUHMrUUo2Y2dpVWFiQ0tZL1hMMmIzY1ordHpYWkRmRUZjQVF1ZUVlUnF4djBxUUpFQ0hTS0laUmpnPSIsImdyb3VwcyI6WyI2Yzc4Y2Q2MC0xNmViLTQ2OTYtYWUyOS04NGZlNzEzMzA1ZDQiLCI4MTE1ZTNiZS1hYzdhLTQ4ODYtYTFlNi01YjZhYWY4MTBhOGYiLCJmYzE5YTg2Mi02NDUyLTRlOTktOTlhMi04MjBhZmEzOWNiZWUiLCIyYzM3MmQ5OC0xM2I2LTQwY2QtYjViMi1mOTFmZTJlYzUxNjIiXSwiaWRwIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvOTE4ODA0MGQtNmM2Ny00YzViLWIxMTItMzZhMzA0YjY2ZGFkLyIsIm5hbWUiOiJBbnRob255IEdJUkVUVEkiLCJub25jZSI6IjdhNWVhM2MzLTE2ZGYtNDg4Mi05NGFmLTI5MzAzZTA3ZDlkZCIsIm9pZCI6ImY5MTc1YmM4LWI3ZWMtNGQ5Zi05YjUzLTIwZjY4MzY2ZjJjOCIsInByZWZlcnJlZF91c2VybmFtZSI6ImFudGhvbnkuZ2lyZXR0aUBnbWFpbC5jb20iLCJyaCI6IjAuQVZnQTJVUmxFNDREUmthdl94Q3N5emNHZVRac2V5Vm9FYXhLdnBOdkxOZ2M3RU5ZQUdrLiIsInJvbGVzIjpbIlN1cnZleUNyZWF0b3IiXSwic3ViIjoiNDM3VmVqWnBzMVNxUnFaRXVHeWYtSEhxQkZUMmdOdTRDS3p3OVllMGJHcyIsInRpZCI6IjEzNjU0NGQ5LTAzOGUtNDY0Ni1hZmZmLTEwYWNjYjM3MDY3OSIsInV0aSI6IlVDbnBMVHVaY1V1SG5JUWkxWFY5QUEiLCJ2ZXIiOiIyLjAifQ.d6OD27P3onvd21S98J77IR-WpCAs2qhJIIhcNjrDxaaG8AsKqJSy1f2E1hwvkA17vcdgkci3wTW_nNBArXV6pzAZrJ9u8bZSVUBATvyyKVkTBdtStEUs9wtu4B-e_ufRkszzULp_Sw8OGpw85eDcPc4APPM003It6PAIcuCRDNs0zkVXUKwax2NqCI_OC__krlczOqt3La3Y1TwT6mNvBqRKDREaIm4JeokSALjsH7woGFB8oeCTeUVqX2QLzKmgzqGtLWW4dAM_7V5VfJcY3hhNa55iLw95kpuoKQ4mZTUnknoUoQag9QizhemV83Enh8tTu15PCCoPxFJx0P7OaA
*/
