namespace Shop.Web.Data
{
    using Entities;
    public class CountryRepository : GenericRepository<Country>, ICountryRepositoy
    {
        public CountryRepository(DataContext context) : base(context)
        {
        }
    }
}