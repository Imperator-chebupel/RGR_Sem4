using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Визуализатор_сортировки
{
    public class Presenter
    {
        public ISort Algorithm = new Algorithm_bubble();//{ get; set; }
        private Random r = new Random();

        Chart Data = new Chart();
        private System.Windows.Forms.Label label_count { get; set; } = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label label_speed { get; set; } = new System.Windows.Forms.Label();
        private System.Windows.Forms.Button Generate { get; set; } = new System.Windows.Forms.Button();
        private RichTextBox RCB {get; set; } = new RichTextBox();
        private System.Windows.Forms.TrackBar Trackbar { get; set; } = new System.Windows.Forms.TrackBar();
        private System.Windows.Forms.TrackBar Trackbar_ { get; set; } = new System.Windows.Forms.TrackBar();
        private CheckBox AlBubble = new CheckBox();
        private CheckBox AlInsert = new CheckBox();

        

        public CheckBox DrawCheckBox1()
        {
            AlBubble.Enabled = true;
            AlBubble.Location = new Point(600, 380);
            AlBubble.Checked= true;
            AlBubble.CheckedChanged += (sender, e) =>
            {
                if (AlBubble.Checked) 
                {
                    AlInsert.Checked = false;
                    Algorithm = new Algorithm_bubble();
                }
            };

            return AlBubble;
        }

        public CheckBox DrawCheckBox2()
        {
            AlInsert.Enabled = true;
            AlInsert.Location = new Point(600, 410);
            AlInsert.CheckedChanged += (sender, e) =>
            {
                if (AlInsert.Checked)
                {
                    AlBubble.Checked = false;
                    //Algorithm = new Algorithm_insert();
                }
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
            Trackbar.Maximum = 500;
            Trackbar.ValueChanged += (sender, e) =>
            {
                label_count.Text = "Количество: " + Trackbar.Value.ToString();
            };
            Trackbar.TickFrequency = 100;
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
            Generate.Click += (sender, e) =>
            {
                RCB.Clear();
                Start_work(Trackbar.Value);
                RCB.Text += Return_String();
                Data.Series[0].Points.Clear();

                //Data.Series[0].Points.DataBindY(Numbers);


                double[] doubles= new double[] {0.9, 0.7 ,0.1, 0.99, 0.5 , 0.11 };
                //Data.Series[0].Points.DataBindY(doubles);



                //List<(int , int , double , double )> Path = Algorithm.Sort(Numbers);
                for (int i = 0; i < Numbers.Length; i++)
                {
                    Data.Series[0].Points.AddXY(i, Numbers[i]);
                }
                List<(int, int, double, double)> Path = Algorithm.Sort(Numbers);


                foreach ((int, int, double, double) F in Path)
                {
                    Numbers[F.Item1] = F.Item3;
                    Numbers[F.Item2] = F.Item4;
                    Data.Series[0].Points.DataBindY(Numbers);
                    Data.Update();
                    Task.Delay(1).GetAwaiter().GetResult();
                }
                //Data.Series[0].Points.Clear();
                for (int i = 0; i < Numbers.Length; i++)
                {
                    //Data.Series[0].Points.AddXY(i, Numbers[i]);
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
            Data.Series.Add(new Series("Сортировка"));
            Data.Series["Сортировка"].ChartType = SeriesChartType.Column;
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
        /*
        public void Sort_numbers()
        {
            //RCB.Text += "Я абрикос\n";//Algorithm.Sort(Numbers);
            List<(int, int, double, double)> Path = Algorithm.Sort(Numbers);
        }*/
    }
}
