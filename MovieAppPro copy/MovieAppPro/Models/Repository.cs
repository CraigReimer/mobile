using System;
using SQLite;

namespace MovieAppPro.Models
{
	public class Repository
	{
		private readonly SQLiteConnection _database;

		public Repository()
		{
			var dbPath = Path.Combine(
				Environment.GetFolderPath(
				Environment.SpecialFolder.LocalApplicationData),
				"movies.db");

			_database = new SQLiteConnection(dbPath);
			_database.CreateTable<Movie>();
		}

		public List<Movie> GetMovies()
		{
			return _database.Table<Movie>().ToList();

			// _database.Query<Movie>("SELECT * FROM movie");
		}

		public void SaveMovie(Movie movie)
		{
			_database.Insert(movie);
		}
	}
}

