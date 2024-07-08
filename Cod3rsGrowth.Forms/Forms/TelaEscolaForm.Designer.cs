namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaEscolaForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewEscolas = new DataGridView();
            painelLateral = new Panel();
            panel1 = new Panel();
            botaoPesquisar = new Button();
            panelBotaoFiltrar = new Panel();
            botaoFiltros = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEscolas).BeginInit();
            painelLateral.SuspendLayout();
            panel1.SuspendLayout();
            panelBotaoFiltrar.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewEscolas
            // 
            dataGridViewEscolas.BackgroundColor = Color.Blue;
            dataGridViewEscolas.BorderStyle = BorderStyle.None;
            dataGridViewEscolas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Blue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewEscolas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewEscolas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEscolas.EnableHeadersVisualStyles = false;
            dataGridViewEscolas.GridColor = Color.White;
            dataGridViewEscolas.Location = new Point(165, 12);
            dataGridViewEscolas.Name = "dataGridViewEscolas";
            dataGridViewEscolas.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewEscolas.RowTemplate.Height = 25;
            dataGridViewEscolas.Size = new Size(623, 299);
            dataGridViewEscolas.TabIndex = 2;
            dataGridViewEscolas.CellFormatting += AoFormatarCelulas_dataGridViewEscolas;
            // 
            // painelLateral
            // 
            painelLateral.BackColor = Color.DarkGray;
            painelLateral.Controls.Add(panel1);
            painelLateral.Controls.Add(panelBotaoFiltrar);
            painelLateral.Dock = DockStyle.Left;
            painelLateral.Location = new Point(0, 0);
            painelLateral.Name = "painelLateral";
            painelLateral.Size = new Size(164, 323);
            painelLateral.TabIndex = 1;
            painelLateral.Paint += AoRequererPintura_painelLateral;
            // 
            // panel1
            // 
            panel1.Controls.Add(botaoPesquisar);
            panel1.Location = new Point(12, 231);
            panel1.Name = "panel1";
            panel1.Size = new Size(133, 57);
            panel1.TabIndex = 36;
            panel1.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoPesquisar
            // 
            botaoPesquisar.BackColor = Color.Green;
            botaoPesquisar.FlatAppearance.BorderSize = 0;
            botaoPesquisar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoPesquisar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoPesquisar.FlatStyle = FlatStyle.Flat;
            botaoPesquisar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoPesquisar.ForeColor = Color.White;
            botaoPesquisar.Location = new Point(3, 3);
            botaoPesquisar.Name = "botaoPesquisar";
            botaoPesquisar.Size = new Size(112, 44);
            botaoPesquisar.TabIndex = 31;
            botaoPesquisar.Text = "Pesquisar";
            botaoPesquisar.UseVisualStyleBackColor = false;
            botaoPesquisar.Click += botaoPesquisar_Click;
            // 
            // panelBotaoFiltrar
            // 
            panelBotaoFiltrar.Controls.Add(botaoFiltros);
            panelBotaoFiltrar.Location = new Point(12, 21);
            panelBotaoFiltrar.Name = "panelBotaoFiltrar";
            panelBotaoFiltrar.Size = new Size(133, 57);
            panelBotaoFiltrar.TabIndex = 35;
            panelBotaoFiltrar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoFiltros
            // 
            botaoFiltros.BackColor = Color.Green;
            botaoFiltros.FlatAppearance.BorderSize = 0;
            botaoFiltros.FlatAppearance.MouseDownBackColor = Color.White;
            botaoFiltros.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoFiltros.FlatStyle = FlatStyle.Flat;
            botaoFiltros.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoFiltros.ForeColor = Color.White;
            botaoFiltros.Location = new Point(3, 3);
            botaoFiltros.Name = "botaoFiltros";
            botaoFiltros.Size = new Size(112, 44);
            botaoFiltros.TabIndex = 31;
            botaoFiltros.Text = "Filtros";
            botaoFiltros.UseVisualStyleBackColor = false;
            botaoFiltros.Click += AoClicar_botaoFiltros;
            // 
            // TelaEscolaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Blue;
            ClientSize = new Size(800, 323);
            Controls.Add(dataGridViewEscolas);
            Controls.Add(painelLateral);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaEscolaForm";
            Text = "TelaConvenioForm";
            Load += AoCarregar_TelaConvenioForm;
            VisibleChanged += AoMudarVisibilidade_TelaEscolaForm;
            Paint += AoRequererPintura_TelaConvenioForm;
            ((System.ComponentModel.ISupportInitialize)dataGridViewEscolas).EndInit();
            painelLateral.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelBotaoFiltrar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel painelLateral;
        private DataGridView dataGridViewEscolas;
        private Panel panelBotaoFiltrar;
        private Button botaoFiltros;
        private Panel panel1;
        private Button botaoPesquisar;
    }
}