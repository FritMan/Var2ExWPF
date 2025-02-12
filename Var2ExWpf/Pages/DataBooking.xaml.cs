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
using Var2ExWpf.Classes;
using Var2ExWpf.Data;
using static Var2ExWpf.Classes.Help;

namespace Var2ExWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для DataBooking.xaml
    /// </summary>
    public partial class DataBooking : Page
    {
        public DataBooking()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            bookingDataGrid.ItemsSource = Db.Booking.ToList();
            SearchCb.SelectedIndex = 0;
            FiltrCb.SelectedIndex = 0;
            SeacrhDate.SelectedDate = DateTime.Now;
            SeacrhDate.IsEnabled = false;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditBooking(-1));
        }


        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selected_booking = bookingDataGrid.DataContext as Booking;

            if (selected_booking != null)
            {
                MessageBoxResult MsResult = MessageBox.Show("Вы точно хотите удалить?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (MsResult == MessageBoxResult.Yes) 
                {
                    Db.Booking.Remove(selected_booking);
                    Db.SaveChanges();
                    LoadData();
                }
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchCb.SelectedIndex == 1)
            {
                bookingDataGrid.ItemsSource = Db.Booking.Where(el => SearchTb.Text.Contains(el.Room.Room_number)).ToList();
            }
            else if (SearchCb.SelectedIndex == 2) 
            {
                bookingDataGrid.ItemsSource = Db.Booking.Where(el => SearchTb.Text.Contains(el.Guest.Name)).ToList();
            }
        }

        private void FiltrCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(FiltrCb.SelectedIndex == 0)
            {
                LoadData();
            }
            else if(FiltrCb.SelectedIndex == 1)
            {
                bookingDataGrid.ItemsSource = Db.Booking.Where(el => el.Status_Booking.Name == "Активное").ToList();
            }
            else if(FiltrCb.SelectedIndex == 2)
            {
                bookingDataGrid.ItemsSource = Db.Booking.Where(el => el.Status_Booking.Name == "Завершено").ToList();
            }
            else if (FiltrCb.SelectedIndex ==3)
            {
                bookingDataGrid.ItemsSource = Db.Booking.Where(el => el.Status_Booking.Name == "Отмененено").ToList();
            }
        }

        private void SeacrhDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SearchCb.SelectedIndex == 3)
            {
                bookingDataGrid.ItemsSource = Db.Booking.Where(el => el.Check_in_date == SeacrhDate.SelectedDate || el.Check_out_date == SeacrhDate.SelectedDate).ToList();
            }
        }

        private void SearchCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if(SearchCb.SelectedIndex == 0)
            {
                LoadData();
            }
            else if (SearchCb.SelectedIndex == 3) 
            {
                SearchTb.IsEnabled = false;
                Help.ShowInfo("Выберите в календаре дату для поиска");
                SeacrhDate.IsEnabled = true;
            }
        }

        private void EditBtn_Click_1(object sender, RoutedEventArgs e)
        {
            var selected_booking = bookingDataGrid.SelectedItem as Booking;

            if (selected_booking != null)
            {
                NavigationService.Navigate(new EditBooking(selected_booking.Id));
            }
        }
    }
}
