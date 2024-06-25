namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaPrincipalForm
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button3 = new Button();
            barraLateral = new FlowLayoutPanel();
            panel3 = new Panel();
            panel2 = new Panel();
            botaoConvenios = new Button();
            botaoEmpresas = new Button();
            botaoEscolas = new Button();
            botaoEnderecos = new Button();
            Header = new Panel();
            panel1 = new Panel();
            minimizar = new Button();
            redimensionar = new Button();
            sair = new Button();
            barraLateralTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            barraLateral.SuspendLayout();
            Header.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(459, 231);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(341, 217);
            dataGridView1.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ControlLight;
            button1.Location = new Point(621, 137);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Criar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.MenuHighlight;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = SystemColors.ControlLight;
            button3.Location = new Point(713, 137);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 6;
            button3.Text = "Deletar";
            button3.UseVisualStyleBackColor = false;
            // 
            // barraLateral
            // 
            barraLateral.BackColor = SystemColors.ActiveBorder;
            barraLateral.Controls.Add(panel3);
            barraLateral.Controls.Add(panel2);
            barraLateral.Controls.Add(botaoConvenios);
            barraLateral.Controls.Add(botaoEmpresas);
            barraLateral.Controls.Add(botaoEscolas);
            barraLateral.Controls.Add(botaoEnderecos);
            barraLateral.Dock = DockStyle.Left;
            barraLateral.Location = new Point(0, 0);
            barraLateral.Margin = new Padding(0);
            barraLateral.MaximumSize = new Size(194, 450);
            barraLateral.MinimumSize = new Size(51, 450);
            barraLateral.Name = "barraLateral";
            barraLateral.Size = new Size(51, 450);
            barraLateral.TabIndex = 8;
            barraLateral.Paint += barraLateral_Paint;
            barraLateral.MouseEnter += barraLateral_MouseEnter_1;
            barraLateral.MouseLeave += barraLateral_MouseLeave;
            barraLateral.MouseHover += barraLateral_MouseHover_1;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(191, 144);
            panel3.TabIndex = 10;
            panel3.MouseEnter += panel3_MouseEnter;
            panel3.MouseLeave += barraLateral_MouseLeave;
            panel3.MouseHover += barraLateral_MouseHover_1;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(3, 147);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 0);
            panel2.TabIndex = 10;
            // 
            // botaoConvenios
            // 
            botaoConvenios.BackColor = SystemColors.ButtonFace;
            botaoConvenios.Dock = DockStyle.Top;
            botaoConvenios.FlatAppearance.BorderSize = 0;
            botaoConvenios.FlatStyle = FlatStyle.Flat;
            botaoConvenios.Location = new Point(0, 150);
            botaoConvenios.Margin = new Padding(0);
            botaoConvenios.Name = "botaoConvenios";
            botaoConvenios.Size = new Size(189, 33);
            botaoConvenios.TabIndex = 12;
            botaoConvenios.Text = "Convenios";
            botaoConvenios.UseVisualStyleBackColor = false;
            botaoConvenios.MouseEnter += botaoConvenios_MouseEnter;
            botaoConvenios.MouseLeave += barraLateral_MouseLeave;
            botaoConvenios.MouseHover += barraLateral_MouseHover_1;
            // 
            // botaoEmpresas
            // 
            botaoEmpresas.BackColor = SystemColors.ButtonFace;
            botaoEmpresas.Dock = DockStyle.Top;
            botaoEmpresas.FlatAppearance.BorderSize = 0;
            botaoEmpresas.FlatStyle = FlatStyle.Flat;
            botaoEmpresas.Location = new Point(0, 183);
            botaoEmpresas.Margin = new Padding(0);
            botaoEmpresas.Name = "botaoEmpresas";
            botaoEmpresas.Size = new Size(189, 33);
            botaoEmpresas.TabIndex = 13;
            botaoEmpresas.Text = "Empresas";
            botaoEmpresas.UseVisualStyleBackColor = false;
            botaoEmpresas.Click += botaoEmpresas_Click;
            botaoEmpresas.MouseEnter += botaoEmpresas_MouseEnter;
            botaoEmpresas.MouseLeave += barraLateral_MouseLeave;
            botaoEmpresas.MouseHover += barraLateral_MouseHover_1;
            // 
            // botaoEscolas
            // 
            botaoEscolas.BackColor = SystemColors.ButtonFace;
            botaoEscolas.Dock = DockStyle.Top;
            botaoEscolas.FlatAppearance.BorderSize = 0;
            botaoEscolas.FlatStyle = FlatStyle.Flat;
            botaoEscolas.Location = new Point(0, 216);
            botaoEscolas.Margin = new Padding(0);
            botaoEscolas.Name = "botaoEscolas";
            botaoEscolas.Size = new Size(189, 33);
            botaoEscolas.TabIndex = 14;
            botaoEscolas.Text = "Escolas";
            botaoEscolas.UseVisualStyleBackColor = false;
            botaoEscolas.Click += button4_Click_1;
            botaoEscolas.MouseEnter += botaoEscolas_MouseEnter;
            botaoEscolas.MouseLeave += barraLateral_MouseLeave;
            botaoEscolas.MouseHover += barraLateral_MouseHover_1;
            // 
            // botaoEnderecos
            // 
            botaoEnderecos.BackColor = SystemColors.ButtonFace;
            botaoEnderecos.Dock = DockStyle.Top;
            botaoEnderecos.FlatAppearance.BorderSize = 0;
            botaoEnderecos.FlatStyle = FlatStyle.Flat;
            botaoEnderecos.Location = new Point(0, 249);
            botaoEnderecos.Margin = new Padding(0);
            botaoEnderecos.Name = "botaoEnderecos";
            botaoEnderecos.Size = new Size(189, 33);
            botaoEnderecos.TabIndex = 15;
            botaoEnderecos.Text = "Endereços";
            botaoEnderecos.UseVisualStyleBackColor = false;
            botaoEnderecos.Click += botaoEnderecos_Click;
            botaoEnderecos.MouseEnter += botaoEnderecos_MouseEnter;
            botaoEnderecos.MouseLeave += barraLateral_MouseLeave;
            botaoEnderecos.MouseHover += barraLateral_MouseHover_1;
            // 
            // Header
            // 
            Header.BackColor = SystemColors.AppWorkspace;
            Header.Controls.Add(panel1);
            Header.Dock = DockStyle.Top;
            Header.Location = new Point(51, 0);
            Header.Name = "Header";
            Header.Size = new Size(749, 24);
            Header.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(minimizar);
            panel1.Controls.Add(redimensionar);
            panel1.Controls.Add(sair);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(662, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(87, 24);
            panel1.TabIndex = 0;
            // 
            // minimizar
            // 
            minimizar.BackColor = SystemColors.Control;
            minimizar.FlatStyle = FlatStyle.Popup;
            minimizar.Location = new Point(10, 3);
            minimizar.Name = "minimizar";
            minimizar.Size = new Size(18, 18);
            minimizar.TabIndex = 2;
            minimizar.UseVisualStyleBackColor = false;
            minimizar.Click += minimizar_Click;
            // 
            // redimensionar
            // 
            redimensionar.BackColor = SystemColors.Control;
            redimensionar.FlatStyle = FlatStyle.Popup;
            redimensionar.Location = new Point(34, 3);
            redimensionar.Name = "redimensionar";
            redimensionar.Size = new Size(18, 18);
            redimensionar.TabIndex = 1;
            redimensionar.UseVisualStyleBackColor = false;
            redimensionar.Click += button4_Click;
            // 
            // sair
            // 
            sair.BackColor = SystemColors.Control;
            sair.FlatStyle = FlatStyle.Popup;
            sair.Location = new Point(66, 3);
            sair.Name = "sair";
            sair.Size = new Size(18, 18);
            sair.TabIndex = 0;
            sair.UseVisualStyleBackColor = false;
            sair.Click += sair_Click;
            // 
            // barraLateralTimer
            // 
            barraLateralTimer.Interval = 10;
            barraLateralTimer.Tick += barraLateralTimer_Tick;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Header);
            Controls.Add(barraLateral);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaPrincipalForm";
            Text = "TelaPrincipalForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            barraLateral.ResumeLayout(false);
            Header.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private Button button1;
        private Button button3;
        private FlowLayoutPanel barraLateral;
        private Panel Header;
        private Panel panel1;
        private Button sair;
        private Button minimizar;
        private Button redimensionar;
        private Panel panel2;
        private Button botaoConvenios;
        private System.Windows.Forms.Timer barraLateralTimer;
        private Panel panel3;
        private Button botaoEmpresas;
        private Button botaoEscolas;
        private Button botaoEnderecos;
    }
}