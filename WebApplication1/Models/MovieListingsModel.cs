using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MovieListingsModel : DbContext
    {
        //constructor that reads the db connection string
        public MovieListingsModel(DbContextOptions<MovieListingsModel>options): base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
