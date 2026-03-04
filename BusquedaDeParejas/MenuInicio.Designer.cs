
namespace BusquedaDeParejas
{
    partial class MenuInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuInicio));
            this.label1 = new System.Windows.Forms.Label();
            this.BtnIniciar = new System.Windows.Forms.Button();
            this.BtnDificultad = new System.Windows.Forms.Button();
            this.BtnRanking = new System.Windows.Forms.Button();
            this.BtnIdioma = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.CBIdioma = new System.Windows.Forms.ComboBox();
            this.CBDificultad = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 30F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(110, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Busqueda de Parejas";
            // 
            // BtnIniciar
            // 
            this.BtnIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnIniciar.FlatAppearance.BorderSize = 0;
            this.BtnIniciar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnIniciar.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold);
            this.BtnIniciar.Location = new System.Drawing.Point(237, 78);
            this.BtnIniciar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnIniciar.Name = "BtnIniciar";
            this.BtnIniciar.Size = new System.Drawing.Size(105, 33);
            this.BtnIniciar.TabIndex = 1;
            this.BtnIniciar.Text = "Iniciar";
            this.BtnIniciar.UseVisualStyleBackColor = true;
            this.BtnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            // 
            // BtnDificultad
            // 
            this.BtnDificultad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDificultad.FlatAppearance.BorderSize = 0;
            this.BtnDificultad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnDificultad.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold);
            this.BtnDificultad.Location = new System.Drawing.Point(237, 115);
            this.BtnDificultad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDificultad.Name = "BtnDificultad";
            this.BtnDificultad.Size = new System.Drawing.Size(105, 33);
            this.BtnDificultad.TabIndex = 2;
            this.BtnDificultad.Text = "Dificultad";
            this.BtnDificultad.UseVisualStyleBackColor = true;
            this.BtnDificultad.Click += new System.EventHandler(this.BtnDificultad_Click);
            // 
            // BtnRanking
            // 
            this.BtnRanking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRanking.FlatAppearance.BorderSize = 0;
            this.BtnRanking.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnRanking.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold);
            this.BtnRanking.Location = new System.Drawing.Point(237, 152);
            this.BtnRanking.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnRanking.Name = "BtnRanking";
            this.BtnRanking.Size = new System.Drawing.Size(105, 33);
            this.BtnRanking.TabIndex = 3;
            this.BtnRanking.Text = "Ranking";
            this.BtnRanking.UseVisualStyleBackColor = true;
            this.BtnRanking.Click += new System.EventHandler(this.BtnRanking_Click);
            // 
            // BtnIdioma
            // 
            this.BtnIdioma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnIdioma.FlatAppearance.BorderSize = 0;
            this.BtnIdioma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnIdioma.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold);
            this.BtnIdioma.Location = new System.Drawing.Point(237, 189);
            this.BtnIdioma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnIdioma.Name = "BtnIdioma";
            this.BtnIdioma.Size = new System.Drawing.Size(105, 33);
            this.BtnIdioma.TabIndex = 4;
            this.BtnIdioma.Text = "Idioma";
            this.BtnIdioma.UseVisualStyleBackColor = true;
            this.BtnIdioma.Click += new System.EventHandler(this.BtnIdioma_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSalir.FlatAppearance.BorderSize = 0;
            this.BtnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.BtnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnSalir.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold);
            this.BtnSalir.Location = new System.Drawing.Point(237, 226);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(105, 33);
            this.BtnSalir.TabIndex = 5;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // CBIdioma
            // 
            this.CBIdioma.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.CBIdioma.FormattingEnabled = true;
            this.CBIdioma.Items.AddRange(new object[] {
            "Español",
            "English",
            "Français"});
            this.CBIdioma.Location = new System.Drawing.Point(348, 192);
            this.CBIdioma.Name = "CBIdioma";
            this.CBIdioma.Size = new System.Drawing.Size(104, 29);
            this.CBIdioma.TabIndex = 7;
            this.CBIdioma.Visible = false;
            this.CBIdioma.SelectedIndexChanged += new System.EventHandler(this.CBIdioma_SelectedIndexChanged);
            // 
            // CBDificultad
            // 
            this.CBDificultad.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold);
            this.CBDificultad.FormattingEnabled = true;
            this.CBDificultad.Items.AddRange(new object[] {
            "Facil",
            "Intermedio",
            "Dificil",
            "Profesional"});
            this.CBDificultad.Location = new System.Drawing.Point(348, 118);
            this.CBDificultad.Name = "CBDificultad";
            this.CBDificultad.Size = new System.Drawing.Size(104, 29);
            this.CBDificultad.TabIndex = 8;
            this.CBDificultad.Visible = false;
            this.CBDificultad.SelectedIndexChanged += new System.EventHandler(this.CBDificultad_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 71);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // MenuInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(600, 293);
            this.ControlBox = false;
            this.Controls.Add(this.CBDificultad);
            this.Controls.Add(this.CBIdioma);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnIdioma);
            this.Controls.Add(this.BtnRanking);
            this.Controls.Add(this.BtnDificultad);
            this.Controls.Add(this.BtnIniciar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MenuInicio";
            this.Load += new System.EventHandler(this.MenuInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnIniciar;
        private System.Windows.Forms.Button BtnDificultad;
        private System.Windows.Forms.Button BtnRanking;
        private System.Windows.Forms.Button BtnIdioma;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox CBIdioma;
        private System.Windows.Forms.ComboBox CBDificultad;
    }
}

