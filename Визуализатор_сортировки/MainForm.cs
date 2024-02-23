using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Визуализатор_сортировки
{
    public partial class MainForm : Form
    {
        private Presenter P;
        Chart Data = new Chart();
        System.Windows.Forms.Label label_count = new System.Windows.Forms.Label();
        System.Windows.Forms.Label label_speed = new System.Windows.Forms.Label();
        System.Windows.Forms.Button Generate = new System.Windows.Forms.Button();
        RichTextBox RCB = new RichTextBox();
        TrackBar Trackbar = new TrackBar();
        TrackBar Trackbar_ = new TrackBar();

        public MainForm(Presenter P_)
        {
            P=P_;
            DrawChart();
            DrawButton();
            DrawRichTextBox();
            DrawLabel();
            DrawTrackBar();
            InitializeComponent();
        }

        private void DrawRichTextBox()
        {
            RCB.Location = new Point(520, 60);
            RCB.Size = new Size(250, 300);
            this.Controls.Add(RCB);
        }

        private void DrawTrackBar()
        {
            Trackbar.Location = new Point(10,340);
            Trackbar.Size = new Size(500,200);
            Trackbar.Minimum = 0;
            Trackbar.Maximum = 10000;
            Trackbar.ValueChanged += (sender, e) =>
            {
                label_count.Text = "Количество: "+Trackbar.Value.ToString();
            };
            Trackbar.TickFrequency = 250;
            this.Controls.Add(Trackbar);
            Trackbar_.Location = new Point(10, 400);
            Trackbar_.Size = new Size(200, 200);
            Trackbar_.Minimum = 0;
            Trackbar_.Maximum = 100;
            Trackbar_.ValueChanged += (sender, e) =>
            {
                label_speed.Text = "Скорость (мс): "+Trackbar_.Value.ToString();
            };
            this.Controls.Add(Trackbar_);
        }
        private void DrawButton()
        {
            Generate.Text = "Генерация чисел";
            Generate.Size = new Size(100, 50);
            Generate.Location = new Point(670, 10);
            this.Controls.Add(Generate);
            Generate.Click += (sender, e) =>
            {
                RCB.Clear();
                Data.Series[0].Points.Clear();
                P.Start_work(Trackbar.Value);
                RCB.Text += P.Return_String();
                Array.Sort(P.Numbers);
                for (int i = 0; i < P.Numbers.Length; i++)
                {
                    Data.Series[0].Points.AddXY(i, P.Numbers[i]);
                }
            };
        }

        private void DrawLabel()
        {
            label_count.Size = new Size(150, 30);
            label_count.Location = new Point(520, 10);
            label_count.Text = "Количество: " + Trackbar.Value.ToString();
            this.Controls.Add(label_count);
            label_speed.Size = new Size(150, 30);
            label_speed.Location = new Point(520, 40);
            label_speed.Text = "Скорость (мс): " + Trackbar_.Value.ToString();
            this.Controls.Add(label_speed);
        }

        private void DrawChart()
        {
            Data.Location = new Point(10, 10);
            Data.Size = new Size(500, 300);
            this.Controls.Add(Data);
            Data.ChartAreas.Add(new ChartArea("area"));

            // Настройка типа диаграммы
            Data.Series.Add(new Series("series"));
            Data.Series["series"].ChartType = SeriesChartType.Column;
            Data.Titles.Add("Сортировка");


            // Настройка меток осей
            Data.ChartAreas["area"].AxisX.Title = "Номера элементов";
            Data.ChartAreas["area"].AxisY.Title = "Значения элементов";
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
