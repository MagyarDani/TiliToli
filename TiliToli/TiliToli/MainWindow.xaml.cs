using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TiliToli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int stepsCounter = 0;
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button egyikGomb = sender as Button;
            Button nullaGomb = (Button)FindName("Button0");
            int vTav = Math.Abs((int)(egyikGomb.Margin.Left - nullaGomb.Margin.Left));
            int fTav = Math.Abs((int)(egyikGomb.Margin.Top - nullaGomb.Margin.Top));
            if ((vTav <120 && fTav == 0) || (fTav < 120 && vTav == 0)) {
                var seged = egyikGomb.Margin;
                egyikGomb.Margin = nullaGomb.Margin;
                nullaGomb.Margin = seged;
            }
            stepsCounter++;
            steps.Text = stepsCounter.ToString();

            if (Win ())
            {

                MessageBox.Show("Nyerél.", "Nyertél");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int[] randoms = new int[9];

            int x;
            for (int i = 0; i < 9; i++)
            {
                x = r.Next(1, 10);
                if (randoms.Contains(x))
                {
                    i--;
                    continue;
                }

                randoms[i] = x;
            }
            for (int i = 0; i < 9; i++)
            {
                ((Button)FindName($"Button{i}")).Margin = new Thickness(((randoms[i]-1) % 3) * 115 + 15, ((randoms[i]-1) / 3) * 115 + 70,0,0); 
            }
            stepsCounter = 0;
        }


        private bool Win()
        { 
            for(int i = 1; i < 10; i++)
            {
                int a = i;
                if (a == 9)
                    a = 0;

                if (((Button)FindName($"Button{a}")).Margin != new Thickness(((i-1) % 3) * 115 + 15, ((i-1) / 3) * 115 + 70, 0, 0))
                {
                    return false;
                }
            }
            return true;
        }




        private void steps_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
