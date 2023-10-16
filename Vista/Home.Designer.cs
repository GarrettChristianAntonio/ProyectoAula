
namespace Vista
{
    partial class Home
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbAula = new System.Windows.Forms.ComboBox();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.cbAnio = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(686, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(686, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(42, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(578, 281);
            this.dataGridView1.TabIndex = 2;
            // 
            // cbAula
            // 
            this.cbAula.FormattingEnabled = true;
            this.cbAula.Location = new System.Drawing.Point(61, 67);
            this.cbAula.Name = "cbAula";
            this.cbAula.Size = new System.Drawing.Size(121, 21);
            this.cbAula.TabIndex = 3;
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(405, 67);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(121, 21);
            this.cbMes.TabIndex = 4;
            // 
            // cbAnio
            // 
            this.cbAnio.FormattingEnabled = true;
            this.cbAnio.Location = new System.Drawing.Point(248, 67);
            this.cbAnio.Name = "cbAnio";
            this.cbAnio.Size = new System.Drawing.Size(121, 21);
            this.cbAnio.TabIndex = 5;
            this.cbAnio.SelectedIndexChanged += new System.EventHandler(this.cbAnio_SelectedIndexChanged);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(580, 63);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.cbAnio);
            this.Controls.Add(this.cbMes);
            this.Controls.Add(this.cbAula);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Home";
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbAula;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.ComboBox cbAnio;
        private System.Windows.Forms.Button btnConsultar;
    }
}