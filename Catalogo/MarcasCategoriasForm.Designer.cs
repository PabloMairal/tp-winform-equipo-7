namespace Catalogo
{
    partial class MarcasCategoriasForm
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
            this.lblNombreAux = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnGuardarAux = new System.Windows.Forms.Button();
            this.lblTituloAux = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombreAux
            // 
            this.lblNombreAux.AutoSize = true;
            this.lblNombreAux.Location = new System.Drawing.Point(22, 57);
            this.lblNombreAux.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreAux.Name = "lblNombreAux";
            this.lblNombreAux.Size = new System.Drawing.Size(44, 13);
            this.lblNombreAux.TabIndex = 1;
            this.lblNombreAux.Text = "Nombre";
            // 
            // txtNombreAux
            // 
            this.txtNombre.Location = new System.Drawing.Point(88, 54);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombreAux";
            this.txtNombre.Size = new System.Drawing.Size(132, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // btnGuardarAux
            // 
            this.btnGuardarAux.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            this.btnGuardarAux.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(0)))), ((int)(((byte)(55)))));
            this.btnGuardarAux.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarAux.ForeColor = System.Drawing.Color.White;
            this.btnGuardarAux.Location = new System.Drawing.Point(164, 98);
            this.btnGuardarAux.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarAux.Name = "btnGuardarAux";
            this.btnGuardarAux.Size = new System.Drawing.Size(68, 27);
            this.btnGuardarAux.TabIndex = 3;
            this.btnGuardarAux.Text = "Guardar";
            this.btnGuardarAux.UseVisualStyleBackColor = false;
            this.btnGuardarAux.Click += new System.EventHandler(this.btnGuardarAux_Click);
            // 
            // lblTituloAux
            // 
            this.lblTituloAux.AutoSize = true;
            this.lblTituloAux.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAux.Location = new System.Drawing.Point(22, 15);
            this.lblTituloAux.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTituloAux.Name = "lblTituloAux";
            this.lblTituloAux.Size = new System.Drawing.Size(49, 17);
            this.lblTituloAux.TabIndex = 0;
            this.lblTituloAux.Text = "Titulo";
            // 
            // MarcasCategoriasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(250, 147);
            this.Controls.Add(this.btnGuardarAux);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombreAux);
            this.Controls.Add(this.lblTituloAux);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(266, 186);
            this.MinimumSize = new System.Drawing.Size(266, 186);
            this.Name = "MarcasCategoriasForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNombreAux;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnGuardarAux;
        private System.Windows.Forms.Label lblTituloAux;
    }
}