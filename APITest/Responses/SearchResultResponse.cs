using System;

namespace APITest.Responses
{
    [Serializable]
    public class SearchResultResponse
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public Shards _shards { get; set; }
    }
}
