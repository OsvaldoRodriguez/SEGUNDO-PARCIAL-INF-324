using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;

namespace SEGUNDO_PARCIAL_OFICIAL
{
    public partial class Form1 : Form
    {
        Dictionary<int, Color> tipos_col = new Dictionary<int, Color>();
        Dictionary<int, PuntoColor> adicionado = new Dictionary<int, PuntoColor>();

        int clave = 1;


        Bitmap bmp;
        int x, y; // cordenadas a leer mediante mouse
        int offset = 10;
        double mediaR = 0, mediaG = 0, mediaB = 0;
        int offset1 = 20;
        public Form1()
        {
            InitializeComponent();
            adicionado.Clear();


            dataGridView1.ClearSelection();
            //tipos_col.Add("Verde", Color.Chartreuse);
            //tipos_col.Add("Celeste", Color.Aqua);
            //tipos_col.Add("Lila", Color.Purple);
            //tipos_col.Add("Rosado", Color.Fuchsia);
            //tipos_col.Add("Azul", Color.Blue);
            //tipos_col.Add("Cafe", Color.DarkRed);

            tipos_col.Add(1, Color.Chartreuse);
            tipos_col.Add(2, Color.Aqua);
            tipos_col.Add(3, Color.Purple);
            tipos_col.Add(4, Color.Blue);
            tipos_col.Add(5, Color.DarkRed);
            tipos_col.Add(6, Color.Fuchsia);
            tipos_col.Add(7, Color.Yellow);
            tipos_col.Add(8, Color.Gold);
            
            //button1.BackColor = Color.Chartreuse;
            clave = 1;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos|*.*|Archivos JPEG|*.jpg|Archivos GIF|*.gif";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;

            dataGridView1.ClearSelection();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count < 8)
            {

                x = e.X;
                y = e.Y;
                PuntoColor tmp = new PuntoColor();
                Color c = new Color();
                mediaB = mediaG = mediaR = 0;
                for (int i = x; i < x + offset; i++)
                {
                    for (int j = y; j < y + offset; j++)
                    {
                        c = bmp.GetPixel(i, j);
                        mediaR += c.R;
                        mediaG += c.G;
                        mediaB += c.B;

                    }
                }
                // ahora si sacamos el promedio
                mediaR /= (double)(offset * offset);
                mediaG /= (double)(offset * offset);
                mediaB /= (double)(offset * offset);

                textBox1.Text = mediaR.ToString();
                textBox2.Text = mediaG.ToString();
                textBox3.Text = mediaB.ToString();

                textBox4.Text = x.ToString();
                textBox5.Text = y.ToString();

                //textBox6.Text = mediaB.ToString();

                tmp.x = x;
                tmp.y = y;
                tmp.mediaR = mediaR;
                tmp.mediaG = mediaG;
                tmp.mediaB = mediaB;
                adicionado.Add(clave, tmp);



                clave += 1;

                int tamanio = 0;
                string texto_completo = "";
                foreach (var valores in adicionado)
                {
                    tamanio++;
                    Console.WriteLine("{0} {1}", valores.Key, valores.Value);
                    texto_completo += valores.Key.ToString() + " " + valores.Value.concat();
                    texto_completo += "()";

                }

                //textBox6.Text = texto_completo;
                adicionarColor();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            dataGridView1.ClearSelection();
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();

            // lo pinto  mas antes
            for (int i = 0; i < bmp2.Width; i++)
            {
                for (int j = 0; j < bmp2.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                }
            }

            for (int i = 0; i < bmp.Width - offset; i += offset) {
                for (int j = 0; j < bmp.Height - offset; j += offset){
                    // sacamos la media de cuadrados de tamaño offset
                    double mRn = 0, mGn = 0, mBn = 0;
                    for (int i2 = i; i2 < i + offset; i2++) {
                        for (int j2 = j; j2 < j + offset; j2++) {
                            c = bmp.GetPixel(i2, j2);
                            mRn += c.R;
                            mGn += c.G;
                            mBn += c.B;
                        }
                    }

                    // calculando la media
                    mRn /= (double)(offset * offset);
                    mGn /= (double)(offset * offset);
                    mBn /= (double)(offset * offset);

                    // verificando si cumple

                    foreach(var valores in adicionado){
                        PuntoColor tmp = valores.Value;
                        double mediaR1 = tmp.mediaR;
                        double mediaG1 = tmp.mediaG;
                        double mediaB1 = tmp.mediaB;

                        if( ((mediaR1 - offset1 <= mRn) && (mRn <= mediaR1 + offset1)) &&
                        ((mediaG1 - offset1 <= mGn) && (mGn <= mediaG1 + offset1)) &&
                        ((mediaB1 - offset1 <= mBn) && (mBn <= mediaB1 + offset1)))
                        {


                            // Obteniendo el color para pintar
                            
                            int colorsito = valores.Key;
                            for (int i2 = i; i2 < i + offset; i2++)
                            {
                                for (int j2 = j; j2 < j + offset; j2++)
                                {
                                    bmp2.SetPixel(i2, j2, tipos_col[colorsito]);
                                }
                            }
                        }
                        else
                        {
                            /*
                            for (int i2 = i; i2 < i + offset; i2++)
                            {
                                for (int j2 = j; j2 < j + offset; j2++)
                                {
                                    c = bmp.GetPixel(i2, j2);
                                    bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                                }
                            }
                             * */
                        }
                    }
                    


                }
            }

            pictureBox1.Image = bmp2;

            if (dataGridView1.Rows.Count == 8)
            {
                button3.Enabled = false;
            }


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // hay que rescatar el offet

            offset = Int32.Parse(textBox6.Text.ToString());
            offset1 = Math.Min(15, offset * 3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp2.Width; i++) {
                for (int j = 0; j < bmp2.Height; j++) {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                }
            }
            pictureBox1.Image = bmp2;

            // limpiando el  mapa
            adicionado.Clear();
            clave = 1;

            /// lipiando texto
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";



            //dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            button3.Enabled = true;
        }


        public void adicionarColor()
        {

            dataGridView1.ClearSelection();
            dataGridView1.Rows.Add();
            int filas = dataGridView1.Rows.Count - 1; // index 0
            PuntoColor tmp = adicionado[filas + 1];
            //dataGridView1[1, filas].Value = filas + 1;
            dataGridView1[0, filas].Value = tmp.x.ToString();
            dataGridView1[1, filas].Value = tmp.y.ToString();
            dataGridView1[2, filas].Value = tmp.mediaR.ToString();
            dataGridView1[3, filas].Value = tmp.mediaG.ToString();
            dataGridView1[4, filas].Value = tmp.mediaB.ToString();

            // color promedio
            Color micolor = Color.FromArgb((int)tmp.mediaR, (int)tmp.mediaG, (Int32)tmp.mediaB);
            dataGridView1[5, filas].Style.BackColor = micolor;
            dataGridView1[6, filas].Style.BackColor = tipos_col[filas + 1];

            dataGridView1.ClearSelection();
            //dataGridView1[6, filas].Value = textBox1.Text;
            //dataGridView1[7, filas].Value = textBox1.Text; 
        }


       
        // id_color  x, y, r, g, b, mr, mg, mb, color_original, color_pintar
       


    }
}
