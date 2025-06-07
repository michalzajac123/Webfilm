using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webfilm
{
    public partial class Form1 : Form
    {
        private readonly string apiKey = "f470693ad8a4190c89e1259a892e6a1a"; // Api key 
        int page = 1;
        public Form1()
        {
            InitializeComponent();
            LoadMovies(page);
            this.BackColor = ColorTranslator.FromHtml("#121212"); // ciemne tło ogólne

        }
        /// <summary>
        /// Initializes the form and loads movies asynchronously.
        /// </summary>
        private async void LoadMovies(int page)
        {
            
            previousPageButton.Enabled = false; //Wait until movies are loaded
            nextPageButton.Enabled = false;
            searchButton.Enabled = false;
            string url = $"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}&language=pl-Pl&page={page}";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    JObject data = JObject.Parse(json);
                    var movies = data["results"].Select(movie => new
                    {
                        Id = (int)movie["id"],
                        Title = movie["title"].ToString(),
                        Rating = movie["vote_average"].ToString(),
                        PosterPath = movie["poster_path"]?.ToString()
                    }).ToList();
                    foreach (var movie in movies)
                    {
                        string title = movie.Title;
                        string rating = movie.Rating;
                        string posterUrl = movie.PosterPath;
                        if (!string.IsNullOrEmpty(posterUrl))
                        {
                            string imageUrl = $"https://image.tmdb.org/t/p/w300{posterUrl}";
                            var moviePanel = await CreateMoviePanel(title, rating, imageUrl);
                            moviePanel.Cursor = Cursors.Hand;
                            EventHandler clickHandler = async (s, e) =>
                            {
                                try
                                {
                                    var details = await GetMovieDetails(movie.Id);
                                    if (details == null)
                                    {
                                        MessageBox.Show("Nie udało się pobrać szczegółów filmu.");
                                        return;
                                    }

                                    var detailsForm = new MovieDetailsForm(details);
                                    detailsForm.Show(); // Pokaż okno
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Błąd podczas pobierania szczegółów: " + ex.Message);
                                }
                            };

                            // Dodaj zdarzenie do panelu i dzieci
                            moviePanel.Click += clickHandler;
                            foreach (Control control in moviePanel.Controls)
                            {
                                control.Click += clickHandler;
                            }

                            flowLayoutPanelMovies.Controls.Add(moviePanel);

                        }
                    }
                    previousPageButton.Enabled = true;
                    nextPageButton.Enabled = true;
                    searchButton.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas ładowania filmów: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async Task<MovieDetails> GetMovieDetails(int movieId)
        {
            var url = $"https://api.themoviedb.org/3/movie/{movieId}?api_key={apiKey}&language=pl-PL";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                dynamic json = JsonConvert.DeserializeObject(response);

                return new MovieDetails
                {
                    Title = json.title,
                    Overview = json.overview,
                    ReleaseDate = json.release_date,
                    Rating = json.vote_average,
                    PosterUrl = $"https://image.tmdb.org/t/p/w500{json.poster_path}"
                };
            }
        }
        private async Task<Panel> CreateMoviePanel(string title, string rating, string imageUrl)
        {
            var panel = new Panel
            {
                Width = 200,
                Height = 360,
                Margin = new Padding(10),
                BackColor = ColorTranslator.FromHtml("#1C1C1C"),
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox picture = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 180,
                Height = 270,
                Location = new Point(10, 10),
                BackColor = Color.Black,
                BorderStyle = BorderStyle.FixedSingle
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var bytes = await client.GetByteArrayAsync(imageUrl);
                    using (var ms = new MemoryStream(bytes))
                    {
                        picture.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Obrazek nie załadowany: " + ex.Message);
            }

            Label labelTitle = new Label
            {
                Text = title,
                Width = 180,
                Height = 40,
                Location = new Point(10, 290),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoEllipsis = true
            };

            Label labelRating = new Label
            {
                Text = $"⭐ {rating}",
                Width = 180,
                Height = 20,
                Location = new Point(10, 330),
                ForeColor = Color.Gold,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };

            panel.Controls.Add(picture);
            panel.Controls.Add(labelTitle);
            panel.Controls.Add(labelRating);

            return panel;
        }

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            if(page > 1)
            {
                page--;
                pageNumberLabel.Text = $"Strona: {page}";
                flowLayoutPanelMovies.Controls.Clear();
                LoadMovies(page);
            }
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            if (page < 1000) 
            {
                page++;
                pageNumberLabel.Text = $"Strona: {page}";
                flowLayoutPanelMovies.Controls.Clear();
                LoadMovies(page);
            }
        }
        /// <summary>
        /// Searches for movies based on the provided query using The Movie Database API.
        /// </summary>
        /// <param name="query">Name of Film</param>
        /// <returns></returns>
        private async Task<List<Movie>> SearchMovies(string query)
        {
            var url = $"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&language=pl-PL&query={Uri.EscapeDataString(query)}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                dynamic json = JsonConvert.DeserializeObject(response);

                var results = new List<Movie>();

                foreach (var item in json.results)
                {
                    int id = (int)item.id;
                    string title = item.title;
                    double rating = item.vote_average;
                    string posterPath = item.poster_path;
                    string imageUrl = string.IsNullOrEmpty((string)posterPath)
                        ? ""
                        : $"https://image.tmdb.org/t/p/w500{posterPath}";

                    results.Add(new Movie
                    {
                        Id = id,
                        Title = title,
                        Rating = rating,
                        ImageUrl = imageUrl
                    });
                }

                return results;
            }
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            string query = searchTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(query))
            {
                var movies = await SearchMovies(query);
                flowLayoutPanelMovies.Controls.Clear();

                foreach (var movie in movies)
                {
                    var moviePanel = await CreateMoviePanel(movie.Title, movie.Rating.ToString("0.0"), movie.ImageUrl);
                    moviePanel.Cursor = Cursors.Hand;
                    EventHandler clickHandler = async (s, ev) =>
                    {
                        try
                        {
                            var details = await GetMovieDetails(movie.Id);
                            if (details == null)
                            {
                                MessageBox.Show("Nie udało się pobrać szczegółów filmu.");
                                return;
                            }

                            var detailsForm = new MovieDetailsForm(details);
                            detailsForm.Show(); // Pokaż okno
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Błąd podczas pobierania szczegółów: " + ex.Message);
                        }
                    };

                    // Dodaj zdarzenie do panelu i dzieci
                    moviePanel.Click += clickHandler;
                    foreach (Control control in moviePanel.Controls)
                    {
                        control.Click += clickHandler;
                    }

                    flowLayoutPanelMovies.Controls.Add(moviePanel);
                }
            }
        }
    }
}