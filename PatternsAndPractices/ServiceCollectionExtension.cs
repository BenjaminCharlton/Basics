using Basics.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Basics.PatternsAndPractices
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddJwtAuthentication<TJwtFactory>(
            this IServiceCollection instance, 
            IConfigurationSection jwtAppSettingOptions,
            SymmetricSecurityKey signingKey)
            where TJwtFactory : class, IJwtFactory
        {
            return instance.AddSingleton<IJwtFactory, TJwtFactory>()
                .Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            })

            .AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });
        }
    }
}
