using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Authentication
{
    public class DummyAuth : AuthenticationHandler<DummyAuthOptions>
    {
        public DummyAuth(IOptionsMonitor<DummyAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (Request.Headers.TryGetValue("Authentication", out var key)
                && key == "I'm authenticated")
            {
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, "Known user")
                };
                return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity(claims, Scheme.Name)), Scheme.Name)));
            }

            return Task.FromResult(AuthenticateResult.Fail("Invalid login"));
        }
    }
}
