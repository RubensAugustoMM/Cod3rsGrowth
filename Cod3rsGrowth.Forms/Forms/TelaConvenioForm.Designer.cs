namespace Cod3rsGrowth.Forms.Forms
{
    partial class TelaConvenioForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewConvenios = new DataGridView();
            convenioEscolaEmpresaOtdBindingSource = new BindingSource(components);
            painelLateral = new Panel();
            panelBotaoDeletar = new Panel();
            botaoDeletar = new Button();
            panelBotaoEditar = new Panel();
            botaoEditar = new Button();
            panelBotaoCriar = new Panel();
            botaoCriar = new Button();
            panel1 = new Panel();
            botaoPesquisar = new Button();
            panelBotaoFiltros = new Panel();
            botaoFiltros = new Button();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            numeroProcessoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            objetoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataInicioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataTerminoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idEscolaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeEscolaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idEmpresaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            razaoSocialEmpresaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewConvenios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)convenioEscolaEmpresaOtdBindingSource).BeginInit();
            painelLateral.SuspendLayout();
            panelBotaoDeletar.SuspendLayout();
            panelBotaoEditar.SuspendLayout();
            panelBotaoCriar.SuspendLayout();
            panel1.SuspendLayout();
            panelBotaoFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewConvenios
            // 
            dataGridViewConvenios.AllowUserToAddRows = false;
            dataGridViewConvenios.AllowUserToDeleteRows = false;
            dataGridViewConvenios.AllowUserToOrderColumns = true;
            dataGridViewConvenios.AllowUserToResizeRows = false;
            dataGridViewConvenios.AutoGenerateColumns = false;
            dataGridViewConvenios.BackgroundColor = Color.Blue;
            dataGridViewConvenios.BorderStyle = BorderStyle.None;
            dataGridViewConvenios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Blue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewConvenios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewConvenios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewConvenios.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, numeroProcessoDataGridViewTextBoxColumn, objetoDataGridViewTextBoxColumn, valorDataGridViewTextBoxColumn, dataInicioDataGridViewTextBoxColumn, dataTerminoDataGridViewTextBoxColumn, idEscolaDataGridViewTextBoxColumn, nomeEscolaDataGridViewTextBoxColumn, idEmpresaDataGridViewTextBoxColumn, razaoSocialEmpresaDataGridViewTextBoxColumn });
            dataGridViewConvenios.DataSource = convenioEscolaEmpresaOtdBindingSource;
            dataGridViewConvenios.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewConvenios.EnableHeadersVisualStyles = false;
            dataGridViewConvenios.GridColor = Color.White;
            dataGridViewConvenios.Location = new Point(165, 12);
            dataGridViewConvenios.MultiSelect = false;
            dataGridViewConvenios.Name = "dataGridViewConvenios";
            dataGridViewConvenios.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewConvenios.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewConvenios.RowTemplate.Height = 25;
            dataGridViewConvenios.Size = new Size(623, 299);
            dataGridViewConvenios.TabIndex = 2;
            dataGridViewConvenios.VisibleChanged += AoMudarVisibilidade_dataGridView1;
            // 
            // convenioEscolaEmpresaOtdBindingSource
            // 
            convenioEscolaEmpresaOtdBindingSource.DataSource = typeof(Dominio.ObjetosTranferenciaDados.ConvenioEscolaEmpresaOtd);
            // 
            // painelLateral
            // 
            painelLateral.BackColor = Color.DarkGray;
            painelLateral.Controls.Add(panelBotaoDeletar);
            painelLateral.Controls.Add(panelBotaoEditar);
            painelLateral.Controls.Add(panelBotaoCriar);
            painelLateral.Controls.Add(panel1);
            painelLateral.Controls.Add(panelBotaoFiltros);
            painelLateral.Dock = DockStyle.Left;
            painelLateral.Location = new Point(0, 0);
            painelLateral.Name = "painelLateral";
            painelLateral.Size = new Size(164, 323);
            painelLateral.TabIndex = 1;
            painelLateral.Paint += AoRequererPintura_painelLateral;
            // 
            // panelBotaoDeletar
            // 
            panelBotaoDeletar.Controls.Add(botaoDeletar);
            panelBotaoDeletar.Location = new Point(12, 190);
            panelBotaoDeletar.Name = "panelBotaoDeletar";
            panelBotaoDeletar.Size = new Size(133, 49);
            panelBotaoDeletar.TabIndex = 35;
            panelBotaoDeletar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoDeletar
            // 
            botaoDeletar.BackColor = Color.Green;
            botaoDeletar.FlatAppearance.BorderSize = 0;
            botaoDeletar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoDeletar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoDeletar.FlatStyle = FlatStyle.Flat;
            botaoDeletar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoDeletar.ForeColor = Color.White;
            botaoDeletar.Location = new Point(3, 3);
            botaoDeletar.Name = "botaoDeletar";
            botaoDeletar.Size = new Size(112, 36);
            botaoDeletar.TabIndex = 31;
            botaoDeletar.Text = "Deletar";
            botaoDeletar.UseVisualStyleBackColor = false;
            // 
            // panelBotaoEditar
            // 
            panelBotaoEditar.Controls.Add(botaoEditar);
            panelBotaoEditar.Location = new Point(12, 135);
            panelBotaoEditar.Name = "panelBotaoEditar";
            panelBotaoEditar.Size = new Size(133, 49);
            panelBotaoEditar.TabIndex = 34;
            panelBotaoEditar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoEditar
            // 
            botaoEditar.BackColor = Color.Green;
            botaoEditar.FlatAppearance.BorderSize = 0;
            botaoEditar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoEditar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoEditar.FlatStyle = FlatStyle.Flat;
            botaoEditar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoEditar.ForeColor = Color.White;
            botaoEditar.Location = new Point(3, 3);
            botaoEditar.Name = "botaoEditar";
            botaoEditar.Size = new Size(112, 36);
            botaoEditar.TabIndex = 31;
            botaoEditar.Text = "Editar";
            botaoEditar.UseVisualStyleBackColor = false;
            // 
            // panelBotaoCriar
            // 
            panelBotaoCriar.Controls.Add(botaoCriar);
            panelBotaoCriar.Location = new Point(12, 80);
            panelBotaoCriar.Name = "panelBotaoCriar";
            panelBotaoCriar.Size = new Size(133, 49);
            panelBotaoCriar.TabIndex = 33;
            panelBotaoCriar.Paint += AoRequererPintura_panelSombraBotoes;
            // 
            // botaoCriar
            // 
            botaoCriar.BackColor = Color.Green;
            botaoCriar.FlatAppearance.BorderSize = 0;
            botaoCriar.FlatAppearance.MouseDownBackColor = Color.White;
            botaoCriar.FlatAppearance.MouseOverBackColor = Color.Yellow;
            botaoCriar.FlatStyle = FlatStyle.Flat;
            botaoCriar.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            botaoCriar.ForeColor = Color.White;
            botaoCriar.Location = new Point(3, 3);
            botaoCriar.Name = "botaoCriar";
            botaoCriar.Size = new Size(112, 36);
            botaoCriar.TabIndex = 31;
            botaoCriar.Text = "Criar";
            botaoCriar.UseVisualStyleBackColor = false;
            botaoCriar.Click += AoClicar_botaoCriar;
            // 
            // panel1
            // 
            panel1.Controls.Add(botaoPesquisar);
            panel1.Location = new Point(12, 245);
            panel1.Name = "panel1";
            panel1.Size = new Size(133, 49);
            panel1.TabIndex = 33;
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
            botaoPesquisar.Size = new Size(112, 36);
            botaoPesquisar.TabIndex = 31;
            botaoPesquisar.Text = "Pesquisar";
            botaoPesquisar.UseVisualStyleBackColor = false;
            botaoPesquisar.Click += AoClicar_botaoPesquisar;
            // 
            // panelBotaoFiltros
            // 
            panelBotaoFiltros.Controls.Add(botaoFiltros);
            panelBotaoFiltros.Location = new Point(12, 25);
            panelBotaoFiltros.Name = "panelBotaoFiltros";
            panelBotaoFiltros.Size = new Size(133, 49);
            panelBotaoFiltros.TabIndex = 32;
            panelBotaoFiltros.Paint += AoRequererPintura_panelSombraBotoes;
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
            botaoFiltros.Size = new Size(112, 36);
            botaoFiltros.TabIndex = 31;
            botaoFiltros.Text = "Filtros";
            botaoFiltros.UseVisualStyleBackColor = false;
            botaoFiltros.Click += AoClicar_botaoFiltros;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Código Convênio";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 114;
            // 
            // numeroProcessoDataGridViewTextBoxColumn
            // 
            numeroProcessoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            numeroProcessoDataGridViewTextBoxColumn.DataPropertyName = "NumeroProcesso";
            numeroProcessoDataGridViewTextBoxColumn.HeaderText = "Número do Processo";
            numeroProcessoDataGridViewTextBoxColumn.Name = "numeroProcessoDataGridViewTextBoxColumn";
            numeroProcessoDataGridViewTextBoxColumn.ReadOnly = true;
            numeroProcessoDataGridViewTextBoxColumn.Width = 130;
            // 
            // objetoDataGridViewTextBoxColumn
            // 
            objetoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            objetoDataGridViewTextBoxColumn.DataPropertyName = "Objeto";
            objetoDataGridViewTextBoxColumn.HeaderText = "Objeto";
            objetoDataGridViewTextBoxColumn.Name = "objetoDataGridViewTextBoxColumn";
            objetoDataGridViewTextBoxColumn.ReadOnly = true;
            objetoDataGridViewTextBoxColumn.Width = 67;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            valorDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            valorDataGridViewTextBoxColumn.ReadOnly = true;
            valorDataGridViewTextBoxColumn.Width = 57;
            // 
            // dataInicioDataGridViewTextBoxColumn
            // 
            dataInicioDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataInicioDataGridViewTextBoxColumn.DataPropertyName = "DataInicio";
            dataInicioDataGridViewTextBoxColumn.HeaderText = "Início";
            dataInicioDataGridViewTextBoxColumn.Name = "dataInicioDataGridViewTextBoxColumn";
            dataInicioDataGridViewTextBoxColumn.ReadOnly = true;
            dataInicioDataGridViewTextBoxColumn.Width = 60;
            // 
            // dataTerminoDataGridViewTextBoxColumn
            // 
            dataTerminoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataTerminoDataGridViewTextBoxColumn.DataPropertyName = "DataTermino";
            dataTerminoDataGridViewTextBoxColumn.HeaderText = "Término";
            dataTerminoDataGridViewTextBoxColumn.Name = "dataTerminoDataGridViewTextBoxColumn";
            dataTerminoDataGridViewTextBoxColumn.ReadOnly = true;
            dataTerminoDataGridViewTextBoxColumn.Width = 74;
            // 
            // idEscolaDataGridViewTextBoxColumn
            // 
            idEscolaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            idEscolaDataGridViewTextBoxColumn.DataPropertyName = "IdEscola";
            idEscolaDataGridViewTextBoxColumn.HeaderText = "Código Escola";
            idEscolaDataGridViewTextBoxColumn.Name = "idEscolaDataGridViewTextBoxColumn";
            idEscolaDataGridViewTextBoxColumn.ReadOnly = true;
            idEscolaDataGridViewTextBoxColumn.Width = 97;
            // 
            // nomeEscolaDataGridViewTextBoxColumn
            // 
            nomeEscolaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            nomeEscolaDataGridViewTextBoxColumn.DataPropertyName = "NomeEscola";
            nomeEscolaDataGridViewTextBoxColumn.HeaderText = "Nome Escola";
            nomeEscolaDataGridViewTextBoxColumn.Name = "nomeEscolaDataGridViewTextBoxColumn";
            nomeEscolaDataGridViewTextBoxColumn.ReadOnly = true;
            nomeEscolaDataGridViewTextBoxColumn.Width = 92;
            // 
            // idEmpresaDataGridViewTextBoxColumn
            // 
            idEmpresaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            idEmpresaDataGridViewTextBoxColumn.DataPropertyName = "IdEmpresa";
            idEmpresaDataGridViewTextBoxColumn.HeaderText = "Código Empresa";
            idEmpresaDataGridViewTextBoxColumn.Name = "idEmpresaDataGridViewTextBoxColumn";
            idEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            idEmpresaDataGridViewTextBoxColumn.Width = 108;
            // 
            // razaoSocialEmpresaDataGridViewTextBoxColumn
            // 
            razaoSocialEmpresaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            razaoSocialEmpresaDataGridViewTextBoxColumn.DataPropertyName = "RazaoSocialEmpresa";
            razaoSocialEmpresaDataGridViewTextBoxColumn.HeaderText = "Razão Social Empresa";
            razaoSocialEmpresaDataGridViewTextBoxColumn.Name = "razaoSocialEmpresaDataGridViewTextBoxColumn";
            razaoSocialEmpresaDataGridViewTextBoxColumn.ReadOnly = true;
            razaoSocialEmpresaDataGridViewTextBoxColumn.Width = 132;
            // 
            // TelaConvenioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Blue;
            ClientSize = new Size(800, 323);
            Controls.Add(dataGridViewConvenios);
            Controls.Add(painelLateral);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TelaConvenioForm";
            Text = "TelaConvenioForm";
            Load += AoCarregarForm_TelaConvenioForm;
            Paint += AoRequererPintura_TelaConvenioForm;
            ((System.ComponentModel.ISupportInitialize)dataGridViewConvenios).EndInit();
            ((System.ComponentModel.ISupportInitialize)convenioEscolaEmpresaOtdBindingSource).EndInit();
            painelLateral.ResumeLayout(false);
            panelBotaoDeletar.ResumeLayout(false);
            panelBotaoEditar.ResumeLayout(false);
            panelBotaoCriar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelBotaoFiltros.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel painelLateral;
        private Button botaoFiltros;
        private DataGridView dataGridViewConvenios;
        private Panel panelBotaoFiltros;
        private Panel panel1;
        private Button botaoPesquisar;
        private Panel panelBotaoDeletar;
        private Button botaoDeletar;
        private Panel panelBotaoEditar;
        private Button botaoEditar;
        private Panel panelBotaoCriar;
        private Button botaoCriar;
        private BindingSource convenioEscolaEmpresaOtdBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numeroProcessoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn objetoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataInicioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataTerminoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idEscolaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeEscolaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idEmpresaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn razaoSocialEmpresaDataGridViewTextBoxColumn;
    }
}