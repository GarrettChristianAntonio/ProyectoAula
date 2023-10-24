namespace Vista
{
    partial class Profesores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.cbIdProfesor = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.profesorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profesorcrear = new System.Windows.Forms.ToolStripMenuItem();
            this.profesormodificar = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profesorpagoscrear = new System.Windows.Forms.ToolStripMenuItem();
            this.profesorpagosver = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnocrear = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnoeliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnomodificar = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnover = new System.Windows.Forms.ToolStripMenuItem();
            this.profesorver = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblsumapago = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(223, 92);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(223, 118);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(223, 144);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 2;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(223, 170);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 20);
            this.txtDireccion.TabIndex = 3;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(223, 196);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtDocumento.TabIndex = 4;
            // 
            // cbIdProfesor
            // 
            this.cbIdProfesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdProfesor.FormattingEnabled = true;
            this.cbIdProfesor.Location = new System.Drawing.Point(213, 222);
            this.cbIdProfesor.Name = "cbIdProfesor";
            this.cbIdProfesor.Size = new System.Drawing.Size(121, 21);
            this.cbIdProfesor.TabIndex = 5;
            this.cbIdProfesor.SelectedIndexChanged += new System.EventHandler(this.cbIdProfesor_SelectedIndexChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(160, 404);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(293, 404);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profesorToolStripMenuItem,
            this.alumnoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(586, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // profesorToolStripMenuItem
            // 
            this.profesorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profesorcrear,
            this.profesormodificar,
            this.pagosToolStripMenuItem,
            this.profesorver});
            this.profesorToolStripMenuItem.Name = "profesorToolStripMenuItem";
            this.profesorToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.profesorToolStripMenuItem.Text = "Profesor";
            this.profesorToolStripMenuItem.Click += new System.EventHandler(this.profesorToolStripMenuItem_Click);
            // 
            // profesorcrear
            // 
            this.profesorcrear.Name = "profesorcrear";
            this.profesorcrear.Size = new System.Drawing.Size(180, 22);
            this.profesorcrear.Text = "Crear";
            this.profesorcrear.Click += new System.EventHandler(this.profesorcrear_Click);
            // 
            // profesormodificar
            // 
            this.profesormodificar.Name = "profesormodificar";
            this.profesormodificar.Size = new System.Drawing.Size(180, 22);
            this.profesormodificar.Text = "Modificar";
            this.profesormodificar.Click += new System.EventHandler(this.profesormodificar_Click);
            // 
            // pagosToolStripMenuItem
            // 
            this.pagosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profesorpagoscrear,
            this.profesorpagosver});
            this.pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
            this.pagosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pagosToolStripMenuItem.Text = "Pagos";
            this.pagosToolStripMenuItem.Click += new System.EventHandler(this.pagosToolStripMenuItem_Click);
            // 
            // profesorpagoscrear
            // 
            this.profesorpagoscrear.Name = "profesorpagoscrear";
            this.profesorpagoscrear.Size = new System.Drawing.Size(180, 22);
            this.profesorpagoscrear.Text = "Crear";
            this.profesorpagoscrear.Click += new System.EventHandler(this.profesorpagoscrear_Click);
            // 
            // profesorpagosver
            // 
            this.profesorpagosver.Name = "profesorpagosver";
            this.profesorpagosver.Size = new System.Drawing.Size(180, 22);
            this.profesorpagosver.Text = "Ver";
            this.profesorpagosver.Click += new System.EventHandler(this.profesorpagosver_Click);
            // 
            // alumnoToolStripMenuItem
            // 
            this.alumnoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alumnocrear,
            this.alumnoeliminar,
            this.alumnomodificar,
            this.alumnover});
            this.alumnoToolStripMenuItem.Name = "alumnoToolStripMenuItem";
            this.alumnoToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.alumnoToolStripMenuItem.Text = "Alumno";
            // 
            // alumnocrear
            // 
            this.alumnocrear.Name = "alumnocrear";
            this.alumnocrear.Size = new System.Drawing.Size(180, 22);
            this.alumnocrear.Text = "Crear";
            this.alumnocrear.Click += new System.EventHandler(this.alumnocrear_Click);
            // 
            // alumnoeliminar
            // 
            this.alumnoeliminar.Name = "alumnoeliminar";
            this.alumnoeliminar.Size = new System.Drawing.Size(180, 22);
            this.alumnoeliminar.Text = "Modificar";
            this.alumnoeliminar.Click += new System.EventHandler(this.alumnoeliminar_Click);
            // 
            // alumnomodificar
            // 
            this.alumnomodificar.Name = "alumnomodificar";
            this.alumnomodificar.Size = new System.Drawing.Size(180, 22);
            this.alumnomodificar.Text = "Eliminar";
            this.alumnomodificar.Click += new System.EventHandler(this.alumnomodificar_Click);
            // 
            // alumnover
            // 
            this.alumnover.Name = "alumnover";
            this.alumnover.Size = new System.Drawing.Size(180, 22);
            this.alumnover.Text = "Ver";
            this.alumnover.Click += new System.EventHandler(this.alumnover_Click);
            // 
            // profesorver
            // 
            this.profesorver.Name = "profesorver";
            this.profesorver.Size = new System.Drawing.Size(180, 22);
            this.profesorver.Text = "Ver";
            this.profesorver.Click += new System.EventHandler(this.profesorver_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(562, 251);
            this.dataGridView1.TabIndex = 20;
            // 
            // lblsumapago
            // 
            this.lblsumapago.AutoSize = true;
            this.lblsumapago.Location = new System.Drawing.Point(263, 373);
            this.lblsumapago.Name = "lblsumapago";
            this.lblsumapago.Size = new System.Drawing.Size(34, 13);
            this.lblsumapago.TabIndex = 21;
            this.lblsumapago.Text = "Total:";
            // 
            // Profesores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 450);
            this.Controls.Add(this.lblsumapago);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cbIdProfesor);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Profesores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.ComboBox cbIdProfesor;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem profesorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profesorcrear;
        private System.Windows.Forms.ToolStripMenuItem profesormodificar;
        private System.Windows.Forms.ToolStripMenuItem pagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profesorpagoscrear;
        private System.Windows.Forms.ToolStripMenuItem profesorpagosver;
        private System.Windows.Forms.ToolStripMenuItem profesorver;
        private System.Windows.Forms.ToolStripMenuItem alumnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alumnocrear;
        private System.Windows.Forms.ToolStripMenuItem alumnoeliminar;
        private System.Windows.Forms.ToolStripMenuItem alumnomodificar;
        private System.Windows.Forms.ToolStripMenuItem alumnover;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblsumapago;
    }
}