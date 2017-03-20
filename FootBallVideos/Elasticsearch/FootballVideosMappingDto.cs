using ElasticsearchCRUD.ContextAddDeleteUpdate.CoreTypeAttributes;

namespace FootBallVideos.Elasticsearch
{
    public class FootballVideosMappingDto
    {
        public int Id { get; set; }

        [ElasticsearchString(CopyToList = new[] { "autocomplete", "searchfield" })]
        public string Name { get; set; }

        public string Type { get; set; }

        [ElasticsearchString(Analyzer = "edge_ngram_search", SearchAnalyzer = "standard", TermVector = TermVector.yes)]
        public string searchfield { get; set; }

        [ElasticsearchString(Analyzer = "autocomplete")]
        public string autocomplete { get; set; }
    }
}
