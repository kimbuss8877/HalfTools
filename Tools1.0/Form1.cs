using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;



namespace Tools1._0
{
    public partial class Form1 : Form
    {     
        public const double NUM_000001 = 0.00001f;
        public const float NUM_001 = 0.01f;

        private const int Value5000 = 0;
        private const int Value10000 = 1;
        private const int Value15000 = 2;
        private const int Value20000 = 3;
        private const int Value25000 = 4;
        private const int Value30000 = 5;
        private const int Value35000 = 6;
        private const int Value40000 = 7;
        private const int Value45000 = 8;
        private const int Value50000 = 9;

        private const int Value_55_100 = 10;
        private const int Value_105_150 = 11;
        private const int Value_155_200 = 12;
        private const int Value_205_250 = 13;
        private const int Value_255_300 = 14;
        private const int Value_305_350 = 15;
        private const int Value_355_400 = 16;
        private const int Value_500 = 17;
        private const int Value_600 = 18;
        private const int Value_700 = 19;

        private const int Value_800 = 20;
        private const int Value_900 = 21;
        private const int Value_1000 = 22;

        private const int Value_1 = 23;
        private const int Value_2 = 24;

        private int[] Value_Arr = new int[25];
    
        private const int ValueArr_20000 = 0;
        private const int ValueArr_30000 = 1;
        private const int ValueArr_40000 = 2;
        private const int ValueArr_50000 = 3;
        private const int ValueArr_60000 = 4;
        private const int ValueArr_70000 = 5;
        private const int ValueArr_80000 = 6;
        private const int ValueArr_90000 = 7;
        private const int ValueArr_100000 = 8;
        private const int ValueArr_150000 = 9;
        private const int ValueArr_200000 = 10;
        private const int ValueArr_250000 = 11;
        private const int ValueArr_300000 = 12;
        private const int ValueArr_400000 = 13;
        private const int ValueArr_500000 = 14;
        private const int ValueArr_600000 = 15;
        private const int ValueArr_700000 = 16;
        private const int ValueArr_800000 = 17;
        private const int ValueArr_900000 = 18;
        private const int ValueArr_2000 = 19;

        private int LineChart_X;
        private int LineChart_Y;
 
         private double LineChart_Double_X;
      
        private int Mainchart_Minmum_X;
        private int Mainchart_Maxmum_X;
        private int Mainchart_Interval_X;

        private int Mainchart_Minmum_Y;
        private int Mainchart_Maxmum_Y;
        private int Mainchart_Interval_Y;
        private int MainChart_X;
        private int MainChart_Y;      


        private double Double_LineSelectValue_00;
        private double Double_MainChart_00;

        private int Select_Money_Loop;

        private bool MainChart_On;
        private bool LineChart_On;            
       
       
        private const int LineChart_X_Min = 0;
        private const int LineChart_X_Inter = 1000000;
        public Form1()
        {
            InitializeComponent();
            ComboBox_BaseValue();
            LabelColor_Clear();          
                   
            label36.Text = "0";
            /////////////////////////////////////////////////////     
            Mainchart_Minmum_X = 0;
            Mainchart_Maxmum_X =  1000000;
            Mainchart_Interval_X = 100000;

            Mainchart_Minmum_Y = 0;
            Mainchart_Maxmum_Y = 700000;
            Mainchart_Interval_Y = 100000;
            Base_Text();
            KeyPreview = true;
            this.MouseWheel += new MouseEventHandler(MainChart_MouseWheel);
            //    MessageBox.Show("변경 된 금액이 적용안되었습니다.");
        }
       
        private void Base_Text()
        {
        //    Header[0] = Convert.ToInt32(comboBox2.Text);      //      1 테이블 크기
            Header[0] += 10000000;
            textBox2.Text = "1";                            //      2 테이블 갯수
            textBox3.Text = "10000";                           //      3 리미트
            textBox4.Text = "1";                           //      4 뱅크 5000 최대 횟수
            textBox5.Text = "10";                           //      5 뱅크 2만 최대 횟수
            textBox6.Text = "20";                           //      6 뱅크 3만 최대 횟수
            textBox7.Text = "30";                           //      7 뱅크 5만 최대 횟수
            textBox8.Text = "60";                           //      8
            textBox9.Text = "60";                           //      9
            textBox10.Text = "60";                          //     10
        }
        private void BaseMainChart()
        {
            this.MainChart.ChartAreas[0].AxisX.Minimum = Mainchart_Minmum_X;
            this.MainChart.ChartAreas[0].AxisX.Maximum = Mainchart_Maxmum_X;
            this.MainChart.ChartAreas[0].AxisX.Interval = Mainchart_Interval_X;

            this.MainChart.ChartAreas[0].AxisY.Minimum = Mainchart_Minmum_Y;
            this.MainChart.ChartAreas[0].AxisY.Maximum = Mainchart_Maxmum_Y;
            this.MainChart.ChartAreas[0].AxisY.Interval = Mainchart_Interval_Y;

            MainChart.Series[0].Points.Clear();
            MainChart.Series[0].Points.AddXY(Mainchart_Minmum_X, 100);

            label1.Focus();
        }
        private void BaseLineChart()
        {          
            this.LineChart.ChartAreas[0].AxisX.Minimum = LineChart_X_Min;
            this.LineChart.ChartAreas[0].AxisX.Maximum = 10000000;
            this.LineChart.ChartAreas[0].AxisX.Interval = LineChart_X_Inter;

            this.LineChart.ChartAreas[0].AxisY.Minimum = 60;     // 최저값
            this.LineChart.ChartAreas[0].AxisY.Maximum = 100;    // 최고값
            this.LineChart.ChartAreas[0].AxisY.Interval = 10;    // 간격

            this.LineChart.Series[0].MarkerColor = Color.Red;
            this.LineChart.Series[0].Points.Clear();
            LineChart.Series[0].Points.AddXY(LineChart_X_Min, 100);                        
            label1.Focus();
            //    MessageBox.Show("Base Load");
        }
        private bool Loading_On;
        private void Form1_Load(object sender, EventArgs e)///////////////////////////////////////////////////  시작점
        {
            BaseLineChart();
            BaseMainChart();
            label1.ForeColor = System.Drawing.Color.Red;
            label2.ForeColor = System.Drawing.Color.Blue;
            label3.ForeColor = System.Drawing.Color.Green;

            label1.Text = 0.ToString();
            label2.Text = 0.ToString();
            label3.Text = 0.ToString();       
        }
        private void StartDelay()
        {
            Loading_On = true;
        }
       
