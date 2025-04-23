using ApiGestionBiblioteca_Progra06.Modelos;
using LogicaNegocio.Implementacion;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using LogicaNegocio.Interfaces;

namespace ApiGestionBiblioteca_Progra06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly iSeguridadLN gObjSegLN;
        private readonly string llaveSecreta;

        public AutenticacionController(IConfiguration lConfig)
        {
            gObjSegLN = new SeguridadLN(lConfig.GetConnectionString("SEGCnn"));
            llaveSecreta = lConfig.GetSection("LlaveToken").GetSection("LlaveSecreta").ToString();
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult validarUsuario([FromBody] Usuario pUsuario)
        {
            try
            {
                var lOblUsuario = gObjSegLN.obtenerUsuario(pUsuario.usuario);
                if (lOblUsuario != null)
                {
                    if (pUsuario.contrasena == lOblUsuario.TcContrasena)
                    {
                        var llaveBytes = Encoding.ASCII.GetBytes(llaveSecreta);
                        var dato = new ClaimsIdentity();
                        dato.AddClaim(new Claim(ClaimTypes.NameIdentifier, pUsuario.usuario));

                        var descToken = new SecurityTokenDescriptor
                        {
                            Subject = dato,
                            Expires = DateTime.UtcNow.AddMinutes(5),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llaveBytes), SecurityAlgorithms.HmacSha256Signature)
                        };

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var tokenConfig = tokenHandler.CreateToken(descToken);
                        string tokenCreado = tokenHandler.WriteToken(tokenConfig);
                        return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }
    }
}
