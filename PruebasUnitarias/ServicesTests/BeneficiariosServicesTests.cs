using Moq;
using RestAPI_Maxxi.Models;
using RestAPI_Maxxi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.ServicesTests
{
    public class BeneficiariosServicesTests
    {
        private Beneficiarios _itemResult = new Beneficiarios();
        private Beneficiarios _itemInput = new Beneficiarios();
        private Empleados _itemResultEmpleado = new Empleados();
        private List<Beneficiarios> _itemInputList = new List<Beneficiarios>();
        private List<Beneficiarios> _itemResultList = new List<Beneficiarios>();
        private Mock<IBeneficiarioRepositoryData> _mockRepositorio = new Mock<IBeneficiarioRepositoryData>();
        private Mock<IEmpleadosRepositoryData> _mockRepositorioEmpleados = new Mock<IEmpleadosRepositoryData>();
        [SetUp]
        public void Setup()
        {
            _itemResultEmpleado = new Empleados
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

            _itemResult = new Beneficiarios
            {
                IdBeneficiario = 1,
                IdEmpleado = 1,
                Nombre = "Bernardo",
                Apellidos = "Perez Lopez",
                CURP = "CURP PRUEBA",
                FechaNacimiento = "1990/01/01",
                Nacionalidad = "Mexicana",
                PorcentParticipacion = 100,
                SSN = "999999999",
                Telefono = "4541515444"
            };

            _itemInput = new Beneficiarios
            {
                IdBeneficiario = 0,
                IdEmpleado = 1,
                Nombre = "Bernardo",
                Apellidos = "Perez Lopez",
                CURP = "CURP PRUEBA",
                FechaNacimiento = "1990/01/01",
                Nacionalidad = "Mexicana",
                PorcentParticipacion = 100,
                SSN = "999999999",
                Telefono = "4541515444"
            };

            _itemInputList.Add(_itemInput);
            _itemResultList.Add(_itemResult);

            _mockRepositorioEmpleados.Setup(r => r.GetUser(It.IsAny<int>())).Returns(Task.FromResult(_itemResultEmpleado));
        }

        [Test]
        public async Task Verificar_CreateUser()
        {
            _mockRepositorio.Setup(r => r.CreateUser(It.IsAny<Beneficiarios>())).Returns(Task.FromResult(_itemResult));

            var testService = new BeneficiariosService(_mockRepositorio.Object, _mockRepositorioEmpleados.Object);
            var result = await testService.CreateUser(1, _itemInputList);

            Assert.NotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0].IdBeneficiario);
        }

        [TestCase("Venezolana")]
        [TestCase("Mexicana")]
        public async Task Verificar_UpdateUser(string nacionalidad)
        {
            _itemResult.Nacionalidad = nacionalidad;
            _itemInput.Nacionalidad = nacionalidad;

            _mockRepositorio.Setup(r => r.UpdateUser(It.IsAny<int>(), It.IsAny<Beneficiarios>())).Returns(Task.FromResult(_itemResult));

            var testService = new BeneficiariosService(_mockRepositorio.Object, _mockRepositorioEmpleados.Object);
            var result = await testService.UpdateUser(1, _itemInput);

            Assert.NotNull(result);
            Assert.AreEqual(nacionalidad, result.Nacionalidad);
        }

        [Test]
        public async Task Verificar_DeleteUser()
        {
            _mockRepositorio.Setup(r => r.DeleteUser(It.IsAny<int>())).Returns(Task.FromResult(_itemResult.IdBeneficiario));

            var testService = new BeneficiariosService(_mockRepositorio.Object, _mockRepositorioEmpleados.Object);
            var result = await testService.DeleteUser(1);

            Assert.NotNull(result);
            Assert.AreEqual(_itemInput.IdEmpleado, result);
        }

        [Test]
        public async Task Verificar_GetUser()
        {
            _mockRepositorio.Setup(r => r.GetUser(It.IsAny<int>())).Returns(Task.FromResult(_itemResult));

            var testService = new BeneficiariosService(_mockRepositorio.Object, _mockRepositorioEmpleados.Object);
            var result = await testService.GetUser(1);

            Assert.NotNull(result);
            Assert.AreEqual(_itemResult.IdBeneficiario, result.IdBeneficiario);
        }

        [Test]
        public async Task Verificar_GetByEmployee()
        {
            _itemResult.IdBeneficiario = 2;
            _itemResult.Nombre = "Usuario Prueba";

            _itemResultList.Add(_itemResult);
            _mockRepositorio.Setup(r => r.GetByEmployee(It.IsAny<int>())).Returns(Task.FromResult(_itemResultList));

            var testService = new BeneficiariosService(_mockRepositorio.Object, _mockRepositorioEmpleados.Object);
            var result = await testService.GetByEmployee(1);

            Assert.NotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
