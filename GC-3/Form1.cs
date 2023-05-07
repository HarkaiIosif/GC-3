using System.Runtime.CompilerServices;

namespace GC_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            //E1(e);
            E2(e);
        }
        private void E1(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 3);
            Random rnd = new Random();
            int n = 10;
            float l , l_total = 0;
            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                int x = rnd.Next(10, this.ClientSize.Width - 100);
                int y = rnd.Next(10, this.ClientSize.Height - 100);
                points[i] = new Point(x, y);
                g.DrawEllipse(p, x, y, 4, 4);
            }
            
               int ri = 0, rj = 0;
            for (int i = 0; i < n; i++)
            {   
               
                float lmin = float.MaxValue; ri = 0; rj = 0;
                for (int j = i+1; j < n; j++)
                {
                    //while (points[i].IsEmpty && i + 1 < n) i++;
                    //while (points[j].IsEmpty && j + 1 < n) j++;
                    l = (float)Math.Sqrt(Math.Pow(points[i].X - points[j].X, 2) + Math.Pow(points[i].Y - points[j].Y, 2));
                    if (l < lmin)
                    {
                        lmin = l;
                        ri = i; rj = j;
                    }
                }
              g.DrawLine(p, points[ri].X, points[ri].Y, points[rj].X, points[rj].Y);   
            points[ri].X = 0;
            points[ri].Y = 0;
            points[rj].X = 0;
            points[rj].Y = 0;
            l_total += lmin;
                }

            label1.Text = l_total.ToString();
        }
        private  void E2(PaintEventArgs e)
        {
            label1.Text = " ";
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 3);
            Random rnd=new Random();
            int n = 5;
            Point[] initial = new Point[n];
            Point[] final = new Point[n];   
            for(int i = 0; i < n; i++)
            {
                int x = rnd.Next(10, this.ClientSize.Width - 10);
                int y=rnd.Next(10,this.ClientSize.Height - 10);
                initial[i]= new Point(x, y);
                p.Color = Color.Red;
                g.DrawEllipse(p, x, y, 3, 3);
                x = rnd.Next(10, this.ClientSize.Width - 10);
                y = rnd.Next(10, this.ClientSize.Height - 10);
                final[i]= new Point(x, y);
                p.Color = Color.Blue;
                g.DrawEllipse(p,x,y, 3, 3);
                p.Color= Color.Black;
                g.DrawLine(p, initial[i].X, initial[i].Y, final[i].X, final[i].Y);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    
                    float A1,B1,C1,A2,B2,C2,frac;
                    A1 = final[i].Y - initial[i].Y;
                    B1 = initial[i].X - final[i].X;
                    C1 = A1 * initial[i].X + B1 * initial[i].Y;
                    A2 = final[j].Y - initial[j].Y;
                    B2 = initial[j].X - final[j].X; 
                    C2= A2 * initial[j].X+ B2* initial[j].Y;
                    frac=A1*B2-A2*B1;
                    if (frac != 0)
                    {
                        float rx1, ry1, rx2, ry2;
                        float intersectX=(B2*C1-B1*C2)/frac;
                        float intersectY=(A1*C2-A2*C1)/frac;
                        rx1 = (intersectX - initial[i].X) / (final[i].X - initial[i].X);
                        ry1 = (intersectY - initial[i].Y) / (final[i].Y - initial[i].Y);
                        rx2 = (intersectX - initial[j].X)/(final[j].X - initial[j].X);   
                        ry2 = (intersectY - initial[j].Y)/(final[j].Y - initial[j].Y); 
                        if(((rx1>=0&&rx1<=1)||(ry1>=0&&ry1<=1))&&((rx2>=0&&rx2<=1)||(ry2>=0&&ry2<=1)))
                        {
                            p.Color= Color.Yellow;
                            g.DrawEllipse(p,intersectX,intersectY,4,4);
                        }
                    }
                    
                }
            }
        }      
    }
}
