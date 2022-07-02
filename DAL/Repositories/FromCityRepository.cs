using Dapper;
using Microsoft.Extensions.Configuration;
using MyProject.DAL.IRepositories;
using MyProject.Models;
using Npgsql;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.DAL.Repositories
{
    public class FromCityRepository : IFromCityRepository<FromCity>
    {

        private string connectionString;
        private NpgsqlConnection connection;

        public FromCityRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }
        public void Add(FromCity item)
        {
            connection.Execute("INSERT INTO fromcity (fcityname) VALUES(@FCityName)", item);
        }

        public IEnumerable<FromCity> FindAll()  
        {
            return connection.Query<FromCity>("SELECT * FROM fromcity");
        }

        public FromCity FindByID(int id)
        {
            return connection.Query<FromCity>("SELECT * FROM fromcity WHERE fcityid = @Id", new { Id = id }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            connection.Execute("DELETE FROM fromcity WHERE fcityid=@FCityId", new { FCityId = id });
        }

        public void Update(FromCity item)
        {
            connection.Query("UPDATE fromcity SET fcityname = @FCityName WHERE fcityid = @FCityId", item);
        }

        //public FromCity Add(FromCity fromCity)
        //{
        //    _ctx.FromCities.Add(fromCity);
        //    _ctx.SaveChanges();
        //    return fromCity;
        //}

        //public void Delete(int fCityId)
        //{
        //    FromCity fromCity = _ctx.FromCities.Find(fCityId);
        //    fromCity.IsDeleted = true;
        //    _ctx.SaveChanges();
        //}

        //public List<FromCity> Get()
        //{
        //    return _ctx.FromCities.OrderBy(m => m.FCityId).ToList();
        //}

        //public FromCity GetById(int fCityId)
        //{
        //    FromCity fromCity = _ctx.FromCities.Find(fCityId);
        //    return fromCity;
        //}

        //public FromCity Update(FromCity fromCity)
        //{
        //    _ctx.FromCities.Update(fromCity);
        //    _ctx.SaveChanges();
        //    return fromCity;
        //}
    }
}
