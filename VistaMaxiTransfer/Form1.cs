using Newtonsoft.Json;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Nodes;
using VistaMaxiTransfer.Models;

namespace VistaMaxiTransfer
{
    public partial class Form1 : Form
    {
        private string _pathUri = "https://localhost:7279/";
        private List<Beneficiarios> _listBeneficiarios = new List<Beneficiarios>();
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {

            if (lblProceso.Text != "Beneficiarios")
            {
                if (!string.IsNullOrEmpty(txbNombre.Text) && !string.IsNullOrEmpty(txbApellidos.Text) && !string.IsNullOrEmpty(txbFechaNac.Text)
                 && !string.IsNullOrEmpty(txbNEmpleado.Text) && !string.IsNullOrEmpty(txbCURP.Text) && !string.IsNullOrEmpty(txbSSN.Text)
                     && !string.IsNullOrEmpty(txbTelefono.Text) && !string.IsNullOrEmpty(txbNacionalidad.Text))
                {
                    try
                    {
                        var httpClient = new HttpClient();
                        var url = new Uri($"{_pathUri}Empleados");

                        var data = new
                        {
                            idEmpleado = 0,
                            nombre = txbNombre.Text,
                            apellidos = txbApellidos.Text,
                            fechaNacimiento = txbFechaNac.Text,
                            nEmpleado = txbNEmpleado.Text,
                            curp = txbCURP.Text,
                            ssn = txbSSN.Text,
                            telefono = txbTelefono.Text,
                            nacionalidad = txbNacionalidad.Text,
                        };

                        var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                        // Enviar la solicitud POST
                        HttpResponseMessage response = await httpClient.PostAsync(url, content);

                        // Verificar si la solicitud fue exitosa
                        if (response.IsSuccessStatusCode)
                        {
                            // Leer la respuesta si es necesario
                            string responseContent = await response.Content.ReadAsStringAsync();
                            ResultEmpleados jsonObject = JsonConvert.DeserializeObject<ResultEmpleados>(responseContent);

                            // Obtener el valor de idEmpleado
                            txbIdEmpleado.Text = jsonObject.IdEmpleado.ToString();
                            MessageBox.Show($"Registro guardado con el ID: {txbIdEmpleado.Text} ");
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error, revise los logs");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error, revise los logs");
                    }
                }
                else
                {
                    MessageBox.Show("Todos los campos son requeridos");
                }
            }
            else
            {
                AgregarBeneficiario();
            }
        }

