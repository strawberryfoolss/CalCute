using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalCute_Sc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private decimal resPar = 0;
        private string op = "";
        private bool esNuevaEntrada = false;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string num = button.Content.ToString();

            if (PantallaNum.Text == "0" || esNuevaEntrada)
            {
                PantallaNum.Text = num;
                esNuevaEntrada = false;
            }
            else
            {
                PantallaNum.Text += num;
            }
        }

        private void Punto_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (!PantallaNum.Text.Contains("."))
            {
                PantallaNum.Text += ".";
            }


        }
        private void Sign_Click(object sender, RoutedEventArgs e)
        {

            if (decimal.TryParse(PantallaNum.Text, out decimal num))
            {
                num *= -1;
                PantallaNum.Text = num.ToString();
            }

        }


        private void Op_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (!string.IsNullOrEmpty(op))
            {
                calcular();
            }

            op = button.Content.ToString();
            resPar = decimal.Parse(PantallaNum.Text);
            esNuevaEntrada = true;
        }

        private void Res_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(op)) //checa si hay alguna operacion pendiente, si si, la calcula
            {
                calcular();
                op = ""; //ahora ya no hay operacion pendiente
            }
        }
        private void calcular()
        {
            decimal segundNum = decimal.Parse(PantallaNum.Text); //convierte texto a decimal


            switch (op)
            {
                case "+":
                    resPar += segundNum;
                    break;
                case "-":
                    resPar -= segundNum;
                    break;
                case "x":
                    resPar *= segundNum;
                    break;
                case "÷":
                    if (segundNum == 0)
                    {
                        PantallaNum.Text = "Error! :(";
                        return;
                    }
                    else
                    {
                        resPar /= segundNum;
                    }
                    break;
                case "x²":
                    resPar = segundNum * segundNum; 
                    break;

                default:
                    PantallaNum.Text = "Error! :(";
                    break;

            }
            PantallaNum.Text = resPar.ToString(); //porque estaba despues del break

        }
        private void Atras_Click(object sender, RoutedEventArgs e)
        {
            int longitud = PantallaNum.Text.Length;
            string texto = PantallaNum.Text;
            if (longitud == 1)
            {
                PantallaNum.Text = "0";
            }
            else
            {
                PantallaNum.Text = texto.Substring(0, longitud - 1);

            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {

            PantallaNum.Text = "0";

        }

    }
        
}
    