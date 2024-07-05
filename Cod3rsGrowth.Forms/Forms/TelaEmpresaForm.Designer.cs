namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaEmpresaForm
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
            dataGridViewEmpresas = new DataGridView();
            painelLateral = new Panel();
            panel1 = new Panel();
            botaoPesquisar = new Button();
            panelBotaoFiltrar = new Panel();
            botaoFiltros = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpresas).BeginInit();
            painelLateral.SuspendLayout();
            panel1.SuspendLayout();
            panelBotaoFiltrar.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewEmpresas
            // 
            dataGridViewEmpresas.BackgroundColor = Color.Blue;
            dataGridViewEmpresas.BorderStyle = BorderStyle.None;
            dataGridViewEmpresas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Blue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewEmpresas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewEmpresas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmpresas.EnableHeadersVisualStyles = false;
            dataGridViewEmpresas.GridColor = Color.White;
            dataGridViewEmpresas.Location = new Point(165, 12);
            dataGridViewEmpresas.Name = "dataGridViewEmpresas";
            dataGridViewEmpresas.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewEmpresas.RowTemplate.Height = 25;
            dataGridViewEmpresas.Size = new Size(623, 299);
            dataGridViewEmpresas.TabIndex = 2;
            dataGridViewEmpresas.CellFormatting += AoFormatarCelula_dataGridViewEmpresas;
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
            panel1.Location = new Point(25, 234);
            panel1.Name = "panel1";
            panel1.Size = new Size(107, 67);
            panel1.TabIndex = 34;
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
            botaoPesquisar.Size = new Size(86, 54);
            botaoPesquisar.TabIndex = 31;
            botaoPesquisar.Text = "Pesquisar";
            botaoPesquisar.UseVisualStyleBackColor = false;
            botaoPesquisar.Click += AoClicar_botaoPesquisar;
            // 
            // panelBotaoFiltrar
            // 
            panelBotaoFiltrar.Controls.Add(botaoFiltros);
            panelBotaoFiltrar.Location = new Point(25, 23);
            panelBotaoFiltrar.Name = "panelBotaoFiltrar";
            panelBotaoFiltrar.Size = new Size(107, 67);
            panelBotaoFiltrar.TabIndex = 33;
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
            botaoFiltros.Size = new Size(86, 54);
            botaoFiltros.TabIndex = 31;
            botaoFiltros.Text = "Filtros";
            botaoFiltros.UseVisualStyleBackColor = false;
            botaoFiltros.Click += AoClicar_botaoFiltros;
            // 
            // TelaEmpresaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Blue;
            ClientSize = new Size(800, 323);
            Controls.Add(dataGridViewEmpresas);
            Controls.Add(painelLateral);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaEmpresaForm";
            Text = "TelaConvenioForm";
            Load += AoCarregar_TelaEmpresaForm;
            VisibleChanged += AoMudarVisibilidade_TelaEmpresaForm;
            Paint += AoRequererPintura_TelaEmpresaForm;
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpresas).EndInit();
            painelLateral.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelBotaoFiltrar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel painelLateral;
        private DataGridView dataGridViewEmpresas;
        private Panel panelBotaoFiltrar;
        private Button botaoFiltros;
        private Panel panel1;
        private Button botaoPesquisar;
    }
}