        private void MainChart_MouseWheel(object seder, MouseEventArgs e)
        {
            //Sel_Count = e.Delta / 120;
            //Sel_Sum += Sel_Count;
           
            //if (Sel_Sum < -2 && Mainchart_Minmum_X > 0)
            //{
            //    Mainchart_Maxmum_X -= 100000;
            //    Mainchart_Minmum_X -= 100000;
            //    SelectMainChart();
            //    Sel_Sum = 0;

            //}
            //if (Sel_Sum > 2 )
            //{
            //    Mainchart_Maxmum_X += 100000;
            //    Mainchart_Minmum_X += 100000;
            //    SelectMainChart();
            //    Sel_Sum = 0;
            //}
        }      
        //================================================================================================================================================== 마우스 움직임
        private void LineChart_MouseMove(object sender, MouseEventArgs e)
        {
            if (Loading_On == true)
            {
               
                LineChart_X = 0;
                LineChart_Double_X = LineChart.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                LineChart_X = Convert.ToInt32(LineChart_Double_X);
                if (LineChart_X > 0 && LineChart_X < 10000000)
                {
                    Double_LineSelectValue_00 = LineChart_X * 0.001f;

                    LineChart_X = Convert.ToInt32(Double_LineSelectValue_00);
                    LineChart_X = LineChart_X * 1000;
                    LineChart.Series[1].Points.Clear();
                    LineChart.Series[1].Points.AddXY(LineChart_X, 120);
                    LineChart.Series[1].LabelForeColor = Color.Green;
                    LineChart.Series[1].Label = String.Format("{0:#,###}", LineChart_X);  //LineChart_X.ToString();
                    label3.Text = String.Format("{0:#,###}", LineChart_X);
                }
            }
        }     
        private void MainChart_MouseMove(object sender, MouseEventArgs e)
        {
            if (Loading_On == true)
            {
                MainChart_X = 0;
                MainChart_Y = Convert.ToInt32(MainChart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y));
                MainChart_X = Convert.ToInt32(MainChart.ChartAreas[0].AxisX.PixelPositionToValue(e.X));
                if (MainChart_X > Mainchart_Minmum_X && MainChart_X < Mainchart_Maxmum_X)
                {
                    Double_MainChart_00 = MainChart_X * 0.001;
                    MainChart_X = Convert.ToInt32(Double_MainChart_00);
                    label1.Text = DataTbl[MainChart_X].ToString();
                    MainChart_X *= 1000;
                    label2.Text = String.Format("{0:#,###}", MainChart_X);
                  
                    MainChart.Series[0].Points.Clear();
                    MainChart.Series[0].Points.AddXY(MainChart_X, 1000000);
                    MainChart.Series[0].LabelForeColor = Color.Green;
                    MainChart.Series[0].Label = String.Format("{0:#,###}", MainChart_X);                  
                }
            }
        }      
        //================================================================================================================================================================             
        int InsertBar_CurrentPosi;
        int InsertBar_CurrentIdx;
        int InsertBar_InScore;

