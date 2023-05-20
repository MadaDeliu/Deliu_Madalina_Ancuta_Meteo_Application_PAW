namespace MeteoApplicationMVC.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IRepositoryAlert RepositoryAlert { get; }
        IRepositoryCity RepositoryCity { get; }
        IRepositoryContact RepositoryContact { get; }
        IRepositoryFavoriteLocation RepositoryFavoriteLocation { get; }
        IRepositoryMeteorologist RepositoryMeteorologist { get; }
        IRepositoryNews RepositorySevereWeatherEvents { get; }
        IRepositoryStation RepositoryStation { get; }
        IRepositoryUser RepositoryUser { get; }
        IRepositoryWeatherData RepositoryWeatherData { get; }

        void Save();
    }
}
