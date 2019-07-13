namespace Truco
{
    partial class Form0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form0));
            this.Assets0 = new System.Windows.Forms.ImageList(this.components);
            this.JugarB = new System.Windows.Forms.Button();
            this.JoinB = new System.Windows.Forms.Button();
            this.HostB = new System.Windows.Forms.Button();
            this.ConectarseB = new System.Windows.Forms.Button();
            this.ListaPorts = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Assets0
            // 
            this.Assets0.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Assets0.ImageStream")));
            this.Assets0.TransparentColor = System.Drawing.Color.Transparent;
            this.Assets0.Images.SetKeyName(0, "binding_dark.png");
            this.Assets0.Images.SetKeyName(1, "binding_light.png");
            this.Assets0.Images.SetKeyName(2, "black_twill.png");
            this.Assets0.Images.SetKeyName(3, "Button.png");
            this.Assets0.Images.SetKeyName(4, "Button2.png");
            this.Assets0.Images.SetKeyName(5, "Button3.png");
            this.Assets0.Images.SetKeyName(6, "Fondo.jpg");
            // 
            // JugarB
            // 
            this.JugarB.Enabled = false;
            this.JugarB.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.JugarB.ImageIndex = 4;
            this.JugarB.ImageList = this.Assets0;
            this.JugarB.Location = new System.Drawing.Point(329, 291);
            this.JugarB.Name = "JugarB";
            this.JugarB.Size = new System.Drawing.Size(126, 57);
            this.JugarB.TabIndex = 0;
            this.JugarB.Text = "Jugar";
            this.JugarB.UseVisualStyleBackColor = true;
            this.JugarB.Click += new System.EventHandler(this.JugarB_Click);
            // 
            // JoinB
            // 
            this.JoinB.Enabled = false;
            this.JoinB.Location = new System.Drawing.Point(355, 238);
            this.JoinB.Name = "JoinB";
            this.JoinB.Size = new System.Drawing.Size(75, 23);
            this.JoinB.TabIndex = 1;
            this.JoinB.Text = "JOIN";
            this.JoinB.UseVisualStyleBackColor = true;
            this.JoinB.Visible = false;
            this.JoinB.Click += new System.EventHandler(this.JoinB_Click);
            // 
            // HostB
            // 
            this.HostB.Enabled = false;
            this.HostB.Location = new System.Drawing.Point(355, 195);
            this.HostB.Name = "HostB";
            this.HostB.Size = new System.Drawing.Size(75, 23);
            this.HostB.TabIndex = 2;
            this.HostB.Text = "HOST";
            this.HostB.UseVisualStyleBackColor = true;
            this.HostB.Visible = false;
            this.HostB.Click += new System.EventHandler(this.HostB_Click);
            // 
            // ConectarseB
            // 
            this.ConectarseB.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ConectarseB.ImageIndex = 0;
            this.ConectarseB.ImageList = this.Assets0;
            this.ConectarseB.Location = new System.Drawing.Point(342, 354);
            this.ConectarseB.Name = "ConectarseB";
            this.ConectarseB.Size = new System.Drawing.Size(101, 41);
            this.ConectarseB.TabIndex = 3;
            this.ConectarseB.Text = "Conectarse";
            this.ConectarseB.UseVisualStyleBackColor = true;
            this.ConectarseB.Click += new System.EventHandler(this.ConectarseB_Click);
            // 
            // ListaPorts
            // 
            this.ListaPorts.FormattingEnabled = true;
            this.ListaPorts.Location = new System.Drawing.Point(329, 141);
            this.ListaPorts.Name = "ListaPorts";
            this.ListaPorts.Size = new System.Drawing.Size(126, 21);
            this.ListaPorts.TabIndex = 9;
            this.ListaPorts.Text = "              Puertos";
            this.ListaPorts.Visible = false;
            this.ListaPorts.SelectedIndexChanged += new System.EventHandler(this.CBoxCOMPORT_SelectedIndexChanged);
            // 
            // Form0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Truco.Properties.Resources.Fondo1;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ListaPorts);
            this.Controls.Add(this.ConectarseB);
            this.Controls.Add(this.HostB);
            this.Controls.Add(this.JoinB);
            this.Controls.Add(this.JugarB);
            this.Name = "Form0";
            this.Text = "Form0";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList Assets0;
        private System.Windows.Forms.Button JugarB;
        private System.Windows.Forms.Button JoinB;
        private System.Windows.Forms.Button HostB;
        private System.Windows.Forms.Button ConectarseB;
        private System.Windows.Forms.ComboBox ListaPorts;
    }
}