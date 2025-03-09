using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "The RM",
                    ReleaseDate = DateTime.Parse("2003-02-01"),
                    Genre = "Church",
                    Rating = "PG",
                    Price = 9.99M,
                    ImageName = "theRM.jpg"
                },
                new Movie
                {
                    Title = "Other Side of Heaven",
                    ReleaseDate = DateTime.Parse("2001-10-01"),
                    Genre = "Church",
                    Rating = "PG",
                    Price = 12.99M,
                    ImageName = "otherSideOfHeaven.jpg"
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-09-26"),
                    Genre = "Church",
                    Rating = "PG",
                    Price = 7.99M,
                    ImageName = "meetTheMormons.jpg"
                }
            );
            context.SaveChanges();
        }
    }
}

