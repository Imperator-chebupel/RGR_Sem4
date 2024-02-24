using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Визуализатор_сортировки
{
    public class Presenter
    {
        public ISort Algorithm;
        private Random r = new Random();

        Chart Data = new Chart();
        System.Windows.Forms.Label label_count = new System.Windows.Forms.Label();
        System.Windows.Forms.Label label_speed = new System.Windows.Forms.Label();
        System.Windows.Forms.Button Generate = new System.Windows.Forms.Button();
        RichTextBox RCB = new RichTextBox();
        System.Windows.Forms.TrackBar Trackbar = new System.Windows.Forms.TrackBar();
        System.Windows.Forms.TrackBar Trackbar_ = new System.Windows.Forms.TrackBar();
        CheckBox AlBubble = new CheckBox();
        CheckBox AlInsert = new CheckBox();

        public CheckBox DrawCheckBox1()
        {
            AlBubble.Enabled = true;
            AlBubble.Location = new Point(600, 380);
            AlBubble.Checked= true;
            AlBubble.CheckedChanged += (sender, e) =>
            {
                if (AlBubble.Checked)  AlInsert.Checked = false; 
            };

            return AlBubble;
        }

        public CheckBox DrawCheckBox2()
        {
            AlInsert.Enabled = true;
            AlInsert.Location = new Point(600, 410);
            AlInsert.CheckedChanged += (sender, e) =>
            {
                if (AlInsert.Checked) AlBubble.Checked = false;
            };
            return AlInsert;
        }


        public RichTextBox DrawRichTextBox()
        {
            RCB.Location = new Point(520, 60);
            RCB.Size = new Size(250, 300);
            return RCB;
        }

        public System.Windows.Forms.TrackBar DrawTrackBar_1()
        {
            Trackbar.Location = new Point(10, 340);
            Trackbar.Size = new Size(500, 200);
            Trackbar.Minimum = 0;
            Trackbar.Maximum = 10000;
            Trackbar.ValueChanged += (sender, e) =>
            {
                label_count.Text = "Количество: " + Trackbar.Value.ToString();
            };
            Trackbar.TickFrequency = 250;
            return Trackbar;
        }

        public System.Windows.Forms.TrackBar DrawTrackBar_2()
        {
            Trackbar_.Location = new Point(10, 400);
            Trackbar_.Size = new Size(300, 200);
            Trackbar_.Minimum = 0;
            Trackbar_.Maximum = 1000;
            Trackbar_.ValueChanged += (sender, e) =>
            {
                label_speed.Text = "Скорость (мс): " + Trackbar_.Value.ToString();
            };
            return Trackbar_;
        }

        public System.Windows.Forms.Button DrawButton()
        {
            Generate.Text = "Генерация чисел";
            Generate.Size = new Size(100, 50);
            Generate.Location = new Point(670, 10);
            //this.Controls.Add(Generate);
            Generate.Click += (sender, e) =>
            {
                RCB.Clear();
                Data.Series[0].Points.Clear();
                Start_work(Trackbar.Value);
                RCB.Text += Return_String();
                Array.Sort(Numbers);
                for (int i = 0; i < Numbers.Length; i++)
                {
                    Data.Series[0].Points.AddXY(i, Numbers[i]);
                }
            };
            return Generate;
        }

        public Chart DrawChart()
        {
            Data.Location = new Point(10, 10);
            Data.Size = new Size(500, 300);
            Data.ChartAreas.Add(new ChartArea("area"));

            // Настройка типа диаграммы
            Data.Series.Add(new Series("series"));
            Data.Series["series"].ChartType = SeriesChartType.Column;
            Data.Titles.Add("Сортировка");


            // Настройка меток осей
            Data.ChartAreas["area"].AxisX.Title = "Номера элементов";
            Data.ChartAreas["area"].AxisY.Title = "Значения элементов";
            return Data;
        }

        public System.Windows.Forms.Label DrawLabel1()
        {
            label_count.Size = new Size(150, 30);
            label_count.Location = new Point(520, 10);
            label_count.Text = "Количество: " + Trackbar.Value.ToString();
            return label_count;
        }


        public System.Windows.Forms.Label DrawLabel2()
        {
            label_speed.Size = new Size(150, 20);
            label_speed.Location = new Point(520, 40);
            label_speed.Text = "Скорость (мс): " + Trackbar_.Value.ToString();
            return label_speed;
        }


        public double[] Numbers;
        public double[] Start_work(int Lenght)
        {
            Numbers = new double[Lenght];
            for (int i = 0; i < Lenght; i++)
            {
                Numbers[i] = r.NextDouble();
            }
            return Numbers;
        }

        public string Return_String()
        {
            return (String.Join("\n", Numbers)); 
        }

        public void Sort_numbers()
        {
            for (int i = 0; i < Numbers.Length; i++)
            {
                Algorithm.Sort(Numbers);
            }
        }
    }
}
