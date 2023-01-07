using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace PL.Controllers
{
    public class MovieController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ML.Movie movie = new ML.Movie();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/account/");
                var responseTask = client.GetAsync("16836285/favorite/movies?api_key=ab36432811f7477a8e3a88935217481e&session_id=808fdd466dcd751624d318231ff864e1390283f9&language=en-US&sort_by=created_at.asc&page=1");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    dynamic resultJSON = JObject.Parse(readTask.Result.ToString());
                    responseTask.Wait();
                    movie.Movies = new List<object>();
                    foreach (var item in resultJSON.results)
                    {
                        ML.Movie movieItem = new ML.Movie();
                        movieItem.Titulo = item.title;
                        movieItem.Descripcion = item.overview;
                        movieItem.IdMovie = item.id;

                        movieItem.Imagen = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/" + item.poster_path;
                        movieItem.Idioma = item.original_language;
                        movieItem.Ranking = item.vote_average;

                        movie.Movies.Add(movieItem);
                    }
                }
            }
            return View(movie);
        }

        [HttpGet]
        public IActionResult Popular()
        {
            ML.Movie movie = new ML.Movie();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
                var responseTask = client.GetAsync("movie/popular?api_key=ab36432811f7477a8e3a88935217481e&language=en-US&page=1");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    dynamic resultJSON = JObject.Parse(readTask.Result.ToString());
                    responseTask.Wait();
                    movie.Movies = new List<object>();
                    foreach (var item in resultJSON.results)
                    {
                        ML.Movie movieItem = new ML.Movie();
                        movieItem.Titulo = item.title;
                        movieItem.IdMovie = item.id;
                        movieItem.Descripcion = item.overview;

                        movieItem.Imagen = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/" + item.poster_path;
                        movieItem.Idioma = item.original_language;
                        movieItem.Ranking = item.vote_average;

                        movie.Movies.Add(movieItem);
                    }
                }
            }
            return View(movie);
        }

        [HttpGet]
        public IActionResult AddFavoritMovie(int IdMovie, bool Favorite)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/account/");

                ML.AddMovie addMovie = new ML.AddMovie() { media_type = "movie", media_id = IdMovie, favorite = Favorite };
                var responseTask = client.PostAsJsonAsync<ML.AddMovie>("https://api.themoviedb.org/3/account/16836285/favorite?api_key=ab36432811f7477a8e3a88935217481e&session_id=808fdd466dcd751624d318231ff864e1390283f9",addMovie);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Operacion con exito";
                }
                else
                {
                    ViewBag.Message = "Error ";
                }
                
            }

            return View("Modal");
        }
    }
}
