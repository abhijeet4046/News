using System;
using System.Collections.Generic;
using System.Linq;
using News.Model.DbContext;

namespace News.Model.Repository
{
    public class NewsRepository : INewsRepository<News>
    {
        private readonly NewsContext _newsContext;

        public NewsRepository(NewsContext context)
        {
            _newsContext = context;
        }
        public IEnumerable<News> GetAll()
        {
            return _newsContext.News.ToList().Where( x=>x.Date.Equals(DateTime.Today));
        }

        public News Get(long id)
        {
            return _newsContext.News.ToList().FirstOrDefault(x => x.NewsId == id);
        }

        public bool Add(News news)
        {
            _newsContext.News.Add(news);
            _newsContext.SaveChanges();
            return true;
        }

        public void Update(News dbEntity, News entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(News entity)
        {
            _newsContext.News.Remove(entity);
            _newsContext.SaveChanges();
        }
    }
}
