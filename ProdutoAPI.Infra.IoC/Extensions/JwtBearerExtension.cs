using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoAPI.Infra.IoC.Extensions
{
    public static class JwtBearerExtension
    {
        public static IServiceCollection AddJwtBearerConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //lendo configurações do /appsetings
            var issuer = configuration.GetSection("TokenSettings:Issuer").Value;
            var audience = configuration.GetSection("TokenSettings:Audience").Value;
            var secretKey = configuration.GetSection("TokenSettings:SecretKey").Value;

            //Definindo a politica de autenticação
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                //Definindo as preferencias para autenticação com JWT
                .AddJwtBearer(options =>
                {
                    //definindo as preferencias para autenticação com TOKEN JWT
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true, //validar o emissor do token
                        ValidateAudience = true, //validar o destinatario do token
                        ValidateLifetime = true, //validar o tempo de expiração do token
                        ValidateIssuerSigningKey = true, //validar a chave secreta utilizada elo emissor do token
                        ValidIssuer = issuer, //Nome emissor do tokem
                        ValidAudience = audience,//cliente do token
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), //chave
                    };
                });

            return services;
        }
    }
}
