using System.Drawing;
using System.Windows.Forms;
using FiguresLib;
using RPN;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init.bitmap = new Bitmap(pictureBoxDisplay.ClientSize.Width, pictureBoxDisplay.ClientSize.Height);
            Init.pen = new Pen(Color.Black, 3);
            Init.pictureBox = pictureBoxDisplay;
            ExpHandler.comboBoxConsole = comboBoxConsole;
        }

        private void textBoxInputString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExpHandler.LineProcessing(textBoxInputString.Text);
            }
        }
    }
}
