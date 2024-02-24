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
        System.Windows.Forms.Label label_count;
        System.Windows.Forms.Label label_speed;
        System.Windows.Forms.Button Generate;
        RichTextBox RCB;
        TrackBar Trackbar;
        TrackBar Trackbar_;
        CheckBox CB1, CB2;
        public MainForm(Presenter P_)
        {
            P=P_;

            Data = P.DrawChart();
            this.Controls.Add(Data);

            label_count = P.DrawLabel1();
            this.Controls.Add(label_count);

            label_speed = P.DrawLabel2();
            this.Controls.Add(label_speed);

            Generate = P.DrawButton();
            this.Controls.Add(Generate);

            RCB = P.DrawRichTextBox();
            this.Controls.Add(RCB);

            Trackbar = P.DrawTrackBar_1();
            this.Controls.Add(Trackbar);

            Trackbar_ = P.DrawTrackBar_2();
            this.Controls.Add(Trackbar_);

            CB1 = P.DrawCheckBox1();
            this.Controls.Add(CB1);

            CB2 = P.DrawCheckBox2();
            this.Controls.Add(CB2);

            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
