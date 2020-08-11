using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUChair
{
    public partial class UserControl1 : UserControl
    {
        public event EventHandler buttonClick;
        public event EventHandler labelClick;
        

        public string ButtenText
        {
            get { return button1.Text; }
            set { button1.Text = value; }
        }
        private bool isOnClick = false;

        public bool IsOnClick
        {
            get { return isOnClick; }
            set { 
                isOnClick = value;
                if (value)
                {
                    label1.Image = Properties.Resources.star_02;
                }
                else
                {
                    label1.Image = Properties.Resources.star_1;
                }
            }
        }

        public UserControl1()
        {
            InitializeComponent();
            
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonClick != null)
            {
                buttonClick(this, null);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (labelClick != null)
            {
                labelClick(this, null);
            }
        }
    }
}
