using System;
using System.Collections.Generic;
using Lab._06.MVC.BL.DTO;
using Lab._06.MVC.BL.DTO.Mapper;
using Lab._06.MVC.DL.Models;
using Lab._06.MVC.DL.Uow;

namespace Lab._06.MVC.BL.MovieService
{
    public class MovieService : IMovieService<MovieDto>
    {
        private readonly IUow uow;
        private readonly MapperBL mapper;

        public MovieService(IUow uow, MapperBL mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public void Create(MovieDto movieDto)
        {
            Movie currentMovie;
            if (uow.MovieRepository.GetByName(movieDto.MovieName) == null)
            {
                currentMovie = new Movie
                {
                    MovieName = movieDto.MovieName,
                    UserMovieNote = movieDto.UserMovieNote,
                    MoviePoster = movieDto.MoviePoster
                };
            }
            else
            {
                throw new InvalidOperationException("This movie is exist, check forum!");
            }

            uow.MovieRepository.Create(currentMovie);
            uow.Save();
        }

        public void Remove(string movieName)
        {
            var movie = uow.MovieRepository.GetByName(movieName);
            uow.MovieRepository.Delete(movie);
            uow.Save();
        }

        public List<MovieDto> AllMovies
        {
            get
            {
                var dtoList = new List<MovieDto>();
                foreach (var movies in uow.MovieRepository.GetAll())
                {
                    dtoList.Add(mapper.CreateMap(movies));
                }

                return dtoList;
            }
        }

        public MovieDto GetCurrentMovie(int movieid)
        {
            var movie = uow.MovieRepository.GetById(movieid);
            return mapper.CreateMap(movie);
        }

        public void Update(MovieDto movieDto)
        {
            var currentMovie = new Movie
            {
                MovieName = movieDto.MovieName,
                UserMovieNote = movieDto.UserMovieNote,
                MoviePoster = movieDto.MoviePoster,
                MovieID = movieDto.MovieID
            };
            uow.MovieRepository.Update(currentMovie);
            uow.Save();
        }
    }
}

