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
    public partial class MovieDetailsForm : Form
    {
        public MovieDetailsForm(MovieDetails movie)
        {
            this.BackColor = ColorTranslator.FromHtml("#121212"); // ciemne tło ogólne
            Text = movie.Title;
            Width = 600;
            Height = 700;

            var pictureBox = new PictureBox
            {
                Width = 300,
                Height = 450,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(20, 20)
            };
            LoadImageAsync(movie.PosterUrl, pictureBox);
            Controls.Add(pictureBox);

            var titleLabel = new Label
            {
                Text = $"Tytuł: {movie.Title}",
                Location = new Point(340, 20),
                ForeColor = Color.White,
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            Controls.Add(titleLabel);

            var releaseLabel = new Label
            {
                Text = $"Premiera: {movie.ReleaseDate}",
                Location = new Point(340, 60),
                ForeColor = Color.White,
                AutoSize = true
            };
            Controls.Add(releaseLabel);

            var ratingLabel = new Label
            {
                Text = $"Ocena: {movie.Rating}/10",
                Location = new Point(340, 90),
                ForeColor = Color.White,
                AutoSize = true
            };
            Controls.Add(ratingLabel);

            var overviewBox = new TextBox
            {
                Text = movie.Overview,
                Location = new Point(20, 500),
                BackColor = ColorTranslator.FromHtml("#1E1E1E"), // ciemne tło dla pola tekstowego
                ForeColor = Color.White,
                Width = 540,
                Height = 120,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };
            Controls.Add(overviewBox);
        }

        private async void LoadImageAsync(string url, PictureBox pictureBox)
        {
            using (HttpClient client = new HttpClient())
            {
                var data = await client.GetByteArrayAsync(url);
                using (var ms = new MemoryStream(data))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }
            }
        }
    }

}
