using APITest.Responses;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

namespace APITest
{
    public class Tests : BaseTest
    {
        [Test]
        public void AllShardsAreSuccessful()
        {
            var request = PrepareSearchRequest("en", "job%20offers");

            var response = client.Execute(request);
            Assert.That(response.StatusCode == HttpStatusCode.OK);

            var searchResults = JsonConvert.DeserializeObject<SearchResultResponse>(response.Content);

            var shards = searchResults._shards;

            Assert.Multiple(() =>
            {
                Assert.That(shards.total, Is.GreaterThan(0), "The search has not returned any results");
                Assert.That(shards.total, Is.EqualTo(shards.successful), "There are unsuccessful shards in the search response");
                Assert.That(shards.failed, Is.EqualTo(0), "There are failed shards in the search response");
                Assert.That(shards.skipped, Is.EqualTo(0), "There are skipped shards in the search response");
            });
        }

        [Test]
        public void ArticlesAreSortedByNewest()
        {
            var request = PreparePaginatedNewsRequest("en", "1");

            var response = client.Execute(request);
            Assert.That(response.StatusCode == HttpStatusCode.OK);

            var articles = JsonConvert.DeserializeObject<List<PaginatedNewsResponse>>(response.Content);

            var articlesCount = articles.Count;

            for(var i = 0; i < articlesCount - 1; i++)
            {
                Assert.That(articles[i].post_date, Is.GreaterThan(articles[i + 1].post_date), "The articles are not sorted by newest");
            }
        }
    }
}