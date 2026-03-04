
namespace BusquedaDeParejas
{
    partial class Ganador
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ganador));
            this.ganador1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Clasificacion = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TBNick = new System.Windows.Forms.TextBox();
            this.BtnContinuar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PBGif = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBGif)).BeginInit();
            this.SuspendLayout();
            // 
            // ganador1
            // 
            this.ganador1.AutoSize = true;
            this.ganador1.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ganador1.ForeColor = System.Drawing.Color.Red;
            this.ganador1.Location = new System.Drawing.Point(12, 74);
            this.ganador1.Name = "ganador1";
            this.ganador1.Size = new System.Drawing.Size(863, 153);
            this.ganador1.TabIndex = 0;
            this.ganador1.Text = "¡¡GANASTE!!";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(385, 521);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Clasificacion
            // 
            this.Clasificacion.AutoSize = true;
            this.Clasificacion.Font = new System.Drawing.Font("Microsoft JhengHei", 50F, System.Drawing.FontStyle.Bold);
            this.Clasificacion.ForeColor = System.Drawing.Color.Blue;
            this.Clasificacion.Location = new System.Drawing.Point(170, 74);
            this.Clasificacion.Name = "Clasificacion";
            this.Clasificacion.Size = new System.Drawing.Size(551, 85);
            this.Clasificacion.TabIndex = 2;
            this.Clasificacion.Text = "CLASIFICACION";
            // 
            // data
            // 
            this.data.AllowUserToAddRows = false;
            this.data.AllowUserToDeleteRows = false;
            this.data.AllowUserToResizeColumns = false;
            this.data.AllowUserToResizeRows = false;
            this.data.BackgroundColor = System.Drawing.Color.White;
            this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data.Location = new System.Drawing.Point(199, 203);
            this.data.Name = "data";
            this.data.ReadOnly = true;
            this.data.RowHeadersVisible = false;
            this.data.RowHeadersWidth = 51;
            this.data.Size = new System.Drawing.Size(492, 265);
            this.data.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(307, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "Introduce tu nick:";
            // 
            // TBNick
            // 
            this.TBNick.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNick.Location = new System.Drawing.Point(330, 363);
            this.TBNick.Name = "TBNick";
            this.TBNick.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.TBNick.Size = new System.Drawing.Size(208, 31);
            this.TBNick.TabIndex = 2;
            this.TBNick.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TBNick_MouseClick);
            this.TBNick.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNick_KeyPress);
            // 
            // BtnContinuar
            // 
            this.BtnContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnContinuar.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold);
            this.BtnContinuar.Location = new System.Drawing.Point(385, 474);
            this.BtnContinuar.Name = "BtnContinuar";
            this.BtnContinuar.Size = new System.Drawing.Size(105, 33);
            this.BtnContinuar.TabIndex = 1;
            this.BtnContinuar.Text = "Continuar";
            this.BtnContinuar.UseVisualStyleBackColor = true;
            this.BtnContinuar.Click += new System.EventHandler(this.BtnContinuar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 439);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // PBGif
            // 
            this.PBGif.Image = global::BusquedaDeParejas.Properties.Resources.dance_meme;
            this.PBGif.Location = new System.Drawing.Point(662, 223);
            this.PBGif.Name = "PBGif";
            this.PBGif.Size = new System.Drawing.Size(218, 271);
            this.PBGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBGif.TabIndex = 7;
            this.PBGif.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(796, 521);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Ganador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(910, 564);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PBGif);
            this.Controls.Add(this.BtnContinuar);
            this.Controls.Add(this.TBNick);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.data);
            this.Controls.Add(this.Clasificacion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ganador1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Ganador";
            this.Load += new System.EventHandler(this.Ganador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ganador1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Clasificacion;
        private System.Windows.Forms.DataGridView data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBNick;
        private System.Windows.Forms.Button BtnContinuar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox PBGif;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
    }
}