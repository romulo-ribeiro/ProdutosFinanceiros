using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using ProdutosFinanceiros.Application.Interfaces;

namespace ProdutosFinanceiros.Web.Handlers;

public class AuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    #region Property  
    readonly IUserService _userService;
    #endregion

    #region Constructor  
    public AuthenticationHandler(IUserService userService,
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder)
        : base(options, logger, encoder)
    {
        _userService = userService;
    }
    #endregion

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        string username;
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
            username = credentials.FirstOrDefault();
            var password = credentials.LastOrDefault();

            if (!await _userService.ValidateCredentials(username, password))
                throw new ArgumentException("Invalid credentials");
        }
        catch (Exception ex)
        {
            return AuthenticateResult.Fail($"Authentication failed: {ex.Message}");
        }

        var claims = new[] {
                new Claim(ClaimTypes.Name, username)
            };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}
