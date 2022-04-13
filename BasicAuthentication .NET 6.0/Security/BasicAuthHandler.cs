using BasicAuthentication_.NET_6._0.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BasicAuthentication_.NET_6._0.Security
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService _repository;
        public BasicAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
                                ILoggerFactory loggerFactory,
                                UrlEncoder urlEncoder,
                                ISystemClock systemClockm,
                                IUserService repository)
            : base(options, loggerFactory, urlEncoder, systemClockm)
        {
            _repository = repository;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization")) 
                return AuthenticateResult.Fail("No contains header");

            bool result = false;

            try
            {
                var AuthHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(AuthHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                //get parameters in array format
                var email = credentials[0];
                var password = credentials[1];
                result = _repository.isUser(email, password);
            }
            catch(Exception)
            {
                return AuthenticateResult.Fail("Some ERROR");
            }
            if (!result)
                return AuthenticateResult.Fail("Error User Email or Password ");

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "id"),
                 new Claim(ClaimTypes.Name, "user")
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }
    }
}