        private void txbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números (0-9) y teclas de control como Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancelar la pulsación de tecla si no es un número ni una tecla de control
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Enviar solicitud GET
                var client = new HttpClient();
                client.BaseAddress = new Uri(_pathUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync($"Empleados/{txbIdEmpleado.Text}");

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta como una cadena JSON
                    string json = await response.Content.ReadAsStringAsync();
                    ResultEmpleados jsonObject = JsonConvert.DeserializeObject<ResultEmpleados>(json);

                    if (jsonObject.IdEmpleado > 0)
                    {
                        txbIdEmpleado.Enabled = false;
                        btnBuscar.Visible = false;
                        btnLimpiar.Visible = true;
                        btnAgregar.Visible = false;
                        btnActualizar.Visible = true;
                        btnEliminar.Visible = true;
                        btnBeneficiarios.Visible = true;

                        txbNombre.Text = jsonObject.Nombre;
                        txbApellidos.Text = jsonObject.Apellidos;
                        txbFechaNac.Text = jsonObject.FechaNacimiento;
                        txbNEmpleado.Text = jsonObject.NEmpleado.ToString();
                        txbCURP.Text = jsonObject.Curp;
                        txbSSN.Text = jsonObject.SSN;
                        txbTelefono.Text = jsonObject.Telefono;
                        txbNacionalidad.Text = jsonObject.Nacionalidad;

                    }
                    else
                    {
                        MessageBox.Show("El Id seleccionado no existe");
                    }
                }
                else
                {
                    // Si la solicitud no fue exitosa, mostrar el código de estado HTTP
                    MessageBox.Show($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (lblProceso.Text != "Beneficiarios")
            {
                btnBuscar.Visible = true;
                txbIdEmpleado.Enabled = true;
                txbIdEmpleado.Clear();
                txbNombre.Clear();
                txbApellidos.Clear();
                txbNEmpleado.Clear();
                txbCURP.Clear();
                txbSSN.Clear();
                txbTelefono.Clear();
                txbNacionalidad.Clear();
                btnAgregar.Visible = true;
                btnActualizar.Visible = false;
                btnEliminar.Visible = false;
                btnLimpiar.Visible = false;
                btnBeneficiarios.Visible = false;
                lblPorcentaje.Visible = false;
                txbPorcentaje.Visible = false;
                txbPorcentaje.Clear();
                lblProceso.Text = "";
            }
            else
            {
                txbNombre.Clear();
                txbApellidos.Clear();
                txbNEmpleado.Clear();
                txbCURP.Clear();
                txbSSN.Clear();
                txbTelefono.Clear();
                txbNacionalidad.Clear();
                txbPorcentaje.Clear();
                lblNEmpleado.Visible = false;
                txbNEmpleado.Text = string.Empty;
                txbNEmpleado.Visible = false;
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbNombre.Text) && !string.IsNullOrEmpty(txbApellidos.Text) && !string.IsNullOrEmpty(txbFechaNac.Text)
                && !string.IsNullOrEmpty(txbNEmpleado.Text) && !string.IsNullOrEmpty(txbCURP.Text) && !string.IsNullOrEmpty(txbSSN.Text)
                    && !string.IsNullOrEmpty(txbTelefono.Text) && !string.IsNullOrEmpty(txbNacionalidad.Text))
            {
                try
                {
                    var httpClient = new HttpClient();
                    var url = new Uri($"{_pathUri}Empleados/{txbIdEmpleado.Text}");

                    var data = new
                    {
                        idEmpleado = txbIdEmpleado.Text,
                        nombre = txbNombre.Text,
                        apellidos = txbApellidos.Text,
                        fechaNacimiento = txbFechaNac.Text,
                        nEmpleado = txbNEmpleado.Text,
                        curp = txbCURP.Text,
                        ssn = txbSSN.Text,
                        telefono = txbTelefono.Text,
                        nacionalidad = txbNacionalidad.Text,
                    };

                    var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Enviar la solicitud POST
                    HttpResponseMessage response = await httpClient.PutAsync(url, content);

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Registro Actualizado Correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error, revise los logs");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error, revise los logs");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son requeridos");
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            // Muestra un MessageBox de confirmación antes de eliminar
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verifica si el usuario ha confirmado la eliminación
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Enviar solicitud GET
                    var client = new HttpClient();
                    client.BaseAddress = new Uri(_pathUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.DeleteAsync($"Empleados/{txbIdEmpleado.Text}");

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer la respuesta como una cadena JSON
                        btnLimpiar_Click(sender, e);
                        MessageBox.Show("Registro Eliminado Correctamente");
                    }
                    else
                    {
                        // Si la solicitud no fue exitosa, mostrar el código de estado HTTP
                        MessageBox.Show("Ha ocurrido un error, revise los logs");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error, revise los logs");
                }
            }
        }

        private void btnBeneficiarios_Click(object sender, EventArgs e)
        {
            btnReset.Visible = true;
            lblPorcentaje.Visible = true;
            txbPorcentaje.Visible = true;
            btnBeneficiarios.Visible = false;
            lblIdEmpleado.Text = txbIdEmpleado.Text;
            lblProceso.Text = "Beneficiarios";
            btnAgregar.Visible = true;
            btnActualizar.Visible = false;
            btnEliminar.Visible = false;
            pnlBeneficiarios.Visible = true;
            btnLimpiar_Click(sender, e);
        }

