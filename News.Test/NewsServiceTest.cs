using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using News.Model;
using News.Model.NewsService;
using News.Model.Repository;
using NUnit.Framework;

namespace NewsPages.Test
{
    public class Tests
    {
        Mock<INewsRepository<News.Model.News>> mockObject = new Mock<INewsRepository<News.Model.News>>();
        private INewsService _service = null;

        [SetUp]
        public void Setup()
        {
            _service = new NewsService(mockObject.Object);
            mockObject.Setup(m => m.Add(new News.Model.News())).Returns(true);
            mockObject.Setup(m => m.GetAll()).Returns(getNews());
        }

        [Test]
        public void Test_GetPage_when_check_NumberOFAdds_and_News()
        {
           var pages= _service.GetNewsPages();

           NewsPage page = pages.ToList().FirstOrDefault();

           Assert.AreEqual(page.Newses.Count,8);
           Assert.AreEqual(page.Newses.Where(x=>x.Type.Equals("Advertisement")).ToList().Count,2);
        }
        private IEnumerable<News.Model.News> getNews()
        {
            var newsLIst = new List<News.Model.News>();
            for (int i = 0; i < 8; i++)
            {
                newsLIst.Add(new News.Model.News() { Date = DateTime.Today, Description = "Details News is Here", HeadLine = "HeadLine of News", Priority = Priority.P1, Type = "Sports", NewsId = i + 1 });

            }
            for (int i = 0; i < 2; i++)
            {
                newsLIst.Add(new News.Model.News() { Date = DateTime.Today, Description = "Details News is Here", HeadLine = "HeadLine of News", Priority = Priority.P1, Type = "Advertisement", NewsId = i + 1 });

            }
            return newsLIst;
        }
    }
}