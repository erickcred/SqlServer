using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Blog.Repositories
{
    public class Repository<TModel> where TModel : class
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TModel> Get()
        {
            return _connection.GetAll<TModel>();
        }

        public TModel GetById(int id)
        {
            return _connection.Get<TModel>(id);
        }

        public TModel Create(TModel model)
        {
            _connection.Insert<TModel>(model);

            return model;
        }

        public void Update(TModel model)
        {
            if(model != null)
            {
                _connection.Update<TModel>(model);
            }
        }

        public void Delete(TModel model)
        {
            if (model != null)
            {
                _connection.Delete<TModel>(model);
            }
        }

        public void Delete(int id)
        {
            if (id != 0)
            {
                var model = _connection.Get<TModel>(id);
                _connection.Delete<TModel>(model);
            }
        }

    }
}