        private void AgregarBeneficiario()
        {
            if (!string.IsNullOrEmpty(txbNombre.Text) && !string.IsNullOrEmpty(txbApellidos.Text) && !string.IsNullOrEmpty(txbFechaNac.Text)
                && !string.IsNullOrEmpty(txbPorcentaje.Text) && !string.IsNullOrEmpty(txbCURP.Text) && !string.IsNullOrEmpty(txbSSN.Text)
                    && !string.IsNullOrEmpty(txbTelefono.Text) && !string.IsNullOrEmpty(txbNacionalidad.Text))
            {
                try
                {
                    var suma = 0;
                    suma = suma + Int32.Parse(txbPorcentaje.Text);
                    _listBeneficiarios.Add(new Beneficiarios
                    {
                        IdBeneficiario = _listBeneficiarios.Count() + 1,
                        IdEmpleado = Int32.Parse(lblIdEmpleado.Text),
                        Nombre = txbNombre.Text,
                        Apellidos = txbApellidos.Text,
                        FechaNacimiento = txbFechaNac.Text,
                        Nacionalidad = txbNacionalidad.Text,
                        Telefono = txbTelefono.Text,
                        CURP = txbCURP.Text,
                        SSN = txbSSN.Text,
                        PorcentParticipacion = Int32.Parse(txbPorcentaje.Text)
                    });

                    cbBeneficiarios.DataSource = _listBeneficiarios;
                    cbBeneficiarios.DisplayMember = "Nombre";
                    cbBeneficiarios.ValueMember = "IdBeneficiario";

                    lblTotalPorcentaje.Text = suma.ToString() + "%";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error, revise los logs");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son requeridos");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnBuscar.Visible = true;
            txbIdEmpleado.Enabled = true;
            txbIdEmpleado.Clear();
            txbNombre.Clear();
            txbApellidos.Clear();
            txbNEmpleado.Clear();
            txbCURP.Clear();
            txbSSN.Clear();
            txbTelefono.Clear();
            txbNacionalidad.Clear();
            btnAgregar.Visible = true;
            btnActualizar.Visible = false;
            btnEliminar.Visible = false;
            btnLimpiar.Visible = false;
            btnBeneficiarios.Visible = false;
            lblPorcentaje.Visible = false;
            txbPorcentaje.Visible = false;
            txbPorcentaje.Clear();
            lblProceso.Text = "";
            lblNEmpleado.Visible = false;
            txbNEmpleado.Text = string.Empty;
            txbNEmpleado.Visible = false;
            lblPorcentaje.Visible = false;
            txbPorcentaje.Visible = false;
            btnBeneficiarios.Visible = false;
            lblIdEmpleado.Text = string.Empty;
            lblProceso.Text = "";
            pnlBeneficiarios.Visible = false;
            lblTotalPorcentaje.Text = "";
            cbBeneficiarios.Dispose();
            lblNEmpleado.Visible = true;
            txbNEmpleado.Visible = true;
            btnReset.Visible = false;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            var url = new Uri($"{_pathUri}Beneficiarios/{txbIdEmpleado.Text}");

            var data = new
            {
                idEmpleado = txbIdEmpleado.Text,
                nombre = txbNombre.Text,
                apellidos = txbApellidos.Text,
                fechaNacimiento = txbFechaNac.Text,
                nEmpleado = txbNEmpleado.Text,
                curp = txbCURP.Text,
                ssn = txbSSN.Text,
                telefono = txbTelefono.Text,
                nacionalidad = txbNacionalidad.Text,
                
            };

            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Enviar la solicitud POST
            HttpResponseMessage response = await httpClient.PutAsync(url, content);

            // Verificar si la solicitud fue exitosa
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Registro Actualizado Correctamente");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error, revise los logs");
            }
        }
    }
}
