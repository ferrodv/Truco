namespace Truco
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Baraja = new System.Windows.Forms.ImageList(this.components);
            this.Vira = new System.Windows.Forms.Button();
            this.Card2 = new System.Windows.Forms.Button();
            this.Card1 = new System.Windows.Forms.Button();
            this.Card0 = new System.Windows.Forms.Button();
            this.Mine = new System.Windows.Forms.Button();
            this.Enemy = new System.Windows.Forms.Button();
            this.MyPts = new System.Windows.Forms.Label();
            this.EnemyPts = new System.Windows.Forms.Label();
            this.MyMarcador = new System.Windows.Forms.Label();
            this.EnemyMacarcador = new System.Windows.Forms.Label();
            this.Assets = new System.Windows.Forms.ImageList(this.components);
            this.MyTruco = new System.Windows.Forms.Label();
            this.EnemyTruco = new System.Windows.Forms.Label();
            this.PtsML = new System.Windows.Forms.Label();
            this.PtsEL = new System.Windows.Forms.Label();
            this.TrucoB = new System.Windows.Forms.Button();
            this.EnvidoB = new System.Windows.Forms.Button();
            this.MazoB = new System.Windows.Forms.Button();
            this.RendirseB = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.MensajeL = new System.Windows.Forms.Label();
            this.AceptoB = new System.Windows.Forms.Button();
            this.ElevoB = new System.Windows.Forms.Button();
            this.RechazoB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Baraja
            // 
            this.Baraja.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Baraja.ImageStream")));
            this.Baraja.TransparentColor = System.Drawing.Color.Transparent;
            this.Baraja.Images.SetKeyName(0, "AS_BASTO.jpg");
            this.Baraja.Images.SetKeyName(1, "AS_COPA.jpg");
            this.Baraja.Images.SetKeyName(2, "AS_ESPADA.jpg");
            this.Baraja.Images.SetKeyName(3, "AS_ORO.jpg");
            this.Baraja.Images.SetKeyName(4, "CABALLO_BASTO.jpg");
            this.Baraja.Images.SetKeyName(5, "CABALLO_COPA.jpg");
            this.Baraja.Images.SetKeyName(6, "CABALLO_ESPADA.jpg");
            this.Baraja.Images.SetKeyName(7, "CABALLO_ORO.jpg");
            this.Baraja.Images.SetKeyName(8, "CINCO_BASTO.jpg");
            this.Baraja.Images.SetKeyName(9, "CINCO_COPA.jpg");
            this.Baraja.Images.SetKeyName(10, "CINCO_ESPADA.jpg");
            this.Baraja.Images.SetKeyName(11, "CINCO_ORO.jpg");
            this.Baraja.Images.SetKeyName(12, "CUATRO_BASTO.jpg");
            this.Baraja.Images.SetKeyName(13, "CUATRO_COPA.jpg");
            this.Baraja.Images.SetKeyName(14, "CUATRO_ESPADA.jpg");
            this.Baraja.Images.SetKeyName(15, "CUATRO_ORO.jpg");
            this.Baraja.Images.SetKeyName(16, "DOS_BASTO.jpg");
            this.Baraja.Images.SetKeyName(17, "DOS_COPA.jpg");
            this.Baraja.Images.SetKeyName(18, "DOS_ESPADA.jpg");
            this.Baraja.Images.SetKeyName(19, "DOS_ORO.jpg");
            this.Baraja.Images.SetKeyName(20, "Downside.png");
            this.Baraja.Images.SetKeyName(21, "REY_BASTO.jpg");
            this.Baraja.Images.SetKeyName(22, "REY_COPA.jpg");
            this.Baraja.Images.SetKeyName(23, "REY_ESPADA.jpg");
            this.Baraja.Images.SetKeyName(24, "REY_ORO.jpg");
            this.Baraja.Images.SetKeyName(25, "SEIS_BASTO.jpg");
            this.Baraja.Images.SetKeyName(26, "SEIS_COPA.jpg");
            this.Baraja.Images.SetKeyName(27, "SEIS_ESPADA.jpg");
            this.Baraja.Images.SetKeyName(28, "SEIS_ORO.jpg");
            this.Baraja.Images.SetKeyName(29, "SIETE_BASTO.jpg");
            this.Baraja.Images.SetKeyName(30, "SIETE_COPA.jpg");
            this.Baraja.Images.SetKeyName(31, "SIETE_ESPADA.jpg");
            this.Baraja.Images.SetKeyName(32, "SIETE_ORO.jpg");
            this.Baraja.Images.SetKeyName(33, "SOTA_BASTO.jpg");
            this.Baraja.Images.SetKeyName(34, "SOTA_COPA.jpg");
            this.Baraja.Images.SetKeyName(35, "SOTA_ESPADA.jpg");
            this.Baraja.Images.SetKeyName(36, "SOTA_ORO.jpg");
            this.Baraja.Images.SetKeyName(37, "TRES_BASTO.jpg");
            this.Baraja.Images.SetKeyName(38, "TRES_COPA.jpg");
            this.Baraja.Images.SetKeyName(39, "TRES_ESPADA.jpg");
            this.Baraja.Images.SetKeyName(40, "TRES_ORO.jpg");
            // 
            // Vira
            // 
            this.Vira.AutoSize = true;
            this.Vira.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Vira.BackColor = System.Drawing.Color.DarkGreen;
            this.Vira.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Vira.ImageKey = "(ninguno)";
            this.Vira.ImageList = this.Baraja;
            this.Vira.Location = new System.Drawing.Point(104, 184);
            this.Vira.Margin = new System.Windows.Forms.Padding(5);
            this.Vira.MaximumSize = new System.Drawing.Size(100, 150);
            this.Vira.MinimumSize = new System.Drawing.Size(100, 150);
            this.Vira.Name = "Vira";
            this.Vira.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Vira.Size = new System.Drawing.Size(100, 150);
            this.Vira.TabIndex = 3;
            this.Vira.UseVisualStyleBackColor = false;
            this.Vira.Visible = false;
            // 
            // Card2
            // 
            this.Card2.AutoSize = true;
            this.Card2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Card2.BackColor = System.Drawing.Color.DarkGreen;
            this.Card2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Card2.ImageKey = "(ninguno)";
            this.Card2.ImageList = this.Baraja;
            this.Card2.Location = new System.Drawing.Point(434, 412);
            this.Card2.Margin = new System.Windows.Forms.Padding(5);
            this.Card2.MaximumSize = new System.Drawing.Size(100, 150);
            this.Card2.MinimumSize = new System.Drawing.Size(100, 150);
            this.Card2.Name = "Card2";
            this.Card2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Card2.Size = new System.Drawing.Size(100, 150);
            this.Card2.TabIndex = 2;
            this.Card2.UseVisualStyleBackColor = false;
            this.Card2.Visible = false;
            this.Card2.Click += new System.EventHandler(this.Card2_Click);
            // 
            // Card1
            // 
            this.Card1.AutoSize = true;
            this.Card1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Card1.BackColor = System.Drawing.Color.DarkGreen;
            this.Card1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Card1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Card1.ImageKey = "(ninguno)";
            this.Card1.ImageList = this.Baraja;
            this.Card1.Location = new System.Drawing.Point(324, 397);
            this.Card1.Margin = new System.Windows.Forms.Padding(5);
            this.Card1.MaximumSize = new System.Drawing.Size(100, 150);
            this.Card1.MinimumSize = new System.Drawing.Size(100, 150);
            this.Card1.Name = "Card1";
            this.Card1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Card1.Size = new System.Drawing.Size(100, 150);
            this.Card1.TabIndex = 1;
            this.Card1.UseVisualStyleBackColor = false;
            this.Card1.Visible = false;
            this.Card1.Click += new System.EventHandler(this.Card1_Click);
            // 
            // Card0
            // 
            this.Card0.AutoSize = true;
            this.Card0.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Card0.BackColor = System.Drawing.Color.DarkGreen;
            this.Card0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Card0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Card0.ImageKey = "(ninguno)";
            this.Card0.ImageList = this.Baraja;
            this.Card0.Location = new System.Drawing.Point(214, 412);
            this.Card0.Margin = new System.Windows.Forms.Padding(5);
            this.Card0.MaximumSize = new System.Drawing.Size(100, 150);
            this.Card0.MinimumSize = new System.Drawing.Size(100, 150);
            this.Card0.Name = "Card0";
            this.Card0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Card0.Size = new System.Drawing.Size(100, 150);
            this.Card0.TabIndex = 0;
            this.Card0.UseVisualStyleBackColor = false;
            this.Card0.Visible = false;
            this.Card0.Click += new System.EventHandler(this.Card0_Click);
            // 
            // Mine
            // 
            this.Mine.AutoSize = true;
            this.Mine.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Mine.BackColor = System.Drawing.Color.DarkGreen;
            this.Mine.Cursor = System.Windows.Forms.Cursors.Default;
            this.Mine.ImageList = this.Baraja;
            this.Mine.Location = new System.Drawing.Point(324, 184);
            this.Mine.Margin = new System.Windows.Forms.Padding(5);
            this.Mine.MaximumSize = new System.Drawing.Size(100, 150);
            this.Mine.MinimumSize = new System.Drawing.Size(100, 150);
            this.Mine.Name = "Mine";
            this.Mine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Mine.Size = new System.Drawing.Size(100, 150);
            this.Mine.TabIndex = 5;
            this.Mine.UseVisualStyleBackColor = false;
            this.Mine.Visible = false;
            // 
            // Enemy
            // 
            this.Enemy.AutoSize = true;
            this.Enemy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Enemy.BackColor = System.Drawing.Color.DarkGreen;
            this.Enemy.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Enemy.ImageList = this.Baraja;
            this.Enemy.Location = new System.Drawing.Point(324, 26);
            this.Enemy.Margin = new System.Windows.Forms.Padding(5);
            this.Enemy.MaximumSize = new System.Drawing.Size(100, 150);
            this.Enemy.MinimumSize = new System.Drawing.Size(100, 150);
            this.Enemy.Name = "Enemy";
            this.Enemy.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Enemy.Size = new System.Drawing.Size(100, 150);
            this.Enemy.TabIndex = 6;
            this.Enemy.UseVisualStyleBackColor = false;
            this.Enemy.Visible = false;
            // 
            // MyPts
            // 
            this.MyPts.AutoSize = true;
            this.MyPts.BackColor = System.Drawing.Color.Transparent;
            this.MyPts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyPts.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.MyPts.Location = new System.Drawing.Point(621, 412);
            this.MyPts.Name = "MyPts";
            this.MyPts.Size = new System.Drawing.Size(15, 16);
            this.MyPts.TabIndex = 7;
            this.MyPts.Text = "0";
            // 
            // EnemyPts
            // 
            this.EnemyPts.AutoSize = true;
            this.EnemyPts.BackColor = System.Drawing.Color.Transparent;
            this.EnemyPts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemyPts.ForeColor = System.Drawing.Color.Firebrick;
            this.EnemyPts.Location = new System.Drawing.Point(621, 38);
            this.EnemyPts.Name = "EnemyPts";
            this.EnemyPts.Size = new System.Drawing.Size(15, 16);
            this.EnemyPts.TabIndex = 8;
            this.EnemyPts.Text = "0";
            // 
            // MyMarcador
            // 
            this.MyMarcador.AutoSize = true;
            this.MyMarcador.BackColor = System.Drawing.Color.Transparent;
            this.MyMarcador.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyMarcador.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.MyMarcador.Location = new System.Drawing.Point(11, 339);
            this.MyMarcador.Name = "MyMarcador";
            this.MyMarcador.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MyMarcador.Size = new System.Drawing.Size(32, 33);
            this.MyMarcador.TabIndex = 9;
            this.MyMarcador.Text = "0";
            // 
            // EnemyMacarcador
            // 
            this.EnemyMacarcador.AutoSize = true;
            this.EnemyMacarcador.BackColor = System.Drawing.Color.Transparent;
            this.EnemyMacarcador.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemyMacarcador.ForeColor = System.Drawing.Color.Firebrick;
            this.EnemyMacarcador.ImageList = this.Assets;
            this.EnemyMacarcador.Location = new System.Drawing.Point(9, 146);
            this.EnemyMacarcador.Name = "EnemyMacarcador";
            this.EnemyMacarcador.Size = new System.Drawing.Size(32, 33);
            this.EnemyMacarcador.TabIndex = 10;
            this.EnemyMacarcador.Text = "0";
            // 
            // Assets
            // 
            this.Assets.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Assets.ImageStream")));
            this.Assets.TransparentColor = System.Drawing.Color.Transparent;
            this.Assets.Images.SetKeyName(0, "binding_dark.png");
            this.Assets.Images.SetKeyName(1, "binding_light.png");
            this.Assets.Images.SetKeyName(2, "black_twill.png");
            this.Assets.Images.SetKeyName(3, "Button.png");
            this.Assets.Images.SetKeyName(4, "Button2.png");
            this.Assets.Images.SetKeyName(5, "Button3.png");
            // 
            // MyTruco
            // 
            this.MyTruco.AutoSize = true;
            this.MyTruco.BackColor = System.Drawing.Color.Transparent;
            this.MyTruco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyTruco.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.MyTruco.Location = new System.Drawing.Point(363, 372);
            this.MyTruco.Name = "MyTruco";
            this.MyTruco.Size = new System.Drawing.Size(18, 20);
            this.MyTruco.TabIndex = 11;
            this.MyTruco.Text = "0";
            // 
            // EnemyTruco
            // 
            this.EnemyTruco.AutoSize = true;
            this.EnemyTruco.BackColor = System.Drawing.Color.Transparent;
            this.EnemyTruco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemyTruco.ForeColor = System.Drawing.Color.Firebrick;
            this.EnemyTruco.Location = new System.Drawing.Point(364, 1);
            this.EnemyTruco.Name = "EnemyTruco";
            this.EnemyTruco.Size = new System.Drawing.Size(18, 20);
            this.EnemyTruco.TabIndex = 12;
            this.EnemyTruco.Text = "0";
            // 
            // PtsML
            // 
            this.PtsML.AutoSize = true;
            this.PtsML.BackColor = System.Drawing.Color.Transparent;
            this.PtsML.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PtsML.Location = new System.Drawing.Point(585, 372);
            this.PtsML.Name = "PtsML";
            this.PtsML.Size = new System.Drawing.Size(86, 23);
            this.PtsML.TabIndex = 15;
            this.PtsML.Text = "PUNTOS";
            // 
            // PtsEL
            // 
            this.PtsEL.AutoSize = true;
            this.PtsEL.BackColor = System.Drawing.Color.Transparent;
            this.PtsEL.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PtsEL.Location = new System.Drawing.Point(585, 1);
            this.PtsEL.Name = "PtsEL";
            this.PtsEL.Size = new System.Drawing.Size(86, 23);
            this.PtsEL.TabIndex = 16;
            this.PtsEL.Text = "PUNTOS";
            // 
            // TrucoB
            // 
            this.TrucoB.Enabled = false;
            this.TrucoB.ForeColor = System.Drawing.Color.DarkGray;
            this.TrucoB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TrucoB.ImageKey = "black_twill.png";
            this.TrucoB.ImageList = this.Assets;
            this.TrucoB.Location = new System.Drawing.Point(46, 441);
            this.TrucoB.Name = "TrucoB";
            this.TrucoB.Size = new System.Drawing.Size(105, 23);
            this.TrucoB.TabIndex = 14;
            this.TrucoB.Text = "Truco";
            this.TrucoB.UseVisualStyleBackColor = true;
            this.TrucoB.Visible = false;
            this.TrucoB.Click += new System.EventHandler(this.TrucoB_Click);
            // 
            // EnvidoB
            // 
            this.EnvidoB.Enabled = false;
            this.EnvidoB.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.EnvidoB.FlatAppearance.BorderSize = 0;
            this.EnvidoB.ForeColor = System.Drawing.Color.DarkGray;
            this.EnvidoB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EnvidoB.ImageIndex = 2;
            this.EnvidoB.ImageList = this.Assets;
            this.EnvidoB.Location = new System.Drawing.Point(46, 412);
            this.EnvidoB.Margin = new System.Windows.Forms.Padding(0);
            this.EnvidoB.Name = "EnvidoB";
            this.EnvidoB.Size = new System.Drawing.Size(105, 23);
            this.EnvidoB.TabIndex = 13;
            this.EnvidoB.Text = "Envido";
            this.EnvidoB.UseVisualStyleBackColor = true;
            this.EnvidoB.Visible = false;
            this.EnvidoB.Click += new System.EventHandler(this.EnvidoB_Click);
            // 
            // MazoB
            // 
            this.MazoB.AutoSize = true;
            this.MazoB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MazoB.BackColor = System.Drawing.Color.DarkGreen;
            this.MazoB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MazoB.ImageKey = "Downside.png";
            this.MazoB.ImageList = this.Baraja;
            this.MazoB.Location = new System.Drawing.Point(5, 184);
            this.MazoB.Margin = new System.Windows.Forms.Padding(5);
            this.MazoB.MaximumSize = new System.Drawing.Size(100, 150);
            this.MazoB.MinimumSize = new System.Drawing.Size(100, 150);
            this.MazoB.Name = "MazoB";
            this.MazoB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MazoB.Size = new System.Drawing.Size(100, 150);
            this.MazoB.TabIndex = 4;
            this.MazoB.UseVisualStyleBackColor = false;
            this.MazoB.Click += new System.EventHandler(this.Mazo_Click);
            // 
            // RendirseB
            // 
            this.RendirseB.Enabled = false;
            this.RendirseB.ForeColor = System.Drawing.Color.DarkGray;
            this.RendirseB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RendirseB.ImageKey = "black_twill.png";
            this.RendirseB.ImageList = this.Assets;
            this.RendirseB.Location = new System.Drawing.Point(46, 470);
            this.RendirseB.Name = "RendirseB";
            this.RendirseB.Size = new System.Drawing.Size(105, 23);
            this.RendirseB.TabIndex = 17;
            this.RendirseB.Text = "Ir al mazo";
            this.RendirseB.UseVisualStyleBackColor = true;
            this.RendirseB.Visible = false;
            this.RendirseB.Click += new System.EventHandler(this.RendirseB_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // MensajeL
            // 
            this.MensajeL.Font = new System.Drawing.Font("Ravie", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MensajeL.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.MensajeL.Location = new System.Drawing.Point(477, 150);
            this.MensajeL.Name = "MensajeL";
            this.MensajeL.Size = new System.Drawing.Size(219, 138);
            this.MensajeL.TabIndex = 18;
            this.MensajeL.Text = "Punto";
            this.MensajeL.Visible = false;
            // 
            // AceptoB
            // 
            this.AceptoB.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AceptoB.ImageIndex = 5;
            this.AceptoB.ImageList = this.Assets;
            this.AceptoB.Location = new System.Drawing.Point(226, 349);
            this.AceptoB.Name = "AceptoB";
            this.AceptoB.Size = new System.Drawing.Size(75, 23);
            this.AceptoB.TabIndex = 19;
            this.AceptoB.Text = "Acepto";
            this.AceptoB.UseVisualStyleBackColor = true;
            this.AceptoB.Visible = false;
            this.AceptoB.Click += new System.EventHandler(this.AceptoB_Click);
            // 
            // ElevoB
            // 
            this.ElevoB.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ElevoB.ImageIndex = 5;
            this.ElevoB.ImageList = this.Assets;
            this.ElevoB.Location = new System.Drawing.Point(339, 349);
            this.ElevoB.Name = "ElevoB";
            this.ElevoB.Size = new System.Drawing.Size(75, 23);
            this.ElevoB.TabIndex = 20;
            this.ElevoB.Text = "Elevo";
            this.ElevoB.UseVisualStyleBackColor = true;
            this.ElevoB.Visible = false;
            this.ElevoB.Click += new System.EventHandler(this.ElevoB_Click);
            // 
            // RechazoB
            // 
            this.RechazoB.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RechazoB.ImageIndex = 5;
            this.RechazoB.ImageList = this.Assets;
            this.RechazoB.Location = new System.Drawing.Point(447, 349);
            this.RechazoB.Name = "RechazoB";
            this.RechazoB.Size = new System.Drawing.Size(75, 23);
            this.RechazoB.TabIndex = 21;
            this.RechazoB.Text = "Rechazo";
            this.RechazoB.UseVisualStyleBackColor = true;
            this.RechazoB.Visible = false;
            this.RechazoB.Click += new System.EventHandler(this.RechazoB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(724, 573);
            this.Controls.Add(this.RechazoB);
            this.Controls.Add(this.ElevoB);
            this.Controls.Add(this.AceptoB);
            this.Controls.Add(this.MensajeL);
            this.Controls.Add(this.RendirseB);
            this.Controls.Add(this.PtsEL);
            this.Controls.Add(this.PtsML);
            this.Controls.Add(this.TrucoB);
            this.Controls.Add(this.EnvidoB);
            this.Controls.Add(this.EnemyTruco);
            this.Controls.Add(this.MyTruco);
            this.Controls.Add(this.EnemyMacarcador);
            this.Controls.Add(this.MyMarcador);
            this.Controls.Add(this.EnemyPts);
            this.Controls.Add(this.MyPts);
            this.Controls.Add(this.Enemy);
            this.Controls.Add(this.Mine);
            this.Controls.Add(this.MazoB);
            this.Controls.Add(this.Vira);
            this.Controls.Add(this.Card2);
            this.Controls.Add(this.Card1);
            this.Controls.Add(this.Card0);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Card0;
        private System.Windows.Forms.ImageList Baraja;
        private System.Windows.Forms.Button Card1;
        private System.Windows.Forms.Button Card2;
        private System.Windows.Forms.Button Vira;
        private System.Windows.Forms.Button MazoB;
        private System.Windows.Forms.Button Mine;
        private System.Windows.Forms.Button Enemy;
        private System.Windows.Forms.Label MyPts;
        private System.Windows.Forms.Label EnemyPts;
        private System.Windows.Forms.Label MyMarcador;
        private System.Windows.Forms.Label EnemyMacarcador;
        private System.Windows.Forms.Label MyTruco;
        private System.Windows.Forms.Label EnemyTruco;
        private System.Windows.Forms.ImageList Assets;
        private System.Windows.Forms.Button EnvidoB;
        private System.Windows.Forms.Button TrucoB;
        private System.Windows.Forms.Label PtsML;
        private System.Windows.Forms.Label PtsEL;
        private System.Windows.Forms.Button RendirseB;
        private System.IO.Ports.SerialPort serialPort1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Label MensajeL;
        private System.Windows.Forms.Button AceptoB;
        private System.Windows.Forms.Button ElevoB;
        private System.Windows.Forms.Button RechazoB;
    }
}