        private void InsertBar_Process()
        {        
            InsertBar_CurrentPosi = MainChart_X;
            InsertBar_CurrentIdx = InsertBar_CurrentPosi / 1000;
            InsertBar_InScore = Convert.ToInt32(comboBox3.Text);

            if (DataTbl[InsertBar_CurrentIdx] > 0)
                MessageBox.Show("이미 값이 있습니다");
            else
            {
                DataTbl[InsertBar_CurrentIdx] = InsertBar_InScore;
                SelectMainChart();
                CurrentPro();
                Percent_Process();
                ReLineChart();
                SecterTotal_Process(Mainchart_Minmum_X, Mainchart_Maxmum_X);
            }
            label1.Focus();
        }
        int DeleteBar_CurrentPosi;
        int DeleteBar_CurrentIdx;
        private void Delete_Bar_Process()
        {
            label42.Text = "Delete";
            DeleteBar_CurrentPosi = MainChart_X;
            DeleteBar_CurrentIdx = DeleteBar_CurrentPosi / 1000;

            if (DataTbl[DeleteBar_CurrentIdx] > 0)
            {
                DataTbl[DeleteBar_CurrentIdx] = 0;
                SelectMainChart();
                CurrentPro();
                Percent_Process();
                ReLineChart();
                SecterTotal_Process(Mainchart_Minmum_X, Mainchart_Maxmum_X);
            }
            else MessageBox.Show("지울 값이 없습니다");
            label1.Focus();
        }      
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////   메인 차트로 확대 하는 순간  
        private int Multi_100000;
        private double Devide_100000;
        private void LineChart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)// && Make_On == true)
            {
                LineChart_On = true;               
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right && LineChart_On == true)
            {             
                LineChart_X = Convert.ToInt32(LineChart.ChartAreas[0].AxisX.PixelPositionToValue(e.X));
                LineChart_Y = Convert.ToInt32(LineChart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y));               

                if (LineChart_X > 0 && LineChart_X < 10000000 && LineChart_Y > 50 && LineChart_Y < 120)
                {
                    Devide_100000 = LineChart_X;
                    Devide_100000 *= 0.00001;
                    Devide_100000 = Math.Truncate(Devide_100000);
                    Multi_100000 = Convert.ToInt32(Devide_100000);
                    Multi_100000 *= 100000;

                    LineChartRightClick_To_MainChaartReDraw_Value_X();
                    SelectMainChart();
                    SecterTotal_Process(Mainchart_Minmum_X, Mainchart_Maxmum_X);
                    LineChart_On = false;
                    MainChart_On = true;                    
                }
            }
          //  label1.Focus();
        }
        private void LineChartRightClick_To_MainChaartReDraw_Value_X()
        {
      
            int posi_10000000 = 0;
            int posi_1000000 = 0;
            int posi_100000 = 0;

            int Total = 0;
            posi_100000 = (int)LineChart_X / 100000 % 10;
            posi_100000 *= 100000;
            posi_1000000 = (int)LineChart_X / 1000000 % 10;
            posi_1000000 *= 1000000;
            posi_10000000 = (int)LineChart_X / 10000000 % 10;
            posi_10000000 *= 10000000;
            
            Total = posi_100000 + posi_1000000 + posi_10000000;
            if (Total > 250000)
            {
                Mainchart_Maxmum_X = Total + 250000;
                Mainchart_Minmum_X = Total - 250000;
            }else
            {
                Mainchart_Maxmum_X = 500000;
                Mainchart_Minmum_X = 0;
            }
        }    
        private int SelectMainchart_Start;
        private int SelectMainchart_End;
        private int SelectMainchart_X;
        private int SelectMainchart_Y;
        private void SelectMainChart()
        {          
            MainChart.Series[1].Points.Clear(); // 10만 아래
            MainChart.Series[2].Points.Clear(); //   10 - 20
            MainChart.Series[3].Points.Clear(); //  30 - 40
            MainChart.Series[4].Points.Clear(); //   50
            MainChart.Series[5].Points.Clear(); //   60 - 100

            BaseMainChart();

            if (Mainchart_Minmum_X > 0)
            {
                SelectMainchart_Start = Mainchart_Minmum_X / 1000;
                SelectMainchart_End = Mainchart_Maxmum_X / 1000;
            }else 
            {
                SelectMainchart_Start = 0;
                SelectMainchart_End = 500;
            }          

            MainChart.Series[0].Points.AddXY(Mainchart_Maxmum_X, DataTbl.Length);

            for (Select_Money_Loop = SelectMainchart_Start; Select_Money_Loop < SelectMainchart_End; Select_Money_Loop++)
            {
                if(DataTbl[Select_Money_Loop] > 0) {

                    SelectMainchart_X = Select_Money_Loop * 1000;
                    SelectMainchart_Y = DataTbl[Select_Money_Loop];

                    if (SelectMainchart_Y > 0 && SelectMainchart_Y < 100000)
                    {
                        MainChart.Series[1].Points.AddXY(SelectMainchart_X, SelectMainchart_Y);
                    }
                    if (SelectMainchart_Y > 99000 && SelectMainchart_Y < 200000)
                    {
                        MainChart.Series[2].Points.AddXY(SelectMainchart_X, SelectMainchart_Y);
                    }
                    if (SelectMainchart_Y > 199000 && SelectMainchart_Y < 300000)
                    {
                        MainChart.Series[3].Points.AddXY(SelectMainchart_X, SelectMainchart_Y);
                    }
                    if (SelectMainchart_Y > 299000 && SelectMainchart_Y < 400000)
                    {
                        MainChart.Series[4].Points.AddXY(SelectMainchart_X, SelectMainchart_Y);
                    }
                    if (SelectMainchart_Y > 399000 && SelectMainchart_Y <= 1000000)
                    {
                        MainChart.Series[5].Points.AddXY(SelectMainchart_X, SelectMainchart_Y);
                    }
                }
            }
        }          
 //===============================================================================================================================================================================
        private int ReLineChart_Loop;
        private double ReLineChart_Y;
        private int CurrentPosi_X;
        private int RandomMake_Sum;       

        private void ReLineChart()                                                             // 라인차트 다시 그리기
        {
            CurrentPosi_X = 0;
            RandomMake_Sum = 0;
            int maxtbl = Convert.ToInt32(comboBox2.Text);
            int maxinterval = maxtbl / 10;
            float percentto = 0;
            this.LineChart.ChartAreas[0].AxisX.Minimum = 0;
            this.LineChart.ChartAreas[0].AxisX.Maximum = maxtbl;          // LineChart_X_Maximum;
            this.LineChart.ChartAreas[0].AxisX.Interval = 1000000;      // NUM_500000;

            this.LineChart.ChartAreas[0].AxisY.Minimum = 50;
            this.LineChart.ChartAreas[0].AxisY.Maximum = 120;
            this.LineChart.ChartAreas[0].AxisY.Interval = 10;
            LineChart.Series[0].Points.Clear();
            int temp = 0;
          
            for (ReLineChart_Loop = 0; ReLineChart_Loop < DataTbl.Length; ReLineChart_Loop++)
            {
                CurrentPosi_X = ReLineChart_Loop * 1000;
              
                if (DataTbl[ReLineChart_Loop] > 0)                                 
                    RandomMake_Sum += DataTbl[ReLineChart_Loop];

                switch (CurrentPosi_X)
                {
                    case 500000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 1000000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 1500000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 2000000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 2500000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 3000000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 3500000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 4000000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 4500000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 5000000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 5500000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 6000000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 6500000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 7000000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 7500000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 8000000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 8500000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 9000000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 9500000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    case 9999000:
                        percentto = (float)RandomMake_Sum / CurrentPosi_X;
                        percentto = percentto * 100;
                        this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, percentto);
                        break;
                    default:
                        break;
                }
                          

                //    this.LineChart.Series[0].Points.AddXY(CurrentPosi_X, ReLineChart_Y);                
               
                label35.Text = percentto.ToString();
                if(ReLineChart_Loop == 1)
                    this.LineChart.Series[0].Points.AddXY(1, 100);
            }
            label1.Focus();
        }
        private void Percent_Process(int sum,int posi)
        {
          

        }
        /// /////////////////////////////////////////////////////////////////////////////////////////// 콤보 박스
 
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  int amout = Convert.ToInt32(comboBox2.Text);           
            label1.Focus();
        }        
        
        private double Total_Sum;        
        private double Percent_Value;
        private int Percent_Int;
        private void Percent_Process()
        {
            int total_tbl = Convert.ToInt32(comboBox2.Text);
            Percent_Value = Total_Sum / total_tbl;
            Percent_Value *= 100;
            Percent_Value = Math.Truncate(Percent_Value);
            Percent_Int = Convert.ToInt32(Percent_Value);
            if (Percent_Int >= 100)
            {
                label35.ForeColor = Color.Red;
            }
            else
            {
                label35.ForeColor = Color.Black;
            }
            label35.Text = Percent_Int.ToString();          
        }
        private void CurrentPro()
        {
            Total_Sum = 0;
            for (int proloop = 0;proloop < DataTbl.Length; proloop++)
            {
                if (DataTbl[proloop] > 0)
                    Total_Sum += DataTbl[proloop];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Focus();
        }       

        private Random Rand = new Random();     
        private int[] DataTbl = new int[10000];
       
        private void Random_Make_Process()////////////////////////////////////  /////////////////////////////////////////////////////////////////////////////            랜덤 넣기
        {
            Value_Arr[ValueArr_20000] = Convert.ToInt32(numericUpDown1.Value);
            Value_Arr[ValueArr_30000] = Convert.ToInt32(numericUpDown2.Value);
            Value_Arr[ValueArr_40000] = Convert.ToInt32(numericUpDown3.Value);
            Value_Arr[ValueArr_50000] = Convert.ToInt32(numericUpDown4.Value);
            Value_Arr[ValueArr_60000] = Convert.ToInt32(numericUpDown5.Value);

            Value_Arr[ValueArr_70000] = Convert.ToInt32(numericUpDown6.Value);
            Value_Arr[ValueArr_80000] = Convert.ToInt32(numericUpDown7.Value);
            Value_Arr[ValueArr_90000] = Convert.ToInt32(numericUpDown8.Value);
            Value_Arr[ValueArr_100000] = Convert.ToInt32(numericUpDown9.Value);
            Value_Arr[ValueArr_150000] = Convert.ToInt32(numericUpDown10.Value);

            Value_Arr[ValueArr_200000] = Convert.ToInt32(numericUpDown11.Value);
            Value_Arr[ValueArr_250000] = Convert.ToInt32(numericUpDown12.Value);
            Value_Arr[ValueArr_300000] = Convert.ToInt32(numericUpDown13.Value);
            Value_Arr[ValueArr_400000] = Convert.ToInt32(numericUpDown14.Value);
            Value_Arr[ValueArr_500000] = Convert.ToInt32(numericUpDown15.Value);
            Value_Arr[ValueArr_2000] = Convert.ToInt32(numericUpDown18.Value);

            Score_Position();
            //    MessageBox.Show("랜덤 배열 넣기");
        }      
    
        ///////////////////////////////////////////////////     버 튼    ////////////////////////////////////////// //////////////////          버튼

        private string Current_Directory;
        private void button1_Click(object sender, EventArgs e)   // 저장 버튼
        {            
            Loading_On = false;
            Mashine_Num = Convert.ToInt32(numericUpDown19.Value);

            Current_Directory = System.IO.Directory.GetCurrentDirectory();
            Current_Directory = Current_Directory + "\\" + Mashine_Num + "\\" +"lev0.tab";
            FileInfo Fi = new FileInfo(Current_Directory);         
          
          
            Header[0] = 10000000;                          // 헤더 0 테이블 데이터 최대값         1
            Header[1] = Convert.ToInt32(textBox2.Text);    // 헤더 1 테이블 갯수                  2 테이블 갯수   
            Header[2] = Convert.ToInt32(textBox3.Text);    // 헤더 2 크레딧 퍼센트                3 리미트
            Header[3] = Convert.ToInt32(textBox4.Text);    // 헤더 3 리미트                       4 5000 최대 값
            Header[4] = Convert.ToInt32(textBox5.Text);    // 헤더 4 적립중 큰 점수 배출 확률     5 2만 최대 값
            Header[5] = Convert.ToInt32(textBox6.Text);    // 헤더 5 적립중 작은 점수 배출 확률   6 3만 최대 값
            Header[6] = Convert.ToInt32(textBox7.Text);    // 헤더 6 평균 퍼센트                  7 5만 최대값
            Header[7] = Convert.ToInt32(textBox8.Text);    // 헤더 7 작은 점수 배출 확률          8
            Header[8] = Convert.ToInt32(textBox9.Text);    // 헤더 8 중간 점수 배출 확률          9
            Header[9] = Convert.ToInt32(textBox10.Text);   // 헤더 9 큰   점수 배출 확률         10

          
            if (Fi.Exists)
            {               
                WriteData_File();
            }
            else
            {
                MakeData_File();
                WriteData_File();
            }
            Loading_On = true;
            label1.Focus();
        }
        private void button2_Click(object sender, EventArgs e)                           // 파일 오픈 버튼
        {
            Loading_On = false;
            OpenFileDialog OD = new OpenFileDialog();
            OD.Title = "fileOpen";
            OD.Filter = "Txt Data_|*.tab";
            if(OD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataTblReset_Process();
                string filePath = "";
                filePath = OD.FileName;
             
                ReadData_File(filePath);                                                // 파일 읽기
                               
                Mainchart_Minmum_X = 0;
                Mainchart_Maxmum_X = 500000;
                Mainchart_Interval_X = 100000;
            
                ReLineChart();
                CurrentPro();
                Percent_Process();
                LabelColor_Clear();
            }
            Loading_On = true;
            MainChart_On = true;
            LineChart_On = true;
            label1.Focus();
        }
      
        private bool Make_On;
        private void button4_Click(object sender, EventArgs e)                           /// 생성
        {
            Loading_On = false;
            for (int dataloop = 0; dataloop < DataTbl.Length; dataloop++)
                DataTbl[dataloop] = 0;

            LineChart_On = true;
            Make_On = true;

            LabelColor_Clear();     // 선택 라벨 클리어
            Random_Make_Process();  // 랜덤 생성      
            ReLineChart();
          
            Loading_On = true;
            label1.Focus();
          
            MessageBox.Show("생성 완료");
        }
       /// <summary>
       /// ////////////////////////////////  버튼 5  초기화                   ///////////////////////////////////////////////////////
     
        private void button5_Click(object sender, EventArgs e)                   //초기화 
        {
           
            DataTblReset_Process(); // 포인트 스코어 어레이 리셋          

            BaseLineChart();                      
            MainChart.Series[1].Points.Clear();
            MainChart.Series[2].Points.Clear();
            MainChart.Series[3].Points.Clear();
            MainChart.Series[4].Points.Clear();
            MainChart.Series[5].Points.Clear();
            BaseMainChart();
            MainChart_On = false;
            LineChart_On = false;
            Make_On = false;
           
        }
        private int Mashine_Num;
        private void MakeData_File()
        {
            Mashine_Num = Convert.ToInt32(numericUpDown19.Value);
            Current_Directory = Directory.GetCurrentDirectory();
            Current_Directory = Current_Directory + "\\" + Mashine_Num;
            DirectoryInfo di = new DirectoryInfo(Current_Directory);
            if (di.Exists == false)
                di.Create();

            Current_Directory = Current_Directory + "\\" + "lev0.tab";
            System.IO.FileStream FFs = new System.IO.FileStream(Current_Directory, FileMode.Create);
            FFs.Close();
        }
        private int File_Loop;
        public int[] Header = new int[10];
        public int[] TableData = new int[10000];
        private int[] DataToTotal_Arr = new int[10003];

        private void WriteData_File()
        {         
            FileStream FFs = new FileStream(Current_Directory, FileMode.Open);
            BinaryWriter Bw = new BinaryWriter(FFs);
           
            for (int k = 0; k < DataToTotal_Arr.Length; k++)
                DataToTotal_Arr[k] = 0;

            //for (int k = 0; k < 10; k++)
            //    DataToTotal_Arr[k] = Header[k];
            DataToTotal_Arr[0] = Header[0];
            DataToTotal_Arr[1] = Header[1];
            DataToTotal_Arr[2] = Header[2];

            for (File_Loop = 0; File_Loop < DataTbl.Length; File_Loop++)
            {
                DataToTotal_Arr[File_Loop + 3] = DataTbl[File_Loop];              
            }

            for (File_Loop = 0; File_Loop < DataToTotal_Arr.Length; File_Loop++)
            {
                Bw.Write(DataToTotal_Arr[File_Loop]);
            }
            Bw.Close();
            FFs.Close();
            MessageBox.Show("저장 완료");
        }
        private void ReadData_File(string filepath)
        {
            //Mashine_Num = Convert.ToInt32(numericUpDown19.Value);
            //Current_Directory = Directory.GetCurrentDirectory();
            //Current_Directory = Current_Directory + "\\" + Mashine_Num + "\\" + "level.tbl";
            Current_Directory = filepath;
            FileStream FFs = new FileStream(Current_Directory, FileMode.Open);
            BinaryReader Br = new BinaryReader(FFs);
            for (int valueloop = 0; valueloop < DataToTotal_Arr.Length; valueloop++)
                DataToTotal_Arr[valueloop] = 0;

            for (int dataloop = 0; dataloop < DataTbl.Length; dataloop++)
                DataTbl[dataloop] = 0;

            for (File_Loop = 0; File_Loop < 10010; File_Loop++)
            {
                DataToTotal_Arr[File_Loop] = Br.ReadInt32();
                if (File_Loop < 10)
                    Header[File_Loop] = DataToTotal_Arr[File_Loop];

                if ( File_Loop > 9)                
                    DataTbl[File_Loop - 10] = DataToTotal_Arr[File_Loop];      
            }

            for (int dataloop = 0; dataloop < 25; dataloop++)
                Value_Arr[dataloop] = 0;

            for (int dataloop = 0; dataloop < DataTbl.Length; dataloop++)
                ValueArrRead_Process(DataTbl[dataloop]);          

            numericUpDown1.Value = Value_Arr[ValueArr_20000];    
            numericUpDown2.Value = Value_Arr[ValueArr_30000];
            numericUpDown3.Value = Value_Arr[ValueArr_40000];
            numericUpDown4.Value = Value_Arr[ValueArr_50000];
            numericUpDown5.Value = Value_Arr[ValueArr_60000];  
            numericUpDown6.Value = Value_Arr[ValueArr_70000];
            numericUpDown7.Value = Value_Arr[ValueArr_80000];
            numericUpDown8.Value = Value_Arr[ValueArr_90000];
            numericUpDown9.Value = Value_Arr[ValueArr_100000];     
            numericUpDown10.Value = Value_Arr[ValueArr_150000];
            numericUpDown11.Value = Value_Arr[ValueArr_200000];
            numericUpDown12.Value = Value_Arr[ValueArr_250000];
            numericUpDown13.Value = Value_Arr[ValueArr_300000];   
            numericUpDown14.Value = Value_Arr[ValueArr_400000];
            numericUpDown15.Value = Value_Arr[ValueArr_500000];
            numericUpDown16.Value = Value_Arr[ValueArr_600000];
            numericUpDown17.Value = Value_Arr[ValueArr_700000];
            numericUpDown18.Value = Value_Arr[ValueArr_2000];          

            Br.Close();
            FFs.Close();
            MessageBox.Show("읽기 완료");
        }
       
        private void ValueArrRead_Process(int val)
        {
            if (val > 0)
            {
                if (val > 19000 && val < 30000)
                    Value_Arr[ValueArr_20000]++;

                if (val > 29000 && val < 40000)
                    Value_Arr[ValueArr_30000]++;

                if (val > 39000 && val < 50000)
                    Value_Arr[ValueArr_40000]++;

                if (val > 49000 && val < 60000)
                    Value_Arr[ValueArr_50000]++;

                if (val > 59000 && val < 70000)
                    Value_Arr[ValueArr_60000]++;

                if (val > 69000 && val < 80000)
                    Value_Arr[ValueArr_70000]++;

                if (val > 79000 && val < 90000)
                    Value_Arr[ValueArr_80000]++;

                if (val > 89000 && val < 100000)
                    Value_Arr[ValueArr_90000]++;

                if (val > 99000 && val < 150000)
                    Value_Arr[ValueArr_100000]++;

                if (val > 149000 && val < 200000)
                    Value_Arr[ValueArr_150000]++;

                if (val > 199000 && val < 250000)
                    Value_Arr[ValueArr_200000]++;

                if (val > 249000 && val < 300000)
                    Value_Arr[ValueArr_250000]++;

                if (val > 299000 && val < 400000)
                    Value_Arr[ValueArr_300000]++;

                if (val > 399000 && val < 500000)
                    Value_Arr[ValueArr_400000]++;

                if (val > 499000 && val < 600000)
                    Value_Arr[ValueArr_500000]++;

                if (val > 599000 && val < 700000)
                    Value_Arr[ValueArr_600000]++;
             
                if (val > 699000 && val < 1000000)
                    Value_Arr[ValueArr_700000]++;
                if (val == 2000)
                    Value_Arr[ValueArr_2000]++;
            }
        }
             
        private void DataTblReset_Process() // 포인트 스코어 어레이 리셋
        {
            for (int dataloop = 0; dataloop < DataTbl.Length; dataloop++)
            {
                DataTbl[dataloop] = 0;
            }
        }
        private void ComboBox_BaseValue()
        {
            //this.comboBox1.Items.Add("Save.Dat");          

            comboBox1.Text = "50000";
          
            this.comboBox1.Items.Add("30000");
            this.comboBox1.Items.Add("40000");
            this.comboBox1.Items.Add("45000");
            this.comboBox1.Items.Add("50000");


            this.comboBox1.Items.Add("55000");
            this.comboBox1.Items.Add("60000");
            this.comboBox1.Items.Add("65000");
            this.comboBox1.Items.Add("70000");
            this.comboBox1.Items.Add("75000");
            this.comboBox1.Items.Add("80000");
            this.comboBox1.Items.Add("85000");
            this.comboBox1.Items.Add("90000");
            this.comboBox1.Items.Add("95000");
            this.comboBox1.Items.Add("100000");


            this.comboBox2.Items.Add("10000000");
            this.comboBox2.Items.Add("20000000");
            this.comboBox2.Items.Add("30000000");       
            this.comboBox2.Items.Add("40000000");
            this.comboBox2.Items.Add("50000000");          
            this.comboBox2.Items.Add("60000000");
            this.comboBox2.Items.Add("70000000");
            this.comboBox2.Items.Add("80000000");
            this.comboBox2.Items.Add("90000000");
            this.comboBox2.Items.Add("100000000");

            comboBox2.Text = "10000000";

            this.comboBox3.Items.Add("20000");
            this.comboBox3.Items.Add("21000");
            this.comboBox3.Items.Add("22000");
            this.comboBox3.Items.Add("23000");
            this.comboBox3.Items.Add("24000");
            this.comboBox3.Items.Add("25000");
            this.comboBox3.Items.Add("26000");
            this.comboBox3.Items.Add("27000");
            this.comboBox3.Items.Add("28000");
            this.comboBox3.Items.Add("29000");
            this.comboBox3.Items.Add("30000");

            this.comboBox3.Items.Add("50000");

            this.comboBox3.Items.Add("55000");
            this.comboBox3.Items.Add("60000");
            this.comboBox3.Items.Add("65000");
            this.comboBox3.Items.Add("70000");
            this.comboBox3.Items.Add("75000");
            this.comboBox3.Items.Add("80000");
            this.comboBox3.Items.Add("85000");
            this.comboBox3.Items.Add("90000");
            this.comboBox3.Items.Add("95000");
            this.comboBox3.Items.Add("100000");

            this.comboBox3.Items.Add("105000");
            this.comboBox3.Items.Add("110000");
            this.comboBox3.Items.Add("115000");
            this.comboBox3.Items.Add("120000");
            this.comboBox3.Items.Add("125000");
            this.comboBox3.Items.Add("130000");
            this.comboBox3.Items.Add("135000");
            this.comboBox3.Items.Add("140000");
            this.comboBox3.Items.Add("145000");
            this.comboBox3.Items.Add("150000");

            this.comboBox3.Items.Add("155000");
            this.comboBox3.Items.Add("160000");
            this.comboBox3.Items.Add("165000");
            this.comboBox3.Items.Add("170000");
            this.comboBox3.Items.Add("175000");
            this.comboBox3.Items.Add("180000");
            this.comboBox3.Items.Add("185000");
            this.comboBox3.Items.Add("190000");
            this.comboBox3.Items.Add("195000");       
            this.comboBox3.Items.Add("200000");

            this.comboBox3.Items.Add("205000");
            this.comboBox3.Items.Add("210000");
            this.comboBox3.Items.Add("215000");
            this.comboBox3.Items.Add("220000");
            this.comboBox3.Items.Add("225000");
            this.comboBox3.Items.Add("230000");
            this.comboBox3.Items.Add("235000");
            this.comboBox3.Items.Add("240000");
            this.comboBox3.Items.Add("245000");
            this.comboBox3.Items.Add("250000");

            this.comboBox3.Items.Add("255000");
            this.comboBox3.Items.Add("260000");
            this.comboBox3.Items.Add("265000");
            this.comboBox3.Items.Add("270000");
            this.comboBox3.Items.Add("275000");
            this.comboBox3.Items.Add("280000");
            this.comboBox3.Items.Add("285000");
            this.comboBox3.Items.Add("290000");
            this.comboBox3.Items.Add("295000");
            this.comboBox3.Items.Add("300000");
           
            this.comboBox3.Items.Add("400000");
            this.comboBox3.Items.Add("500000");
            this.comboBox3.Items.Add("600000");
            this.comboBox3.Items.Add("700000");
            this.comboBox3.Items.Add("800000");
            this.comboBox3.Items.Add("900000");
            this.comboBox3.Items.Add("1000000");         

           
            comboBox4.Text = "10000";

            this.comboBox4.Items.Add("10000");
            this.comboBox4.Items.Add("20000");
            this.comboBox4.Items.Add("30000");
            this.comboBox4.Items.Add("40000");
            TextBox_PositionSize();
        }

        private void LabelColor_Clear()  
        {
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;
            label11.ForeColor = Color.Black;
            label12.ForeColor = Color.Black;
            label13.ForeColor = Color.Black;
            label14.ForeColor = Color.Black;
            label15.ForeColor = Color.Black;
            label16.ForeColor = Color.Black;
            label17.ForeColor = Color.Black;
            label18.ForeColor = Color.Black;
            label19.ForeColor = Color.Black;
            label20.ForeColor = Color.Black;
            label21.ForeColor = Color.Black;
            label22.ForeColor = Color.Black;          
        }
         
      
      
        private void SecterTotal_Process(int low,int hig)
        {
            int min = low;
            int secter_index = 0;
            int secter_total = 0;
            while(min < hig)
            {
                secter_index = min / 1000;
                secter_total += DataTbl[secter_index]; 
                min += 1000;
              
            }
            label30.Text = String.Format("{0:#,###}", secter_total); 
        }

        private int Current_TotalSize;
     
       
        private void TextBox_PositionSize()///////////////////////////////////////////////////// 디자인 ///////
        {          
            numericUpDown1.Size = new Size (46, 20);
            numericUpDown1.Location = new Point(51, 7);
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
            numericUpDown1.Maximum = 2000;

            numericUpDown2.Size = new Size(46, 20);
            numericUpDown2.Location = new Point(51, 30);
            numericUpDown2.TextAlign = HorizontalAlignment.Center;
            numericUpDown2.Maximum = 1000;

            numericUpDown3.Size = new Size(46, 20);
            numericUpDown3.Location = new Point(51, 53);
            numericUpDown3.TextAlign = HorizontalAlignment.Center;
            numericUpDown3.Maximum = 1000;

            numericUpDown4.Size = new Size(46, 20);
            numericUpDown4.Location = new Point(51, 76);
            numericUpDown4.TextAlign = HorizontalAlignment.Center;
            numericUpDown4.Maximum = 1000;

            numericUpDown5.Size = new Size(46, 20);
            numericUpDown5.Location = new Point(51, 99);
            numericUpDown5.TextAlign = HorizontalAlignment.Center;
            numericUpDown5.Maximum = 500;

            numericUpDown6.Size = new Size(46, 20);
            numericUpDown6.Location = new Point(51, 122);
            numericUpDown6.TextAlign = HorizontalAlignment.Center;
            numericUpDown6.Maximum = 500;

            this.label5.Location = new Point(32,12);
            this.label6.Location = new Point(32, 34);
            this.label7.Location = new Point(32, 56);
            this.label8.Location = new Point(32, 78);
            this.label9.Location = new Point(32, 100);
            this.label10.Location = new Point(32, 122);

            ///////////////////////////////////////////////////////////
            numericUpDown7.Size = new Size(46, 20);
            numericUpDown7.Location = new Point(143, 7);
            numericUpDown7.TextAlign = HorizontalAlignment.Center;
            numericUpDown7.Maximum = 500;

            numericUpDown8.Size = new Size(46, 20);
            numericUpDown8.Location = new Point(143, 30);
            numericUpDown8.TextAlign = HorizontalAlignment.Center;
            numericUpDown8.Maximum = 500;

            numericUpDown9.Size = new Size(46, 20);
            numericUpDown9.Location = new Point(143, 53);
            numericUpDown9.TextAlign = HorizontalAlignment.Center;
            numericUpDown9.Maximum = 500;

            numericUpDown10.Size = new Size(46, 20);
            numericUpDown10.Location = new Point(143, 76);
            numericUpDown10.TextAlign = HorizontalAlignment.Center;
            numericUpDown10.Maximum = 500;

            numericUpDown11.Size = new Size(46, 20);
            numericUpDown11.Location = new Point(143, 99);
            numericUpDown11.TextAlign = HorizontalAlignment.Center;
            numericUpDown11.Maximum = 200;

            numericUpDown12.Size = new Size(46, 20);
            numericUpDown12.Location = new Point(143, 122);
            numericUpDown12.TextAlign = HorizontalAlignment.Center;
            numericUpDown12.Maximum = 200;

            this.label11.Location = new Point(120, 12);
            this.label12.Location = new Point(120, 34);
            this.label13.Location = new Point(120, 56);
            this.label14.Location = new Point(120, 78);
            this.label15.Location = new Point(120, 100);
            this.label16.Location = new Point(120, 122);
            /////////////////////////////////////////////////////////////////////////


            numericUpDown13.Size = new Size(46, 20);
            numericUpDown13.Location = new Point(254, 7);
            numericUpDown13.TextAlign = HorizontalAlignment.Center;
            numericUpDown13.Maximum = 200;

            numericUpDown14.Size = new Size(46, 20);
            numericUpDown14.Location = new Point(254, 30);
            numericUpDown14.TextAlign = HorizontalAlignment.Center;
            numericUpDown14.Maximum = 200;

            numericUpDown15.Size = new Size(46, 20);
            numericUpDown15.Location = new Point(254, 53);
            numericUpDown15.TextAlign = HorizontalAlignment.Center;
            numericUpDown15.Maximum = 200;

            numericUpDown16.Size = new Size(46, 20);
            numericUpDown16.Location = new Point(254, 76);
            numericUpDown16.TextAlign = HorizontalAlignment.Center;
            numericUpDown16.Maximum = 200;

            numericUpDown17.Size = new Size(46, 20);
            numericUpDown17.Location = new Point(254, 99);
            numericUpDown17.TextAlign = HorizontalAlignment.Center;
            numericUpDown17.Maximum = 200;

            numericUpDown18.Size = new Size(46, 20);
            numericUpDown18.Location = new Point(254, 122);
            numericUpDown18.TextAlign = HorizontalAlignment.Center;
            numericUpDown18.Maximum = 1000;

            this.label17.Location = new Point(220, 12);
            this.label18.Location = new Point(220, 34);
            this.label19.Location = new Point(220, 56);
            this.label20.Location = new Point(220, 78);
            this.label21.Location = new Point(220, 100);
            this.label22.Location = new Point(220, 122);
           
            numericUpDown1.Value = 150;    // 20000   29000
            numericUpDown2.Value = 50;     // 30000   39000
            numericUpDown3.Value = 5;      // 40000   49000
            numericUpDown4.Value = 5;      // 50000   59000
            numericUpDown5.Value = 3;      // 60000   69000
            numericUpDown6.Value = 3;      // 70000   79000
            numericUpDown7.Value = 3;      // 80000   89000 
            numericUpDown8.Value = 3;      // 90000   99000
            numericUpDown9.Value = 1;      // 100000   149000
            numericUpDown10.Value = 1;     // 150000  199000
            numericUpDown11.Value = 1;     // 200000  249000
            numericUpDown12.Value = 1;     // 250000  290000
            numericUpDown13.Value = 0;     // 300000  400000
            numericUpDown14.Value = 0;     // 400000  500000
            numericUpDown15.Value = 0;     // 500000  600000
            numericUpDown16.Value = 0;     // 60  ---> 70
            numericUpDown17.Value = 0;     // 70  ---> 80
            numericUpDown18.Value = 0;     // 2000 원  
           
            //    this.label21.Location = new Point(220, 100);

        }
       
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value5000] = Convert.ToInt32( numericUpDown1.Value);
            label5.ForeColor = Color.Red;        
          
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value10000] = Convert.ToInt32(numericUpDown2.Value);
            label6.ForeColor = Color.Red;          
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value15000] = Convert.ToInt32(numericUpDown3.Value);
            label7.ForeColor = Color.Red;      
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value20000] = Convert.ToInt32(numericUpDown4.Value);
            label8.ForeColor = Color.Red;         
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value25000] = Convert.ToInt32(numericUpDown5.Value);
            label9.ForeColor = Color.Red;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value30000] = Convert.ToInt32(numericUpDown6.Value);
            label10.ForeColor = Color.Red;
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value35000] = Convert.ToInt32(numericUpDown7.Value);
            label11.ForeColor = Color.Red;
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value40000] = Convert.ToInt32(numericUpDown8.Value);
            label12.ForeColor = Color.Red;
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value45000] = Convert.ToInt32(numericUpDown9.Value);
            label13.ForeColor = Color.Red;
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value50000] = Convert.ToInt32(numericUpDown10.Value);
            label14.ForeColor = Color.Red;
        }
        //=============================================================================================================

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value_55_100] = Convert.ToInt32(numericUpDown11.Value);
            label15.ForeColor = Color.Red;
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value_105_150] = Convert.ToInt32(numericUpDown12.Value);
            label16.ForeColor = Color.Red;
        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value_155_200] = Convert.ToInt32(numericUpDown13.Value);
            label17.ForeColor = Color.Red;
        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value_205_250] = Convert.ToInt32(numericUpDown14.Value);
            label18.ForeColor = Color.Red;
        }

        private void numericUpDown15_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value_255_300] = Convert.ToInt32(numericUpDown15.Value);
            label19.ForeColor = Color.Red;
        }

        private void numericUpDown16_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value_305_350] = Convert.ToInt32(numericUpDown16.Value);
            label20.ForeColor = Color.Red;
        }

        private void numericUpDown17_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value_355_400] = Convert.ToInt32(numericUpDown17.Value);
            label21.ForeColor = Color.Red;
        }
        //========================================================================================================
        private void numericUpDown18_ValueChanged(object sender, EventArgs e)
        {
            LabelColor_Clear();
            Value_Arr[Value_500] = Convert.ToInt32(numericUpDown18.Value);
            label22.ForeColor = Color.Red;
        }                  
       
        private void Score_Position()
        {
            int temp = Convert.ToInt32(comboBox1.Text);
            int thousand_20000 = temp / 1000;           
            int score20000Count = Convert.ToInt32(numericUpDown1.Value);
           
            int scoreValue = 0;
            int scorePoint = 0;
            int run_max = 0;
            int run_min = 0;
            int tbl_end = 10000;           
            
            while(true)
            {
                run_max += thousand_20000;              
                if (run_max > tbl_end)
                    break;
                scorePoint = Rand.Next(run_min + 1, run_max);
                scoreValue = Rand.Next(20, 28);
                scoreValue *= 1000;
                while (true)             
                {                   
                    if (DataTbl[scorePoint] == 0)
                    {
                        DataTbl[scorePoint] = scoreValue;
                        break;
                    }
                }
                score20000Count--;
                run_min += thousand_20000;
            }
            if (score20000Count > 0)
            {               
                int secondinter = 10000000 / score20000Count;
                run_min = 0;               
                while (true)
                {
                    run_max = secondinter;
                    if (run_max >= tbl_end)
                        break;
                    while(true)
                    {
                        scorePoint = Rand.Next(run_min, run_max);
                        scoreValue = Rand.Next(20, 28);
                        scoreValue *= 1000;
                        if (DataTbl[scorePoint] == 0)
                        {
                            DataTbl[scorePoint] = scoreValue;
                            break;
                        }
                    }
                    score20000Count--;
                    run_min += thousand_20000;
                }
            }

            if (Value_Arr[ValueArr_30000] > 0)    // 3만           
                DivideValue(30000, Value_Arr[ValueArr_30000]);

            if (Value_Arr[ValueArr_40000] > 0)    // 4만           
                DivideValue(40000, Value_Arr[ValueArr_40000]);

            if (Value_Arr[ValueArr_50000] > 0)    // 5만         
                DivideValue(50000, Value_Arr[ValueArr_50000]);

            if (Value_Arr[ValueArr_60000] > 0)    // 6만           
                DivideValue(60000, Value_Arr[ValueArr_60000]);

            if (Value_Arr[ValueArr_70000] > 0)    // 7만           
                DivideValue(70000, Value_Arr[ValueArr_70000]);

            if (Value_Arr[ValueArr_80000] > 0)    // 6만           
                DivideValue(80000, Value_Arr[ValueArr_80000]);

            if (Value_Arr[ValueArr_90000] > 0)    // 7만           
                DivideValue(90000, Value_Arr[ValueArr_90000]);

            if (Value_Arr[ValueArr_100000] > 0)    // 10만                     
                DivideValue(100000, Value_Arr[ValueArr_100000]);

            if (Value_Arr[ValueArr_150000] > 0)    // 15만            
                DivideValue(150000, Value_Arr[ValueArr_150000]);

            if (Value_Arr[ValueArr_200000] > 0)    // 20만           
                DivideValue(200000, Value_Arr[ValueArr_200000]);

            if (Value_Arr[ValueArr_250000] > 0)    // 25만            
                DivideValue(250000, Value_Arr[ValueArr_250000]);

            if (Value_Arr[ValueArr_300000] > 0)    // 30만          
                DivideValue(300000, Value_Arr[ValueArr_300000]);

            if (Value_Arr[ValueArr_400000] > 0)    // 40만            
                DivideValue(400000, Value_Arr[ValueArr_400000]);

            if (Value_Arr[ValueArr_500000] > 0)    // 50만           
                DivideValue(500000, Value_Arr[ValueArr_500000]);

            if (Value_Arr[ValueArr_2000] > 0)    // 2000           
                Posi2000(Value_Arr[ValueArr_2000]);

        }
        private void Posi2000(int val)
        {
            int interval = Convert.ToInt32(comboBox4.Text);
            int min = 0;
            int maxtemp = interval / 1000;
            int max = maxtemp;           
            int runcount = 0;
            int scorePoint = 0;
            int scoreValue = 2000;            

            while (runcount < val)
            {
                scorePoint = Rand.Next(min, max);
                if (DataTbl[scorePoint] == 0)
                {
                    DataTbl[scorePoint] = scoreValue;
                    min = max;
                    max += maxtemp;
                    runcount++;
                    if (max == 10000)
                    {
                        min = 0;
                        max = maxtemp;
                    }
                }
            }                  
        }
        public int DivideCount;
        private void DivideValue(int val,int con)
        {
            DivideCount = 0;
            int divideinter = DivideInterval_Process(val);
            divideinter /= 1000;
            int dividethousand = 0;
            int dividepoint = 0;
            int dividescore = 0;
            int dividemin = 0;
            int dividemax = 0;
            
            while(true)
            {
                dividemax += divideinter;               
                if (dividemax >= 10000000)
                    break;
                if (val > 20000 && val < 100000)
                    dividethousand = Rand.Next(1, 9);
                else dividethousand = Rand.Next(1, 49);
                dividethousand *= 1000;

                dividescore = val + dividethousand;

                while(true)
                {
                    dividepoint = Rand.Next(dividemin, dividemax);
                   
                    if (DataTbl[dividepoint] == 0)
                    {
                        DataTbl[dividepoint] = dividescore;
                        DivideCount--;
                        break;
                    }
                }
                if (DivideCount == 0)
                    break;
                dividemin += divideinter;
            }
                
        }  
        private int  DivideInterval_Process(int val)
        {
            int retval = 0;
            int totalscore = 10000000;
            switch (val)
            {
                case 30000:
                    DivideCount = Value_Arr[ValueArr_30000];
                    retval = totalscore / Value_Arr[ValueArr_30000];
                    break;
                case 40000:
                    DivideCount = Value_Arr[ValueArr_40000];
                    retval = totalscore / Value_Arr[ValueArr_40000];
                    break;
                case 50000:
                    DivideCount = Value_Arr[ValueArr_50000];
                    retval = totalscore / Value_Arr[ValueArr_50000];
                    break;
                case 60000:
                    DivideCount = Value_Arr[ValueArr_60000];
                    retval = totalscore / Value_Arr[ValueArr_60000];
                    break;
                case 70000:
                    DivideCount = Value_Arr[ValueArr_70000];
                    retval = totalscore / Value_Arr[ValueArr_70000];
                    break;
                case 80000:
                    DivideCount = Value_Arr[ValueArr_80000];
                    retval = totalscore / Value_Arr[ValueArr_80000];
                    break;
                case 90000:
                    DivideCount = Value_Arr[ValueArr_90000];
                    retval = totalscore / Value_Arr[ValueArr_90000];
                    break;
                case 100000:
                    DivideCount = Value_Arr[ValueArr_100000];
                    retval = totalscore / Value_Arr[ValueArr_100000];
                    break;
                case 150000:
                    DivideCount = Value_Arr[ValueArr_150000];
                    retval = totalscore / Value_Arr[ValueArr_150000];
                    break;
                case 200000:
                    DivideCount = Value_Arr[ValueArr_200000];
                    retval = totalscore / Value_Arr[ValueArr_200000];
                    break;
                case 250000:
                    DivideCount = Value_Arr[ValueArr_250000];
                    retval = totalscore / Value_Arr[ValueArr_250000];
                    break;
                case 300000:
                    DivideCount = Value_Arr[ValueArr_300000];
                    retval = totalscore / Value_Arr[ValueArr_300000];
                    break;
                case 400000:
                    DivideCount = Value_Arr[ValueArr_400000];
                    retval = totalscore / Value_Arr[ValueArr_400000];
                    break;
                case 500000:
                    DivideCount = Value_Arr[ValueArr_500000];
                    retval = totalscore / Value_Arr[ValueArr_500000];
                    break;
                default:
                    break;
            }
            return retval;
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)   //테이블 크기
        {
            //Header[0] = Convert.ToInt32(textBox1.Text);
            //Header[0] += 1;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)   // 토탈확률
        {
            Header[1] = Convert.ToInt32(textBox2.Text);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Header[2] = Convert.ToInt32(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text != null)
            Header[3] = Convert.ToInt32(textBox4.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Header[4] = Convert.ToInt32(textBox5.Text);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Header[5] = Convert.ToInt32(textBox6.Text);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Header[6] = Convert.ToInt32(textBox7.Text);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Header[7] = Convert.ToInt32(textBox8.Text);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            Header[8] = Convert.ToInt32(textBox9.Text);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            Header[9] = Convert.ToInt32(textBox10.Text);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.D)
                Delete_Bar_Process();
            if (e.KeyData == Keys.Space)
                InsertBar_Process();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            NumMeric_Save();
        }
        int[] Nummeric_Data = new int[18];
        private void NumMeric_Save()
        {
            Loading_On = false;
            Mashine_Num = Convert.ToInt32(numericUpDown19.Value);

            Current_Directory = Directory.GetCurrentDirectory();
            Current_Directory = Current_Directory + "\\" + "Count.Dat";
            FileInfo Fi = new FileInfo(Current_Directory);
          
            Nummeric_Data[0] = Convert.ToInt32(numericUpDown1.Value);
            Nummeric_Data[1] = Convert.ToInt32(numericUpDown2.Value);
            Nummeric_Data[2] = Convert.ToInt32(numericUpDown3.Value);
            Nummeric_Data[3] = Convert.ToInt32(numericUpDown4.Value);
            Nummeric_Data[4] = Convert.ToInt32(numericUpDown5.Value);
            Nummeric_Data[5] = Convert.ToInt32(numericUpDown6.Value);
            Nummeric_Data[6] = Convert.ToInt32(numericUpDown7.Value);
            Nummeric_Data[7] = Convert.ToInt32(numericUpDown8.Value);
            Nummeric_Data[8] = Convert.ToInt32(numericUpDown9.Value);
            Nummeric_Data[9] = Convert.ToInt32(numericUpDown10.Value);

            Nummeric_Data[10] = Convert.ToInt32(numericUpDown11.Value);
            Nummeric_Data[11] = Convert.ToInt32(numericUpDown12.Value);
            Nummeric_Data[12] = Convert.ToInt32(numericUpDown13.Value);
            Nummeric_Data[13] = Convert.ToInt32(numericUpDown14.Value);
            Nummeric_Data[14] = Convert.ToInt32(numericUpDown15.Value);
            Nummeric_Data[15] = Convert.ToInt32(numericUpDown16.Value);
            Nummeric_Data[16] = Convert.ToInt32(numericUpDown17.Value);
            Nummeric_Data[17] = Convert.ToInt32(numericUpDown18.Value);

            if (Fi.Exists)
            {
                DataWrite_File();
            }
            else
            {
                DataFile_Make();
                DataWrite_File();
            }
            Loading_On = true;
            label1.Focus();
        }
        private void DataWrite_File()
        {
            FileStream FFs = new FileStream(Current_Directory, FileMode.Open);
            BinaryWriter Bw = new BinaryWriter(FFs);

            for (int i = 0; i < Nummeric_Data.Length; i++)
            {
                Bw.Write(Nummeric_Data[i]);
            }              
            Bw.Close();
            FFs.Close();
            MessageBox.Show("저장 완료");
        }
        private void DataFile_Make()
        {
           // Mashine_Num = Convert.ToInt32(numericUpDown19.Value);
            Current_Directory = Directory.GetCurrentDirectory();
           
            //DirectoryInfo di = new DirectoryInfo(Current_Directory);
            //if (di.Exists == false)
            //    di.Create();

            Current_Directory = Current_Directory + "\\" + "Count.Dat";
            FileStream FFs = new FileStream(Current_Directory, FileMode.Create);
            FFs.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            NumMeric_Load();
        }
        private void NumMeric_Load()
        {
            Loading_On = false;
            OpenFileDialog OD = new OpenFileDialog();
            OD.Title = "fileOpen";
            OD.Filter = "Txt Data_|*.Dat";
            if (OD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataTblReset_Process();
                string filePath = "";
                filePath = OD.FileName;

                DataFile_Read(filePath);

            }           
            label1.Focus();
        }
        private void DataFile_Read(string filepath)
        {            
            FileStream FFs = new FileStream(filepath, FileMode.Open);
            BinaryReader Br = new BinaryReader(FFs);
          

            for (int dataloop = 0; dataloop < Nummeric_Data.Length; dataloop++)
                Nummeric_Data[dataloop] = 0;

            for (int dataloop = 0; dataloop < Nummeric_Data.Length; dataloop++)           
                Nummeric_Data[dataloop] = Br.ReadInt32();
              
          

            numericUpDown1.Value = Nummeric_Data[0];
            numericUpDown2.Value = Nummeric_Data[1];
            numericUpDown3.Value = Nummeric_Data[2];
            numericUpDown4.Value = Nummeric_Data[3];
            numericUpDown5.Value = Nummeric_Data[4];
            numericUpDown6.Value = Nummeric_Data[5];
            numericUpDown7.Value = Nummeric_Data[6];
            numericUpDown8.Value = Nummeric_Data[7];
            numericUpDown9.Value = Nummeric_Data[8];
            numericUpDown10.Value = Nummeric_Data[9];
            numericUpDown11.Value = Nummeric_Data[10];
            numericUpDown12.Value = Nummeric_Data[11];
            numericUpDown13.Value = Nummeric_Data[12];
            numericUpDown14.Value = Nummeric_Data[13];
            numericUpDown15.Value = Nummeric_Data[14];
            numericUpDown16.Value = Nummeric_Data[15];
            numericUpDown17.Value = Nummeric_Data[16];
            numericUpDown18.Value = Nummeric_Data[17];

            Br.Close();
            FFs.Close();
            MessageBox.Show("읽기 완료");
        }
      
    }
}
   
   

