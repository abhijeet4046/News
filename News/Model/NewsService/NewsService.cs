using System;
using System.Collections.Generic;
using System.Linq;
using News.Model.Repository;

namespace News.Model.NewsService
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository<News> _newsRepository;

        public NewsService(INewsRepository<News> newsRepository)
        {
            _newsRepository = newsRepository;
        }


        public IEnumerable<News> GetAllNews()
        {
            return _newsRepository.GetAll();
        }

        public IEnumerable<NewsPage> GetNewsPages()
        {
            var todaysNewsPages = new List<NewsPage>();
            int pageLimit = 10;
            var todaysNews = GetAllNews().Where(x => x.Date.Equals(DateTime.Today)).ToList();
            int j = 0;
            var todaysGetAdvertisements = GetAdvertisements().Where(x => x.Date.Equals(DateTime.Today)).ToList();
            var newsPage = new NewsPage();
            IList<News> newses = new List<News>();
            for (int i = 0; i < todaysNews.Count(); i++)
            {
                if ((i % 8) == 0 && i != 0)
                {
                    newsPage = new NewsPage();
                    newses = new List<News>();
                }

                if ((i % 3) == 0 && i != 0)
                {
                    if (todaysGetAdvertisements.Count > j)
                    {
                        newses.Add(todaysGetAdvertisements[j]);
                        j++;
                    }
                    else
                    {
                        newses.Add(todaysNews[i]);
                    }

                }
                else
                {
                    newses.Add(todaysNews[i]);
                }

                if (newses.Count == 8)
                {
                    newsPage.Newses = newses;
                    todaysNewsPages.Add(newsPage);
                }

                if (todaysNews.Count() != i - 1) continue;
                newsPage.Newses = newses;
                todaysNewsPages.Add(newsPage);

            }

            return todaysNewsPages;
        }

        public IEnumerable<News> GetAdvertisements()
        {
            return _newsRepository.GetAll().Where(x => x.Type.Equals("Advertisement")).ToList();
        }

        public bool SubmitNews(News news)
        {
            _newsRepository.Add(news);
            return true;
        }

        public bool DeleteNews(News news)
        {
            _newsRepository.Delete(Get((int)news.NewsId));
            return true;
        }
        public Model.News Get(int id)
        {
            return _newsRepository.Get(id);
        }
    }
}
