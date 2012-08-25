using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Threading;

namespace PhoneApp2
{
    public partial class MainPage : PhoneApplicationPage
    {
        int size = 50;
        private bool[,] mCells = new bool[8, 8];
        private bool isStopped = new bool();
        private System.Collections.Generic.List<Queen> Queens = new System.Collections.Generic.List<Queen>();
        private System.Collections.Generic.List<TimeSpan> tempos = new System.Collections.Generic.List<TimeSpan>();
        DispatcherTimer dt = new DispatcherTimer();
        TimeSpan rightTime = new TimeSpan();
        public MainPage()
        {
            InitializeComponent();
            DrawBoard();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += new EventHandler(dt_Tick);
            tempos.Insert(0, TimeSpan.FromSeconds(9999));
            tempos.Insert(0, TimeSpan.FromSeconds(9998));
        }
        [System.ComponentModel.Browsable(false)]
        public bool[,] Cells
        {
            get
            {
                return mCells;
            }
            set
            {
                mCells = value;
            }
        }
        void dt_Tick(object sender, EventArgs e)
        {
            rightTime = TimeSpan.FromSeconds(1) + rightTime;
            textTimer.Text = rightTime.ToString();
        }
        private void ChessBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (isStopped == true)
            {
                return;
            }
            System.Windows.Point point = e.GetPosition(null);
            byte rowIndex = (byte)((point.X-25) / size);
            byte colIndex = (byte)((point.Y-205) / size);;
            Queen queen = new Queen(rowIndex, colIndex);
            Int16 index = Exists(ref queen);
            if (Queens.Count < 8)
            {
                if (index > -1)
                {
                    mCells[rowIndex, colIndex] = false;
                    Queens.RemoveAt(index);
                }
                else
                {
                    //new SolidColorBrush(Colors.Green);
                    if (CanPutQueen(rowIndex, colIndex))
                    {
                        System.Diagnostics.Debug.WriteLine("adicionando");
                        mCells[rowIndex, colIndex] = true;
                        Queens.Add(new Queen(rowIndex, colIndex));
                    }
                }
            }
            DrawBoard();
            if (Queens.Count == 8) {
                dt.Stop();
                FinishGame();
            }
        }
        private void FinishGame()
        {
            for (int i = 0; i < tempos.Count; i++)
            {
                if (rightTime < tempos[i])
                {
                    tempos.Insert(i, rightTime);
                    break;
                }
            }
            pointsFirst.Text = tempos[0].ToString();
            pointsSecond.Text = tempos[1].ToString();
            pointsThird.Text = tempos[2].ToString();
            rightTime = new TimeSpan();
            for (int i = 0; i < Queens.Count; i++)
            {
                Queens.RemoveAt(i);
            }
            mCells = new bool[8, 8];
            pivotGame.SelectedIndex = 2;
            DrawBoard();
        }
        private Int16 Exists(ref Queen Queen)
        {
            if (Queens.Count == 0)
            {
                return -1;
            }
            for (byte i = 0; i < Queens.Count; i++)
            {
                if (Queens[i].Row == Queen.Row && Queens[i].Column == Queen.Column)
                {
                    return i;
                }
            }
            return -1;
        }
        public void DrawBoard()
        {
            bool flip = true;
            for (float i = 0; i <= 7; i++)
            {
                for (float j = 0; j <= 7; j++)
                {
                    GeometryGroup geometry = new GeometryGroup();
                    RectangleGeometry rect = new RectangleGeometry();
                    rect.Rect = new Rect(0, 0, size, size);
                    Path path = new Path();
                    SolidColorBrush color = new SolidColorBrush();
                    if (flip)
                    {
                        color.Color = Colors.Red;
                    }
                    else
                    {
                        color.Color = Colors.White;
                    }
                    path.Fill = color;
                    path.Stroke = new SolidColorBrush(Colors.Black);
                    path.Stretch = Stretch.Fill;
                    path.StrokeThickness = 2.0;
                    path.SetValue(Canvas.LeftProperty, (double)(i * size));
                    path.SetValue(Canvas.TopProperty, (double)(j * size));
                    flip = ((j == 7) ? flip : ! flip);
                    geometry.Children.Add(rect);
                    EllipseGeometry ellipse = new EllipseGeometry();
                    ellipse.Center = new Point(size/2, size/2);
                    ellipse.RadiusX = size/4;
                    ellipse.RadiusY = size/4;
                    if (mCells[(int)i, (int)j])
                    {
                        Queen q = new Queen((byte)i, (byte)j);
                        Int16 index = Exists(ref q);
                        if (index > 0)
                        {
                            if (Queens[index] != null)
                            {
                                if (! (CheckAll(index)))
                                {
                                    geometry.Children.Add(ellipse);
                                }
                                else
                                {
                                    geometry.Children.Add(ellipse);
                                }
                            }
                        }
                        else
                        {
                            geometry.Children.Add(ellipse);
                        }
                    }
                    path.Data = geometry;
                    path.MouseLeftButtonDown += new MouseButtonEventHandler(ChessBoard_MouseDown);
                    this.contentPanel.Children.Add(path);
                }
            }
        }
        private bool CanPutQueen(int x, int y)
        {
            for (int i = 0; i <= 7; i++)
            {
                if (mCells[x, i] == true || mCells[i, y] == true)
                {
                    return false;
                }
                if (x - i >= 0 && y - i >= 0)
                {
                    if (mCells[x - i, y - i] == true)
                    {
                        return false;
                    }
                }
                if (x + i < 8 && y + i < 8)
                {
                    if (mCells[x + i, y + i] == true)
                    {
                        return false;
                    }
                }
                if (x + i < 8 && y - i >= 0)
                {
                    if (mCells[x + i, y - i] == true)
                    {
                        return false;
                    }
                }
                if (x - i >= 0 && y + i < 8)
                {
                    if (mCells[x - i, y + i] == true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool CheckAll(int Level)
        {
            for (int i = Level; i >= 0; i--)
            {
            for (int j = i - 1; j >= 0; j--)
                {
                    if (Queens[i].Row == Queens[j].Row || Queens[i].Column == Queens[j].Column || Queens[i].Row + Queens[i].Column == Queens[j].Row + Queens[j].Column | Queens[i].Row - Queens[j].Row == Queens[i].Column - Queens[j].Column)
                {
                    return false;
                    }
                }
            }
            return true;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btIniciar_Click(object sender, RoutedEventArgs e)
        {
            dt.Start();
            pivotGame.SelectedIndex = 1;
        }
        private void btRanking_Click(object sender, RoutedEventArgs e)
        {

            pivotGame.SelectedIndex = 2;
        }
        private void stopContinue_Click(object sender, RoutedEventArgs e)
        {
            if ((string)(stopContinue.Content.ToString()) == "stop")
            {
                stopContinue.Content = "start";
                isStopped = true;
                dt.Stop();
            }
            else
            {
                stopContinue.Content = "stop";
                isStopped = false;
                dt.Start();
            }
        }
    }
}