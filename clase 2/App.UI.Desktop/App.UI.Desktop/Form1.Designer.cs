namespace App.UI.Desktop
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LBLIGV = new System.Windows.Forms.Label();
            this.btnEnviarDocumento = new System.Windows.Forms.Button();
            this.btnElvis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Obtener IGV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IGV : ";
            // 
            // LBLIGV
            // 
            this.LBLIGV.AutoSize = true;
            this.LBLIGV.Location = new System.Drawing.Point(128, 130);
            this.LBLIGV.Name = "LBLIGV";
            this.LBLIGV.Size = new System.Drawing.Size(35, 13);
            this.LBLIGV.TabIndex = 2;
            this.LBLIGV.Text = "label2";
            // 
            // btnEnviarDocumento
            // 
            this.btnEnviarDocumento.Location = new System.Drawing.Point(31, 206);
            this.btnEnviarDocumento.Name = "btnEnviarDocumento";
            this.btnEnviarDocumento.Size = new System.Drawing.Size(141, 52);
            this.btnEnviarDocumento.TabIndex = 3;
            this.btnEnviarDocumento.Text = "Enviar Documento";
            this.btnEnviarDocumento.UseVisualStyleBackColor = true;
            this.btnEnviarDocumento.Click += new System.EventHandler(this.btnEnviarDocumento_Click);
            // 
            // btnElvis
            // 
            this.btnElvis.Location = new System.Drawing.Point(232, 217);
            this.btnElvis.Name = "btnElvis";
            this.btnElvis.Size = new System.Drawing.Size(127, 41);
            this.btnElvis.TabIndex = 4;
            this.btnElvis.Text = "Elvis Operator";
            this.btnElvis.UseVisualStyleBackColor = true;
            this.btnElvis.Click += new System.EventHandler(this.btnElvis_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 369);
            this.Controls.Add(this.btnElvis);
            this.Controls.Add(this.btnEnviarDocumento);
            this.Controls.Add(this.LBLIGV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBLIGV;
        private System.Windows.Forms.Button btnEnviarDocumento;
        private System.Windows.Forms.Button btnElvis;
    }
}

