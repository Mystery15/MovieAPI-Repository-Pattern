using MyMDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMDB.Data.EFCore
{
    public class EfCoreMovieRepository : EfCoreRepository<Movie, MyMDBContext>
    {
        public EfCoreMovieRepository(MyMDBContext context) : base(context)
        {
        }
    }
}
