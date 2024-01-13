using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace VideoPlayer
{
    /// <summary>
    /// Interaction logic for MovieDetail.xaml
    /// </summary>
    public partial class MovieDetail : Window
    {
        int _currentIndex = 0;
        ObservableCollection<Movie>? _movies = new ObservableCollection<Movie>();
        public MovieDetail()
        {
            InitializeComponent();
        }
        
        public MovieDetail(ObservableCollection<Movie>? movies, int selectedIndex)
        {
            InitializeComponent();
            _currentIndex = selectedIndex;
            _movies = movies;
            DisplayCurrentImage();
        }

        private void DisplayCurrentImage()
        {
            if (_currentIndex >= 0 && _currentIndex < _movies.Count)
            {

                this.DataContext = _movies[_currentIndex];
            }
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            _currentIndex = (_currentIndex - 1 + _movies.Count) % _movies.Count;
            DisplayCurrentImage();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            _currentIndex = (_currentIndex + 1) % _movies.Count;
            DisplayCurrentImage();
        }
    }
}
