using Kurs.Model;
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
using System.Windows.Shapes;

namespace Kurs.View
{
    /// <summary>
    /// Логика взаимодействия для AddRece.xaml
    /// </summary>
    public partial class AddRece : Window
    {
        public AddRece()
        {
            InitializeComponent();
            Load();
        }

        public void Load() 
        {
            using (var context = new Formula12025Context()) 
            {
                foreach (var item in context.Tracks.ToList()) 
                {
                    IdTrack.Items.Add(item.Title);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Race.GeneratRace(IdTrack.SelectedIndex + 1, StartD.SelectedDate, EndD.SelectedDate, Note.Text));
        }
    }
}
