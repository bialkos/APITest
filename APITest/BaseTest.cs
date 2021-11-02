using RestSharp;

namespace APITest
{
    public class BaseTest
    {
        public RestClient client { get; set; }

        protected BaseTest()
        {
            client = new RestClient("https://nexergroup.com");
            
        }
        
        public RestRequest PrepareSearchRequest(string language, string searchPhrase)
        {
            var request = new RestRequest($"/wp-json/elasticnexer/search?lang={language}&s={searchPhrase}", Method.GET);
            return request;
        }

        public RestRequest PreparePaginatedNewsRequest(string language, string pageNumber)
        {
            var request = new RestRequest($"/wp-json/nexer-blocks/v1/paginated-news?page={pageNumber}& lang={language}", Method.GET);
            return request;
        }
    }
}
