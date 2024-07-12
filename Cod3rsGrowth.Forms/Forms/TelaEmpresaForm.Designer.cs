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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewEmpresas = new DataGridView();
            empresaEnderecoOtdBindingSource = new BindingSource(components);
            painelLateral = new Panel();
            panelBotaoDeletar = new Panel();
            botaoDeletar = new Button();
            panel1 = new Panel();
            botaoPesquisar = new Button();
            panelBotaoEditar = new Panel();
            botaoEditar = new Button();
            panelBotaoFiltrar = new Panel();
            botaoFiltros = new Button();
            panelBotaoCriar = new Panel();
            botaoCriar = new Button();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            razaoSocialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeFantasiaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cnpjDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            situcaoCadastralDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            dataSituacaoCadastralDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataAberturaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            naturezaJuridicaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            porteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            matrizFilialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            capitalSocialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idEnderecoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpresas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)empresaEnderecoOtdBindingSource).BeginInit();
            painelLateral.SuspendLayout();
            panelBotaoDeletar.SuspendLayout();
            panel1.SuspendLayout();
            panelBotaoEditar.SuspendLayout();
            panelBotaoFiltrar.SuspendLayout();
            panelBotaoCriar.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewEmpresas
            // 
            dataGridViewEmpresas.AllowUserToAddRows = false;
            dataGridViewEmpresas.AllowUserToDeleteRows = false;
            dataGridViewEmpresas.AllowUserToOrderColumns = true;
            dataGridViewEmpresas.AllowUserToResizeRows = false;
            dataGridViewEmpresas.AutoGenerateColumns = false;
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
            dataGridViewEmpresas.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, razaoSocialDataGridViewTextBoxColumn, nomeFantasiaDataGridViewTextBoxColumn, cnpjDataGridViewTextBoxColumn, situcaoCadastralDataGridViewCheckBoxColumn, dataSituacaoCadastralDataGridViewTextBoxColumn, idadeDataGridViewTextBoxColumn, dataAberturaDataGridViewTextBoxColumn, naturezaJuridicaDataGridViewTextBoxColumn, porteDataGridViewTextBoxColumn, matrizFilialDataGridViewTextBoxColumn, capitalSocialDataGridViewTextBoxColumn, idEnderecoDataGridViewTextBoxColumn, estadoDataGridViewTextBoxColumn });
            dataGridViewEmpresas.DataSource = empresaEnderecoOtdBindingSource;
            dataGridViewEmpresas.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewEmpresas.EnableHeadersVisualStyles = false;
            dataGridViewEmpresas.GridColor = Color.White;
            dataGridViewEmpresas.Location = new Point(165, 12);
            dataGridViewEmpresas.Name = "dataGridViewEmpresas";
            dataGridViewEmpresas.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewEmpresas.RowTemplate.Height = 25;
            dataGridViewEmpresas.Size = new Size(623, 299);
            dataGridViewEmpresas.TabIndex = 2;
            dataGridViewEmpresas.CellFormatting += AoFormatarCelulas_dataGridViewEmpresas;
            // 
            // empresaEnderecoOtdBindingSource
            // 
            empresaEnderecoOtdBindingSource.DataSource = typeof(Dominio.ObjetosTranferenciaDados.EmpresaEnderecoOtd);
            // 
            // painelLateral
            // 
            painelLateral.BackColor = Color.DarkGray;
            painelLateral.Controls.Add(panelBotaoDeletar);
            painelLateral.Controls.Add(panel1);
            painelLateral.Controls.Add(panelBotaoEditar);
            painelLateral.Controls.Add(panelBotaoFiltrar);
            painelLateral.Controls.Add(panelBotaoCriar);
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
            panelBotaoDeletar.Location = new Point(12, 177);
            panelBotaoDeletar.Name = "panelBotaoDeletar";
            panelBotaoDeletar.Size = new Size(133, 49);
            panelBotaoDeletar.TabIndex = 38;
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
            // panel1
            // 
            panel1.Controls.Add(botaoPesquisar);
            panel1.Location = new Point(12, 232);
            panel1.Name = "panel1";
            panel1.Size = new Size(133, 49);
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
            botaoPesquisar.Size = new Size(112, 36);
            botaoPesquisar.TabIndex = 31;
            botaoPesquisar.Text = "Pesquisar";
            botaoPesquisar.UseVisualStyleBackColor = false;
            botaoPesquisar.Click += AoClicar_botaoPesquisar;
            // 
            // panelBotaoEditar
            // 
            panelBotaoEditar.Controls.Add(botaoEditar);
            panelBotaoEditar.Location = new Point(12, 122);
            panelBotaoEditar.Name = "panelBotaoEditar";
            panelBotaoEditar.Size = new Size(133, 49);
            panelBotaoEditar.TabIndex = 37;
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
            // panelBotaoFiltrar
            // 
            panelBotaoFiltrar.Controls.Add(botaoFiltros);
            panelBotaoFiltrar.Location = new Point(12, 12);
            panelBotaoFiltrar.Name = "panelBotaoFiltrar";
            panelBotaoFiltrar.Size = new Size(133, 49);
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
            botaoFiltros.Size = new Size(112, 36);
            botaoFiltros.TabIndex = 31;
            botaoFiltros.Text = "Filtros";
            botaoFiltros.UseVisualStyleBackColor = false;
            botaoFiltros.Click += AoClicar_botaoFiltros;
            // 
            // panelBotaoCriar
            // 
            panelBotaoCriar.Controls.Add(botaoCriar);
            panelBotaoCriar.Location = new Point(12, 67);
            panelBotaoCriar.Name = "panelBotaoCriar";
            panelBotaoCriar.Size = new Size(133, 49);
            panelBotaoCriar.TabIndex = 36;
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
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Código Empresa";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 108;
            // 
            // razaoSocialDataGridViewTextBoxColumn
            // 
            razaoSocialDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            razaoSocialDataGridViewTextBoxColumn.DataPropertyName = "RazaoSocial";
            razaoSocialDataGridViewTextBoxColumn.HeaderText = "Razão Social";
            razaoSocialDataGridViewTextBoxColumn.Name = "razaoSocialDataGridViewTextBoxColumn";
            razaoSocialDataGridViewTextBoxColumn.ReadOnly = true;
            razaoSocialDataGridViewTextBoxColumn.Width = 88;
            // 
            // nomeFantasiaDataGridViewTextBoxColumn
            // 
            nomeFantasiaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            nomeFantasiaDataGridViewTextBoxColumn.DataPropertyName = "NomeFantasia";
            nomeFantasiaDataGridViewTextBoxColumn.HeaderText = "Nome Fantasia";
            nomeFantasiaDataGridViewTextBoxColumn.Name = "nomeFantasiaDataGridViewTextBoxColumn";
            nomeFantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            nomeFantasiaDataGridViewTextBoxColumn.Width = 101;
            // 
            // cnpjDataGridViewTextBoxColumn
            // 
            cnpjDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            cnpjDataGridViewTextBoxColumn.DataPropertyName = "Cnpj";
            cnpjDataGridViewTextBoxColumn.HeaderText = "CNPJ";
            cnpjDataGridViewTextBoxColumn.Name = "cnpjDataGridViewTextBoxColumn";
            cnpjDataGridViewTextBoxColumn.ReadOnly = true;
            cnpjDataGridViewTextBoxColumn.Width = 58;
            // 
            // situcaoCadastralDataGridViewCheckBoxColumn
            // 
            situcaoCadastralDataGridViewCheckBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            situcaoCadastralDataGridViewCheckBoxColumn.DataPropertyName = "SitucaoCadastral";
            situcaoCadastralDataGridViewCheckBoxColumn.HeaderText = "Situção Cadastral";
            situcaoCadastralDataGridViewCheckBoxColumn.Name = "situcaoCadastralDataGridViewCheckBoxColumn";
            situcaoCadastralDataGridViewCheckBoxColumn.ReadOnly = true;
            situcaoCadastralDataGridViewCheckBoxColumn.Width = 93;
            // 
            // dataSituacaoCadastralDataGridViewTextBoxColumn
            // 
            dataSituacaoCadastralDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataSituacaoCadastralDataGridViewTextBoxColumn.DataPropertyName = "DataSituacaoCadastral";
            dataSituacaoCadastralDataGridViewTextBoxColumn.HeaderText = "Data da Alteração  Situação Cadastral";
            dataSituacaoCadastralDataGridViewTextBoxColumn.Name = "dataSituacaoCadastralDataGridViewTextBoxColumn";
            dataSituacaoCadastralDataGridViewTextBoxColumn.ReadOnly = true;
            dataSituacaoCadastralDataGridViewTextBoxColumn.Width = 162;
            // 
            // idadeDataGridViewTextBoxColumn
            // 
            idadeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            idadeDataGridViewTextBoxColumn.DataPropertyName = "Idade";
            idadeDataGridViewTextBoxColumn.HeaderText = "Idade";
            idadeDataGridViewTextBoxColumn.Name = "idadeDataGridViewTextBoxColumn";
            idadeDataGridViewTextBoxColumn.ReadOnly = true;
            idadeDataGridViewTextBoxColumn.Width = 60;
            // 
            // dataAberturaDataGridViewTextBoxColumn
            // 
            dataAberturaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataAberturaDataGridViewTextBoxColumn.DataPropertyName = "DataAbertura";
            dataAberturaDataGridViewTextBoxColumn.HeaderText = "Data de Abertura";
            dataAberturaDataGridViewTextBoxColumn.Name = "dataAberturaDataGridViewTextBoxColumn";
            dataAberturaDataGridViewTextBoxColumn.ReadOnly = true;
            dataAberturaDataGridViewTextBoxColumn.Width = 110;
            // 
            // naturezaJuridicaDataGridViewTextBoxColumn
            // 
            naturezaJuridicaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            naturezaJuridicaDataGridViewTextBoxColumn.DataPropertyName = "NaturezaJuridica";
            naturezaJuridicaDataGridViewTextBoxColumn.HeaderText = "Natureza Juridica";
            naturezaJuridicaDataGridViewTextBoxColumn.Name = "naturezaJuridicaDataGridViewTextBoxColumn";
            naturezaJuridicaDataGridViewTextBoxColumn.ReadOnly = true;
            naturezaJuridicaDataGridViewTextBoxColumn.Width = 111;
            // 
            // porteDataGridViewTextBoxColumn
            // 
            porteDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            porteDataGridViewTextBoxColumn.DataPropertyName = "Porte";
            porteDataGridViewTextBoxColumn.HeaderText = "Porte";
            porteDataGridViewTextBoxColumn.Name = "porteDataGridViewTextBoxColumn";
            porteDataGridViewTextBoxColumn.ReadOnly = true;
            porteDataGridViewTextBoxColumn.Width = 59;
            // 
            // matrizFilialDataGridViewTextBoxColumn
            // 
            matrizFilialDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            matrizFilialDataGridViewTextBoxColumn.DataPropertyName = "MatrizFilial";
            matrizFilialDataGridViewTextBoxColumn.HeaderText = "Matriz ou Filial";
            matrizFilialDataGridViewTextBoxColumn.Name = "matrizFilialDataGridViewTextBoxColumn";
            matrizFilialDataGridViewTextBoxColumn.ReadOnly = true;
            matrizFilialDataGridViewTextBoxColumn.Width = 78;
            // 
            // capitalSocialDataGridViewTextBoxColumn
            // 
            capitalSocialDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            capitalSocialDataGridViewTextBoxColumn.DataPropertyName = "CapitalSocial";
            capitalSocialDataGridViewTextBoxColumn.HeaderText = "Capital Social";
            capitalSocialDataGridViewTextBoxColumn.Name = "capitalSocialDataGridViewTextBoxColumn";
            capitalSocialDataGridViewTextBoxColumn.ReadOnly = true;
            capitalSocialDataGridViewTextBoxColumn.Width = 94;
            // 
            // idEnderecoDataGridViewTextBoxColumn
            // 
            idEnderecoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            idEnderecoDataGridViewTextBoxColumn.DataPropertyName = "IdEndereco";
            idEnderecoDataGridViewTextBoxColumn.HeaderText = "Código Endereço";
            idEnderecoDataGridViewTextBoxColumn.Name = "idEnderecoDataGridViewTextBoxColumn";
            idEnderecoDataGridViewTextBoxColumn.ReadOnly = true;
            idEnderecoDataGridViewTextBoxColumn.Width = 112;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            estadoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            estadoDataGridViewTextBoxColumn.ReadOnly = true;
            estadoDataGridViewTextBoxColumn.Width = 66;
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
            ((System.ComponentModel.ISupportInitialize)empresaEnderecoOtdBindingSource).EndInit();
            painelLateral.ResumeLayout(false);
            panelBotaoDeletar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelBotaoEditar.ResumeLayout(false);
            panelBotaoFiltrar.ResumeLayout(false);
            panelBotaoCriar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel painelLateral;
        private DataGridView dataGridViewEmpresas;
        private Panel panelBotaoFiltrar;
        private Button botaoFiltros;
        private Panel panel1;
        private Button botaoPesquisar;
        private Panel panelBotaoDeletar;
        private Button botaoDeletar;
        private Panel panelBotaoEditar;
        private Button botaoEditar;
        private Panel panelBotaoCriar;
        private Button botaoCriar;
        private BindingSource empresaEnderecoOtdBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn razaoSocialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeFantasiaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cnpjDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn situcaoCadastralDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataSituacaoCadastralDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataAberturaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn naturezaJuridicaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn porteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn matrizFilialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn capitalSocialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idEnderecoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
    }
}