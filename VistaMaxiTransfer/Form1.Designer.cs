namespace VistaMaxiTransfer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txbNombre = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txbApellidos = new TextBox();
            label4 = new Label();
            txbFechaNac = new DateTimePicker();
            lblNEmpleado = new Label();
            txbNEmpleado = new TextBox();
            txbCURP = new TextBox();
            label6 = new Label();
            txbSSN = new TextBox();
            label7 = new Label();
            txbTelefono = new TextBox();
            label8 = new Label();
            txbNacionalidad = new TextBox();
            label9 = new Label();
            btnAgregar = new Button();
            txbIdEmpleado = new TextBox();
            btnActualizar = new Button();
            btnEliminar = new Button();
            txbResultado = new Label();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            btnBeneficiarios = new Button();
            txbPorcentaje = new TextBox();
            lblPorcentaje = new Label();
            lblIdEmpleado = new Label();
            lblProceso = new Label();
            pnlBeneficiarios = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            lblTotalPorcentaje = new Label();
            label10 = new Label();
            cbBeneficiarios = new ComboBox();
            label5 = new Label();
            btnReset = new Button();
            pnlBeneficiarios.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 58);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // txbNombre
            // 
            txbNombre.Location = new Point(116, 51);
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(178, 27);
            txbNombre.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 18);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 2;
            label2.Text = "IdGeneral";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 101);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 4;
            label3.Text = "Apellidos:";
            // 
            // txbApellidos
            // 
            txbApellidos.Location = new Point(116, 94);
            txbApellidos.Name = "txbApellidos";
            txbApellidos.Size = new Size(330, 27);
            txbApellidos.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 141);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 6;
            label4.Text = "Fecha Nac.";
            // 
            // txbFechaNac
            // 
            txbFechaNac.CustomFormat = "yyyy/MM/dd";
            txbFechaNac.Format = DateTimePickerFormat.Custom;
            txbFechaNac.Location = new Point(116, 136);
            txbFechaNac.Name = "txbFechaNac";
            txbFechaNac.Size = new Size(125, 27);
            txbFechaNac.TabIndex = 7;
            // 
            // lblNEmpleado
            // 
            lblNEmpleado.AutoSize = true;
            lblNEmpleado.Location = new Point(15, 180);
            lblNEmpleado.Name = "lblNEmpleado";
            lblNEmpleado.Size = new Size(101, 20);
            lblNEmpleado.TabIndex = 8;
            lblNEmpleado.Text = "N° Empleado:";
            // 
            // txbNEmpleado
            // 
            txbNEmpleado.Location = new Point(116, 177);
            txbNEmpleado.Name = "txbNEmpleado";
            txbNEmpleado.Size = new Size(125, 27);
            txbNEmpleado.TabIndex = 9;
            // 
            // txbCURP
            // 
            txbCURP.Location = new Point(116, 216);
            txbCURP.Name = "txbCURP";
            txbCURP.Size = new Size(250, 27);
            txbCURP.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(58, 219);
            label6.Name = "label6";
            label6.Size = new Size(48, 20);
            label6.TabIndex = 10;
            label6.Text = "CURP:";
            // 
            // txbSSN
            // 
            txbSSN.Location = new Point(116, 260);
            txbSSN.Name = "txbSSN";
            txbSSN.Size = new Size(250, 27);
            txbSSN.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(58, 263);
            label7.Name = "label7";
            label7.Size = new Size(39, 20);
            label7.TabIndex = 12;
            label7.Text = "SSN:";
            // 
            // txbTelefono
            // 
            txbTelefono.Location = new Point(116, 302);
            txbTelefono.MaxLength = 10;
            txbTelefono.Name = "txbTelefono";
            txbTelefono.Size = new Size(250, 27);
            txbTelefono.TabIndex = 15;
            txbTelefono.KeyPress += txbTelefono_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(45, 305);
            label8.Name = "label8";
            label8.Size = new Size(70, 20);
            label8.TabIndex = 14;
            label8.Text = "Telefono:";
            // 
            // txbNacionalidad
            // 
            txbNacionalidad.Location = new Point(116, 349);
            txbNacionalidad.Name = "txbNacionalidad";
            txbNacionalidad.Size = new Size(250, 27);
            txbNacionalidad.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(17, 352);
            label9.Name = "label9";
            label9.Size = new Size(101, 20);
            label9.TabIndex = 16;
            label9.Text = "Nacionalidad:";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(612, 37);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(112, 41);
            btnAgregar.TabIndex = 18;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txbIdEmpleado
            // 
            txbIdEmpleado.Location = new Point(116, 15);
            txbIdEmpleado.Name = "txbIdEmpleado";
            txbIdEmpleado.Size = new Size(125, 27);
            txbIdEmpleado.TabIndex = 19;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(612, 98);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(112, 41);
            btnActualizar.TabIndex = 20;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Visible = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(612, 157);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 41);
            btnEliminar.TabIndex = 21;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Visible = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txbResultado
            // 
            txbResultado.AutoSize = true;
            txbResultado.Location = new Point(116, 399);
            txbResultado.Name = "txbResultado";
            txbResultado.Size = new Size(0, 20);
            txbResultado.TabIndex = 23;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(257, 14);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 24;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(357, 15);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 29);
            btnLimpiar.TabIndex = 25;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Visible = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnBeneficiarios
            // 
            btnBeneficiarios.Location = new Point(558, 288);
            btnBeneficiarios.Name = "btnBeneficiarios";
            btnBeneficiarios.Size = new Size(166, 41);
            btnBeneficiarios.TabIndex = 22;
            btnBeneficiarios.Text = "Asignar Beneficiarios";
            btnBeneficiarios.UseVisualStyleBackColor = true;
            btnBeneficiarios.Visible = false;
            btnBeneficiarios.Click += btnBeneficiarios_Click;
            // 
            // txbPorcentaje
            // 
            txbPorcentaje.Location = new Point(116, 392);
            txbPorcentaje.MaxLength = 3;
            txbPorcentaje.Name = "txbPorcentaje";
            txbPorcentaje.Size = new Size(125, 27);
            txbPorcentaje.TabIndex = 27;
            txbPorcentaje.Visible = false;
            txbPorcentaje.KeyPress += txbTelefono_KeyPress;
            // 
            // lblPorcentaje
            // 
            lblPorcentaje.AutoSize = true;
            lblPorcentaje.Location = new Point(15, 395);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(90, 20);
            lblPorcentaje.TabIndex = 26;
            lblPorcentaje.Text = "% Beneficio:";
            lblPorcentaje.Visible = false;
            // 
            // lblIdEmpleado
            // 
            lblIdEmpleado.AutoSize = true;
            lblIdEmpleado.Location = new Point(20, 438);
            lblIdEmpleado.Name = "lblIdEmpleado";
            lblIdEmpleado.Size = new Size(0, 20);
            lblIdEmpleado.TabIndex = 28;
            lblIdEmpleado.Visible = false;
            // 
            // lblProceso
            // 
            lblProceso.AutoSize = true;
            lblProceso.Location = new Point(21, 459);
            lblProceso.Name = "lblProceso";
            lblProceso.Size = new Size(0, 20);
            lblProceso.TabIndex = 29;
            lblProceso.Visible = false;
            // 
            // pnlBeneficiarios
            // 
            pnlBeneficiarios.Controls.Add(button3);
            pnlBeneficiarios.Controls.Add(button2);
            pnlBeneficiarios.Controls.Add(button1);
            pnlBeneficiarios.Controls.Add(lblTotalPorcentaje);
            pnlBeneficiarios.Controls.Add(label10);
            pnlBeneficiarios.Controls.Add(cbBeneficiarios);
            pnlBeneficiarios.Controls.Add(label5);
            pnlBeneficiarios.Location = new Point(789, 36);
            pnlBeneficiarios.Name = "pnlBeneficiarios";
            pnlBeneficiarios.Size = new Size(556, 340);
            pnlBeneficiarios.TabIndex = 30;
            pnlBeneficiarios.Visible = false;
            // 
            // button3
            // 
            button3.Location = new Point(372, 279);
            button3.Name = "button3";
            button3.Size = new Size(166, 41);
            button3.TabIndex = 23;
            button3.Text = "Guardar Beneficiarios";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(212, 183);
            button2.Name = "button2";
            button2.Size = new Size(112, 41);
            button2.TabIndex = 22;
            button2.Text = "Eliminar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(64, 183);
            button1.Name = "button1";
            button1.Size = new Size(112, 41);
            button1.TabIndex = 19;
            button1.Text = "Modificar";
            button1.UseVisualStyleBackColor = true;
            // 
            // lblTotalPorcentaje
            // 
            lblTotalPorcentaje.AutoSize = true;
            lblTotalPorcentaje.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotalPorcentaje.Location = new Point(361, 100);
            lblTotalPorcentaje.Name = "lblTotalPorcentaje";
            lblTotalPorcentaje.Size = new Size(0, 30);
            lblTotalPorcentaje.TabIndex = 3;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(230, 108);
            label10.Name = "label10";
            label10.Size = new Size(125, 20);
            label10.TabIndex = 2;
            label10.Text = "Total % Asignado";
            // 
            // cbBeneficiarios
            // 
            cbBeneficiarios.FormattingEnabled = true;
            cbBeneficiarios.Location = new Point(37, 55);
            cbBeneficiarios.Name = "cbBeneficiarios";
            cbBeneficiarios.Size = new Size(462, 28);
            cbBeneficiarios.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 28);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 0;
            label5.Text = "Beneficiarios";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(466, 14);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 31;
            btnReset.Text = "Resetear";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Visible = false;
            btnReset.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1381, 499);
            Controls.Add(btnReset);
            Controls.Add(pnlBeneficiarios);
            Controls.Add(lblProceso);
            Controls.Add(lblIdEmpleado);
            Controls.Add(txbPorcentaje);
            Controls.Add(lblPorcentaje);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(txbResultado);
            Controls.Add(btnBeneficiarios);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(txbIdEmpleado);
            Controls.Add(btnAgregar);
            Controls.Add(txbNacionalidad);
            Controls.Add(label9);
            Controls.Add(txbTelefono);
            Controls.Add(label8);
            Controls.Add(txbSSN);
            Controls.Add(label7);
            Controls.Add(txbCURP);
            Controls.Add(label6);
            Controls.Add(txbNEmpleado);
            Controls.Add(lblNEmpleado);
            Controls.Add(txbFechaNac);
            Controls.Add(label4);
            Controls.Add(txbApellidos);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txbNombre);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Empleados / Beneficiarios";
            pnlBeneficiarios.ResumeLayout(false);
            pnlBeneficiarios.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txbNombre;
        private Label label2;
        private Label label3;
        private TextBox txbApellidos;
        private Label label4;
        private DateTimePicker txbFechaNac;
        private Label lblNEmpleado;
        private TextBox txbNEmpleado;
        private TextBox txbCURP;
        private Label label6;
        private TextBox txbSSN;
        private Label label7;
        private TextBox txbTelefono;
        private Label label8;
        private TextBox txbNacionalidad;
        private Label label9;
        private Button btnAgregar;
        private TextBox txbIdEmpleado;
        private Button btnActualizar;
        private Button btnEliminar;
        private Label txbResultado;
        private Button btnBuscar;
        private Button btnLimpiar;
        private Button btnBeneficiarios;
        private TextBox txbPorcentaje;
        private Label lblPorcentaje;
        private Label lblIdEmpleado;
        private Label lblProceso;
        private Panel pnlBeneficiarios;
        private Label label10;
        private ComboBox cbBeneficiarios;
        private Label label5;
        private Label lblTotalPorcentaje;
        private Button button1;
        private Button button3;
        private Button button2;
        private Button btnReset;
    }
}
