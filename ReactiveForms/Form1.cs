using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactiveForms
{
    public partial class Form1 : Form
    {
        int sourceLabelStartingX, sourceLabelEndingX, sourceLabelStartingY, sourceLabelEndingY;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //traditional
            sourceLabelStartingX = 0;
            sourceLabelStartingY = 0;
            sourceLabelEndingX = 50;
            sourceLabelEndingY = 50;
            ObservableExample();
            //this.MouseMove += Form1_MouseMove;
        }

        private void ObservableExample()
        {              
            var textObservable = Observable.FromEventPattern(txtInput, "TextChanged")
                                    .Select(x => txtInput.Text);
            
            var mouseObservable = Observable.FromEventPattern<MouseEventArgs>(this.lblSource, "MouseMove")                
                .Where(x => fallsWithinLabelBounds(x.EventArgs.Location))
                .Select(x => string.Format("X:{0}, Y:{1}\n", x.EventArgs.Location.X, x.EventArgs.Location.Y));
            
            var combined = Observable.CombineLatest(textObservable, mouseObservable, 
                (t,m) => { return string.Format("{0}-{1}",t,m); });
            
            combined
                .Subscribe(
                    s => lblLog.Text += s,
                    ex => { MessageBox.Show("Ohh no, we had an error"); },
                    () => { MessageBox.Show("We are done"); }
                );
        }

        private bool fallsWithinLabelBounds(Point point)
        {
            if (point.IsEmpty) return false;
            return XIsWithinRange(point.X) && YIsWithinRange(point.Y);                
        }

        private bool YIsWithinRange(int y)
        {
            return y >= sourceLabelStartingY && y <= sourceLabelEndingY;
        }

        private bool XIsWithinRange(int x)
        {
            return x >= sourceLabelStartingX && x <= sourceLabelEndingX;
        }

        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            lblCurrent.Text = string.Format("X:{0}, Y:{1}\n", e.Location.X, e.Location.Y);
            if (fallsWithinLabelBounds(e.Location))
            {
                lblLog.Text += string.Format("**X:{0}, Y:{1}**\n", e.Location.X, e.Location.Y);
            }
        }
    }
}
