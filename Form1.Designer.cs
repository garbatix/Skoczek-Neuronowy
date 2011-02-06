namespace Skoczek_Neuronowy
{
    partial class Okienko
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
            this.panel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.kontrBok = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.kontrPauza = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.butStop = new System.Windows.Forms.Button();
            this.checkKlik = new System.Windows.Forms.CheckBox();
            this.checkStany = new System.Windows.Forms.CheckBox();
            this.checkRuchy = new System.Windows.Forms.CheckBox();
            this.checkSciezkaH = new System.Windows.Forms.CheckBox();
            this.checkCyklH = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusBarText1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarTextCzas = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kontrBok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kontrPauza)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel.Location = new System.Drawing.Point(614, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(300, 300);
            this.panel.TabIndex = 0;
            this.panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(362, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(344, 261);
            this.textBox1.TabIndex = 4;
            // 
            // kontrBok
            // 
            this.kontrBok.Location = new System.Drawing.Point(461, 12);
            this.kontrBok.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.kontrBok.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.kontrBok.Name = "kontrBok";
            this.kontrBok.Size = new System.Drawing.Size(46, 20);
            this.kontrBok.TabIndex = 5;
            this.kontrBok.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.kontrBok.ValueChanged += new System.EventHandler(this.kontrBok_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(513, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bok szachownicy";
            // 
            // kontrPauza
            // 
            this.kontrPauza.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.kontrPauza.Location = new System.Drawing.Point(372, 283);
            this.kontrPauza.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.kontrPauza.Name = "kontrPauza";
            this.kontrPauza.Size = new System.Drawing.Size(46, 20);
            this.kontrPauza.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Opóźnienie";
            // 
            // butStop
            // 
            this.butStop.Enabled = false;
            this.butStop.Location = new System.Drawing.Point(362, 12);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(75, 23);
            this.butStop.TabIndex = 10;
            this.butStop.Text = "Zatrzymaj";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Visible = false;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // checkKlik
            // 
            this.checkKlik.AutoSize = true;
            this.checkKlik.Location = new System.Drawing.Point(12, 309);
            this.checkKlik.Name = "checkKlik";
            this.checkKlik.Size = new System.Drawing.Size(231, 17);
            this.checkKlik.TabIndex = 12;
            this.checkKlik.Text = "następny krok po kliknięciu w szachownicę";
            this.checkKlik.UseVisualStyleBackColor = true;
            // 
            // checkStany
            // 
            this.checkStany.AutoSize = true;
            this.checkStany.Location = new System.Drawing.Point(12, 286);
            this.checkStany.Name = "checkStany";
            this.checkStany.Size = new System.Drawing.Size(91, 17);
            this.checkStany.TabIndex = 14;
            this.checkStany.Text = "pokazuj stany";
            this.checkStany.UseVisualStyleBackColor = true;
            // 
            // checkRuchy
            // 
            this.checkRuchy.AutoSize = true;
            this.checkRuchy.Location = new System.Drawing.Point(372, 309);
            this.checkRuchy.Name = "checkRuchy";
            this.checkRuchy.Size = new System.Drawing.Size(154, 17);
            this.checkRuchy.TabIndex = 15;
            this.checkRuchy.Text = "rysuj wszystkie zmiany sieci";
            this.checkRuchy.UseVisualStyleBackColor = true;
            // 
            // checkSciezkaH
            // 
            this.checkSciezkaH.AutoSize = true;
            this.checkSciezkaH.Checked = true;
            this.checkSciezkaH.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSciezkaH.Location = new System.Drawing.Point(461, 38);
            this.checkSciezkaH.Name = "checkSciezkaH";
            this.checkSciezkaH.Size = new System.Drawing.Size(112, 17);
            this.checkSciezkaH.TabIndex = 16;
            this.checkSciezkaH.Text = "ścieżka Hamiltona";
            this.checkSciezkaH.UseVisualStyleBackColor = true;
            // 
            // checkCyklH
            // 
            this.checkCyklH.AutoSize = true;
            this.checkCyklH.Location = new System.Drawing.Point(461, 61);
            this.checkCyklH.Name = "checkCyklH";
            this.checkCyklH.Size = new System.Drawing.Size(95, 17);
            this.checkCyklH.TabIndex = 17;
            this.checkCyklH.Text = "cykl Hamiltona";
            this.checkCyklH.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Wyświetlanie:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarText1,
            this.StatusBarTextCzas});
            this.statusStrip1.Location = new System.Drawing.Point(0, 338);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(926, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusBarText1
            // 
            this.StatusBarText1.Name = "StatusBarText1";
            this.StatusBarText1.Size = new System.Drawing.Size(48, 17);
            this.StatusBarText1.Text = "Gotowy";
            // 
            // StatusBarTextCzas
            // 
            this.StatusBarTextCzas.Name = "StatusBarTextCzas";
            this.StatusBarTextCzas.Size = new System.Drawing.Size(0, 17);
            // 
            // Okienko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 360);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkCyklH);
            this.Controls.Add(this.checkSciezkaH);
            this.Controls.Add(this.checkRuchy);
            this.Controls.Add(this.checkStany);
            this.Controls.Add(this.checkKlik);
            this.Controls.Add(this.butStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kontrPauza);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kontrBok);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel);
            this.Name = "Okienko";
            this.Text = "Skoczek Neuronowy";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kontrBok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kontrPauza)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown kontrBok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown kontrPauza;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.CheckBox checkKlik;
        private System.Windows.Forms.CheckBox checkStany;
        private System.Windows.Forms.CheckBox checkRuchy;
        private System.Windows.Forms.CheckBox checkSciezkaH;
        private System.Windows.Forms.CheckBox checkCyklH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarText1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarTextCzas;
    }
}