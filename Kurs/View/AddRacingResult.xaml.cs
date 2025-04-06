using Kurs.Model;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для AddRacingResult.xaml
    /// </summary>
    public partial class AddRacingResult : Window
    {
        public AddRacingResult()
        {
            InitializeComponent();
            Load();
        }
        
        public void Load() 
        {
            using (var context = new Formula12025Context())
            {
                foreach (var item in context.Racers.ToList()) 
                {
                    RacerC.Items.Add(item.LastName+" "+item.Name);
                }
                var list = context.Races.Include(g => g.IDtrackNavigation).ToList();
                foreach (var item in list)
                {
                    RaceC.Items.Add(item.IDtrackNavigation.Title);
                }
                var list_pos = context.Positionscores
                    .AsEnumerable()
                    .OrderBy(s =>
                    {
                        if (int.TryParse(s.Position, out int num))
                            return num;
                        else
                            return int.MaxValue;
                    }).ThenBy(s => s.Position).ToList();

                foreach (var item in list_pos)
                {
                    EndC.Items.Add(item.Position);
                }
                for (int i = 1; i <= 20; i++)
                {
                    StartC.Items.Add(i.ToString());
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(RacingResult.GeneratRacingResult(RacerC.SelectedIndex + 1, RaceC.SelectedIndex + 1, StartC.SelectedIndex + 1, EndC.SelectedItem.ToString()));
        }
    }
}
