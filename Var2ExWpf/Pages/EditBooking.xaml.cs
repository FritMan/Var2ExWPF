using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Var2ExWpf.Classes;
using Var2ExWpf.Data;
using static Var2ExWpf.Classes.Help;

namespace Var2ExWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditBooking.xaml
    /// </summary>
    public partial class EditBooking : Page
    {
        private int _Id;
        public EditBooking(int Id)
        {
            InitializeComponent();
            room_ComboBox.ItemsSource = Db.Room.ToList();
            status_booking_ComboBox.ItemsSource = Db.Status_Booking.ToList();
            guest_ComboBox.ItemsSource = Db.Guest.ToList();
            _Id = Id;

            if(_Id == -1)
            {
                gridBooking.DataContext = new Booking(){ Check_in_date = DateTime.Now, Check_out_date = DateTime.Now };
                
            }
            else
            {
                gridBooking.DataContext = Db.Booking.FirstOrDefault(el => el.Id == _Id);
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            int parsedValue;
            if(!int.TryParse(total_priceTextBox.Text, out parsedValue))
            {
                Help.ShowError("Могут быть введены только цифры!");
                return;
            }
            else
            {
                if (_Id == -1)
                {
                    Db.Booking.Add(gridBooking.DataContext as Booking);
                }
                Db.SaveChanges();
                NavigationService.Navigate(new DataBooking());
            }
        }
    }
}
