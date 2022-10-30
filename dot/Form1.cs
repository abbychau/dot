using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;

namespace dot
{
    public partial class DotForm : Form
    {
        private int mouseX = 0;
        private int mouseY = 0;
        
        public DotForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //hide the title bar
            this.FormBorderStyle = FormBorderStyle.None;
            
            //onload, set windows as transparent
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            //set position to the right hand side of the screen
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, 0);
            //height equals the height of the screen
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            //width equals 1/2 of the screen
            this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
            //left from the middle
            this.Left = Screen.PrimaryScreen.WorkingArea.Width / 2;


            //add a timer to the form
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            g = this.CreateGraphics();
        }
        Graphics g;
        private void Timer_Tick(object sender, EventArgs e)
        {

            if (Cursor.Position.X == mouseX && Cursor.Position.Y == mouseY)
            {
                return;
            }
            //get the mouse position of the screen
            mouseX = Cursor.Position.X;
            mouseY = Cursor.Position.Y;

            //if the mouse is in the left hand side of the screen
            if (mouseX < Screen.PrimaryScreen.WorkingArea.Width / 2)
            {
                //log to console
                Console.WriteLine("Mouse is in the left hand side of the screen");

                //draw a dot at the mouse position on the window
                g.Clear(Color.Black);
                DrawCursor();
                    //g.FillEllipse(Brushes.Red, mouseX, mouseY, 4, 4);

            }
            else
            {
                Console.WriteLine("Mouse is in the right hand side of the screen");
            }
        }
        
        private void DrawCursor()
        {
            
            
            g.FillPath(new SolidBrush(Color.FromArgb(128, 255, 0, 0)), new GraphicsPath(
                new Point[] {
                    new Point(mouseX, mouseY), 
                    new Point(mouseX + 20, mouseY+10), 
                    new Point(mouseX+10 , mouseY +20) 
                }, new byte[] { 0, 1, 1 }));
        }
    }
}