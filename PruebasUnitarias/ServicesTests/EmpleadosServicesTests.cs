using Moq;
using RestAPI_Maxxi.Models;
using RestAPI_Maxxi.Services;

namespace PruebasUnitarias.ServicesTests
{
    public class EmpleadosServicesTests
    {
        private Empleados _itemResult = new Empleados();
        private Empleados _itemInput = new Empleados();
        private Mock<IEmpleadosRepositoryData> mockRepositorio = new Mock<IEmpleadosRepositoryData>();

        [SetUp]
        public void Setup()
        {
            _itemResult = new Empleados
            {
                Nombre = "Bernardo",
                Apellidos = "Perez Lopez",
                CURP = "CURP PRUEBA",
                FechaNacimiento = "1990/01/01",
                IdEmpleado = 1,
                Nacionalidad = "Mexicana",
                NEmpleado = 145,
                SSN = "999999999",
                Telefono = "4541515444"
            };

            _itemInput = new Empleados
            {
                Nombre = "Bernardo",
                Apellidos = "Perez Lopez",
                CURP = "CURP PRUEBA",
                FechaNacimiento = "1990/01/01",
                IdEmpleado = 0,
                Nacionalidad = "Mexicana",
                NEmpleado = 145,
                SSN = "999999999",
                Telefono = "4541515444"
            };
        }

        [Test]
        public async Task Verificar_CreateUser()
        {
            mockRepositorio.Setup(r => r.CreateUser(It.IsAny<Empleados>())).Returns(Task.FromResult(_itemResult));

            var testService = new EmpleadosService(mockRepositorio.Object);
            var result = await testService.CreateUser(_itemInput);

            Assert.NotNull(result);
            Assert.AreEqual(1, result.IdEmpleado);
        }

        [Test]
        public void Verificar_Mayor_De_Edad()
        {
            _itemInput.FechaNacimiento = "2018/05/25";

            mockRepositorio.Setup(r => r.CreateUser(It.IsAny<Empleados>())).Returns(Task.FromResult(_itemResult));

            var testService = new EmpleadosService(mockRepositorio.Object);
            Assert.ThrowsAsync<Exception>(async ()  => 
                await testService.CreateUser(_itemInput)
            );
        }

        [Test]
        public void Verificar_Numero_Telefonico()
        {
            _itemInput.Telefono = "77777777777777";

            mockRepositorio.Setup(r => r.CreateUser(It.IsAny<Empleados>())).Returns(Task.FromResult(_itemResult));

            var testService = new EmpleadosService(mockRepositorio.Object);
            Assert.ThrowsAsync<Exception>(async () =>
                await testService.CreateUser(_itemInput)
            );
        }

        [Test]
        public async Task Verificar_UpdateUser()
        {
            // Vamos actualizar el telefono
            _itemResult.Telefono = "5555555555";

            mockRepositorio.Setup(r => r.UpdateUser(It.IsAny<int>(),It.IsAny<Empleados>())).Returns(Task.FromResult(_itemResult));

            var testService = new EmpleadosService(mockRepositorio.Object);
            var result = await testService.UpdateUser(_itemInput.IdEmpleado, _itemInput);

            Assert.NotNull(result);
            Assert.AreNotEqual(_itemInput.Telefono, result.Telefono);
        }

        [Test]
        public async Task Verificar_DeleteUser()
        {
            // Vamos a eliminar el empleado 9
            _itemInput.IdEmpleado = 9;

            mockRepositorio.Setup(r => r.DeleteUser(It.IsAny<int>())).Returns(Task.FromResult(_itemInput.IdEmpleado));

            var testService = new EmpleadosService(mockRepositorio.Object);
            var result = await testService.DeleteUser(_itemInput.IdEmpleado);

            Assert.NotNull(result);
            Assert.AreEqual(_itemInput.IdEmpleado, result);
        }

        [Test]
        public async Task Verificar_GetUser()
        {
            // Vamos a obtener al empleado
            _itemInput.IdEmpleado = 16;
            _itemResult.IdEmpleado = 16;

            mockRepositorio.Setup(r => r.GetUser(It.IsAny<int>())).Returns(Task.FromResult(_itemResult));

            var testService = new EmpleadosService(mockRepositorio.Object);
            var result = await testService.GetUser(_itemInput.IdEmpleado);

            Assert.NotNull(result);
            Assert.AreEqual(_itemInput.IdEmpleado, result.IdEmpleado);
        }
    }
}
