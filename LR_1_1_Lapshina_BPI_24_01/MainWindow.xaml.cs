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

namespace LR_1_1_Lapshina_BPI_24_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ButtonAddYear.Click += AddOneYear_Click;
            ButtonDeleteDays.Click += SubtractTwoDays_Click;

            dayInput.TextChanged += ValidateDay;
            monthInput.TextChanged += ValidateMonth;
            yearInput.TextChanged += ValidateYear;

            CreateEmptyDate();
        }

        private bool isValidDay = false;
        private bool isValidMonth = false;
        private bool isValidYear = false;

        private Date currentDate;

        private void CreateEmptyDate()
        {
            currentDate = new Date(1, 1, 2000);
        }

        private void EditDateData()
        {
            int day = int.Parse(dayInput.Text);
            int month = int.Parse(monthInput.Text);
            int year = int.Parse(yearInput.Text);
            currentDate.EditData(day, month, year);
        }

        private void ValidateDay(object sender, TextChangedEventArgs e)
        {
            isValidDay = false;
            dayInput.Background = Brushes.Red;

            if (string.IsNullOrEmpty(dayInput.Text))
                return;

            if (int.TryParse(dayInput.Text, out int day))
            {
                if (day >= 1 && day <= 31)
                {
                    isValidDay = true;
                    dayInput.Background = Brushes.Green;
                }
            }
        }

        private void ValidateMonth(object sender, TextChangedEventArgs e)
        {
            isValidMonth = false;
            monthInput.Background = Brushes.Red;

            if (string.IsNullOrEmpty(monthInput.Text))
                return;

            if (int.TryParse(monthInput.Text, out int month))
            {
                if (month >= 1 && month <= 12)
                {
                    isValidMonth = true;
                    monthInput.Background = Brushes.Green;
                }
            }
        }

        private void ValidateYear(object sender, TextChangedEventArgs e)
        {
            isValidYear = false;
            yearInput.Background = Brushes.Red;

            if (string.IsNullOrEmpty(yearInput.Text))
                return;

            if (int.TryParse(yearInput.Text, out int year))
            {
                if (year >= 1 && year <= 9999)
                {
                    isValidYear = true;
                    yearInput.Background = Brushes.Green;
                }
            }
        }

        private bool CheckValid()
        {
            if (!isValidDay || !isValidMonth || !isValidYear)
                return false;

            // Проверка существования даты (например, 31 февраля)
            try
            {
                int day = int.Parse(dayInput.Text);
                int month = int.Parse(monthInput.Text);
                int year = int.Parse(yearInput.Text);
                DateTime dt = new DateTime(year, month, day);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void AddOneYear_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValid())
            {
                EditDateData();
                currentDate.AddOneYear();
                UpdateDateFields();
         
            }
        }

        private void SubtractTwoDays_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValid())
            {
                EditDateData();
                currentDate.SubtractTwoDays();
                UpdateDateFields();

            }
        }

        private void UpdateDateFields()
        {
            dayInput.Text = currentDate.Day.ToString();
            monthInput.Text = currentDate.Month.ToString();
            yearInput.Text = currentDate.Year.ToString();
        }
    }
}