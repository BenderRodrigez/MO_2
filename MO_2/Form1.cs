using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MO_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int sizeX = 100;
        double[] Y = new double[sizeX];

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            for(int x = 0; x < sizeX; x++)
                {
                    Y[x] = System.Math.Cos(((x / 10.0) - 3));
                    chart1.Series[0].Points.AddXY(((x / 10.0) - 3), Y[x]);
                }
            chart1.Series.Add("0X");
            chart1.Series[1].Color = Color.Black;
            chart1.Series[1].IsVisibleInLegend = false;
            chart1.Series[1].BorderWidth = 2;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int x = -4; x <= 10; x++)
            {
                chart1.Series[1].Points.AddXY(x, 0);
            }
            chart1.Series.Add("0Y");
            chart1.Series[2].IsVisibleInLegend = false;
            chart1.Series[2].BorderWidth = 2;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[2].Color = Color.Black;
            for (int y = -2; y < 3; y++)
            {
                chart1.Series[2].Points.AddXY(0, y);
            }
            
        }
    }
}
