using Microsoft.AspNetCore.Mvc;
using RestAPI_Maxxi.Models;
using RestAPI_Maxxi.Services;

namespace RestAPI_Maxxi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly ILogger<EmpleadosController> _logger;
        private readonly IEmpleados _empleados;

        public EmpleadosController(ILogger<EmpleadosController> logger, IEmpleados empleados)
        {
            _logger = logger;
            _empleados = empleados;
        }

        [HttpGet]
        public ActionResult<Empleados> Get()
        {
            var data = new Empleados();
            return data;
        }

        [HttpGet("{idEmpleado}")]
        public ActionResult<Empleados> Get(int idEmpleado)
        {
            var result = _empleados.GetUser(idEmpleado);
            return Ok(result.Result);
        }

        [HttpPost]
        public ActionResult<Empleados> Post([FromBody] Empleados empleado)
        {
            var data = _empleados.CreateUser(empleado);
            return Ok(data.Result);
        }

        [HttpPut("{idEmpleado}")]
        public ActionResult Put(int idEmpleado, [FromBody] Empleados empleado)
        {
            var data = _empleados.UpdateUser(idEmpleado, empleado);
            return Ok(data.Result);
        }

        [HttpDelete("{idEmpleado}")]
        public ActionResult Delete(int idEmpleado)
        {
            var result = _empleados.DeleteUser(idEmpleado);
            return Ok(result.Result);
        }
    }
}
