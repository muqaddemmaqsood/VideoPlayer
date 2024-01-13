using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
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
using static System.Net.Mime.MediaTypeNames;
using static VideoPlayer.MainWindow;

namespace VideoPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Movie>? Movies { get; set; }
        public Movie? SelectedMovie { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        public void Start()
        {
            ObservableCollection<Movie>? movies = ApiHelper.GetMoviesFromApi("https://assets.acmeaom.com/interview-project/uwpvideos.json");
            if (movies != null)
            {
                Movies = new ObservableCollection<Movie>(movies.OrderBy(x => x.Title));
                imageListBox.ItemsSource = Movies;
            }
            else
            {
                MessageBox.Show("Unable to load movies, Please check internet");
            }

        }


        private void ImageListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (imageListBox.SelectedItem != null)
            {
                int index = imageListBox.SelectedIndex;
                MovieDetail detailsWindow = new MovieDetail(Movies, index);
                detailsWindow.Owner = this;
                detailsWindow.ShowDialog();
            }
        }

    }
}