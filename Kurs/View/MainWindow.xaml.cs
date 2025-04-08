using Kurs.Model;
using Kurs.View;
using Kurs.СustomElement;
using Microsoft.EntityFrameworkCore;
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

namespace Kurs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        public void Load() 
        {
            using (var context = new Formula12025Context()) 
            {
                var list = context.RacingResults.Include(g=>g.FinalPositionNavigation).Include(g => g.IDracerNavigation).ToList();
                foreach (var item in list) 
                {
                    PerList.Items.Add(new RacerCard(item.IDracerNavigation));
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddRece().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new AddRacingResult().Show();
        }
    }
}