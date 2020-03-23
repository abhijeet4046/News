using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Model.NewsService
{
   public interface INewsService
   {
       IEnumerable<Model.News> GetAllNews();
       IEnumerable<Model.NewsPage> GetNewsPages();
       IEnumerable<Model.News> GetAdvertisements();
        bool SubmitNews(News news);
       bool DeleteNews(News news);
   }
}
