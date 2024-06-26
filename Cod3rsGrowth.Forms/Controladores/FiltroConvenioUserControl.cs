using Cod3rsGrowth.Dominio.Filtros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cod3rsGrowth.Forms.Controladores
{
    public partial class FiltroConvenioUserControl : UserControl
    {
        private PrivateFontCollection _pixeboy;
        public FiltroConvenio Filtro;

        public FiltroConvenioUserControl()
        {
            InitializeComponent();
        }

        private void FiltroConvenioUserControl_Paint(object sender, PaintEventArgs e)
        {
            if (BorderStyle == BorderStyle.None)
            {
                const int Tamanho = 2;
                const int xInicioRetanguloExterior = 4;
                const int yInicioRetanguloExterior = 6;
                const int xInicioRetanguloInterior = 8;
                const int yInicioRetanguloInterior = 10;

                using (Pen caneta = new Pen(Color.White, Tamanho))
                {
                    e.Graphics.DrawRectangle(caneta, new Rectangle(xInicioRetanguloExterior,
                                                                   yInicioRetanguloExterior,
                                                                   Width - (xInicioRetanguloExterior + Tamanho) * 2,
                                                                   Height - (yInicioRetanguloExterior + Tamanho) * 2));

                    e.Graphics.DrawRectangle(caneta, new Rectangle(xInicioRetanguloInterior,
                                                                   yInicioRetanguloInterior,
                                                                   Width - (xInicioRetanguloInterior + Tamanho) * 2,
                                                                   Height - (yInicioRetanguloInterior + Tamanho) * 2));
                }
            }
        }

        private void FiltroConvenioUserControl_Load(object sender, EventArgs e)
        {
            _pixeboy = new PrivateFontCollection();
            _pixeboy.AddFontFile("C:\\Users\\Usuario\\Desktop\\Cod3rsGrowth\\Cod3rsGrowth\\Cod3rsGrowth.Forms\\Resources\\Pixeboy-z8XGD.ttf");
            Filtro = new FiltroConvenio();

            foreach (Control c in this.Controls)
            {
                c.Font = new Font(_pixeboy.Families[0], 12, FontStyle.Bold);
            }


        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void botaoFiltrar_Click(object sender, EventArgs e)
        {
            Filtro.ObjetoFiltro = textBoxObjeto.Text;
            Filtro.ValorFiltro = decimal.Parse(textBoxValor.Text);
            Filtro.DataInicioFiltro = dateTimePickerDataInicio.Value;
            Filtro.DataTerminoFiltro = dateTimePickerDataInicio.Value;
        }

        private void checkBoxMaiorValor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMenorValor.Checked == true)
                checkBoxMenorValor.Checked = !checkBoxMenorValor.Checked;
        }

        private void checkBoxMenorValor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaiorValor.Checked == true)
                checkBoxMaiorValor.Checked = !checkBoxMaiorValor.Checked;
        }

        private void checkBoxMaiorDataInicio_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMenorDataInicio.Checked == true)
                checkBoxMenorDataInicio.Checked = !checkBoxMenorDataInicio.Checked;     
        }

        private void checkBoxMenorDataInicio_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaiorDataInicio.Checked == true)
                checkBoxMaiorDataInicio.Checked = !checkBoxMaiorDataInicio.Checked;
        }

        private void checkBoxMaiorDataTermino_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMenorDataTermino.Checked == true)
                checkBoxMenorDataTermino.Checked = !checkBoxMenorDataTermino.Checked;
        }

        private void checkBoxMenorDataTermino_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaiorDataTermino.Checked == true)
                checkBoxMaiorDataTermino.Checked = !checkBoxMaiorDataTermino.Checked;
        }
    }
}
