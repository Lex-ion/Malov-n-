using System.Drawing;
using System.Drawing.Imaging;


namespace Malování
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x =0;
        int y =0;


        Color barva = Color.Black;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);

           

            int i=0;
            System.Windows.Forms.RadioButton[] rb = {radioButton1,radioButton2,radioButton3,radioButton4,radioButton5 };
            foreach (RadioButton element in rb)
            {
                i++;
                if (element.Checked)
                {
                    switch (i)
                    {
                        case 1:
                            barva=Color.Black;
                            break;
                        case 2:
                            barva=Color.Red;
                            break;
                        case 4:
                            barva= Color.Green;
                            break;
                        case 3:
                            barva= Color.Blue;
                            break;
                        case 5:
                            barva = Color.White;
                            break;
                    }
                }

            }



            int x1 = (Cursor.Position.X - pictureBox1.Left - this.Left - 6) / 2;
            int y1 = (Cursor.Position.Y - pictureBox1.Top - this.Top - 27) / 2;

            if (Control.MouseButtons == MouseButtons.Left&& x1 >= 0 && x1 <= 299&& y1 >= 0 && y1 <= 299)
            {

                x = x1;
                y=y1;



               

                /*trackBar1.Value=x;
                trackBar2.Value=trackBar2.Maximum-y;*/

                textBox1.Text=x.ToString();
                textBox2.Text=y.ToString();

            }
            

           bitmap.SetPixel(x, y, barva);
            
               
           pictureBox1.Image = bitmap;


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            x = trackBar1.Value;
            textBox1.Text = x.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            y=trackBar2.Maximum-trackBar2.Value;
            textBox2.Text = y.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            trackBar1.Value = Prevod(textBox1.Text);
            x = trackBar1.Value;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           trackBar2.Value=trackBar2.Maximum- Prevod(textBox2.Text);
            y=trackBar2.Maximum- trackBar2.Value;
        }


        public int Prevod(string vstup)
        {
            string predchozi = "0";
            int vystup;
            if (int.TryParse(vstup, out vystup))
            {
                if (vystup < 0)
                {
                     return Convert.ToInt16(predchozi);
                }
                else if (vystup > 299)
                {
                    return Convert.ToInt16(predchozi);
                }else
                {
                    return vystup;
                }

            }
            else return Convert.ToInt16(predchozi);

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);

            for (int i = 0; i < bitmap.Height-1; i++)
            {
                for (int j = 0; j < bitmap.Width-1; j++)
                {
                    bitmap.SetPixel(j, i, barva);
                    pictureBox1.Image = bitmap;

                }
            }
            
           
        }

       
    }
}