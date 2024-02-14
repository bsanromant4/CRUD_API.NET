using Microsoft.AspNetCore.Mvc;
using RestAPI_Maxxi.Models;
using RestAPI_Maxxi.Services;

namespace RestAPI_Maxxi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeneficiariosController : ControllerBase
    {
        private readonly ILogger<BeneficiariosController> _logger;
        private readonly IBeneficiario _beneficiarios;

        public BeneficiariosController(ILogger<BeneficiariosController> logger, IBeneficiario beneficiarios)
        {
            _logger = logger;
            _beneficiarios = beneficiarios;
        }

        [HttpGet("Employee/{idEmpleado}")]
        public ActionResult<List<Beneficiarios>> GetByEmployee(int idEmpleado)
        {
            var result = _beneficiarios.GetByEmployee(idEmpleado);
            return Ok(result?.Result);
        }

        [HttpGet("{idBeneficiario}")]
        public ActionResult<Beneficiarios> Get(int idBeneficiario)
        {
            var result = _beneficiarios.GetUser(idBeneficiario);
            return Ok(result?.Result);
        }

        [HttpPost("{idBeneficiario}")]
        public ActionResult<Beneficiarios> Post(int idBeneficiario, [FromBody] List<Beneficiarios> beneficiarios)
        {
            var data = _beneficiarios.CreateUser(idBeneficiario, beneficiarios);
            return Ok(data?.Result);
        }

        [HttpPut("{idBeneficiario}")]
        public ActionResult Put(int idBeneficiario, [FromBody] Beneficiarios beneficiarios)
        {
            var data = _beneficiarios.UpdateUser(idBeneficiario, beneficiarios);
            return Ok(data?.Result);
        }

        [HttpDelete("{idBeneficiario}")]
        public ActionResult Delete(int idBeneficiario)
        {
            var result = _beneficiarios.DeleteUser(idBeneficiario);
            return Ok(result?.Result);
        }
    }
}
