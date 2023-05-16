﻿using MeteoApplicationMVC.Data;
using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;

namespace MeteoApplicationMVC.Repositories
{
    public class RepositoryFavoriteLocation : RepositoryBase<FavoriteLocation>, IRepositoryFavoriteLocation
    {
        public RepositoryFavoriteLocation(ApplicationDbContext _applicationDbContext)
            : base(_applicationDbContext)
        {
        }
    }
}
