using System;
using System.Collections.Generic;
using System.Linq;
using ElasticsearchCRUD;
using ElasticsearchCRUD.ContextAddDeleteUpdate.IndexModel.MappingModel;
using ElasticsearchCRUD.ContextAddDeleteUpdate.IndexModel.SettingsModel;
using ElasticsearchCRUD.ContextAddDeleteUpdate.IndexModel.SettingsModel.Analyzers;
using ElasticsearchCRUD.ContextAddDeleteUpdate.IndexModel.SettingsModel.Filters;
using ElasticsearchCRUD.ContextSearch.SearchModel.AggModel;
using ElasticsearchCRUD.Model;
using ElasticsearchCRUD.Model.SearchModel;
using ElasticsearchCRUD.Model.SearchModel.Aggregations;
using ElasticsearchCRUD.Model.SearchModel.Queries;
using ElasticsearchCRUD.Model.SearchModel.Sorting;
using ElasticsearchCRUD.Tracing;
using Nest;
using System.Net.Http;
using Newtonsoft.Json;

namespace FootBallVideos.Elasticsearch
{
    public class FootballVideosSearchProvider
    {
        private readonly IElasticsearchMappingResolver _elasticsearchMappingResolver = new ElasticsearchMappingResolver();
        // const string ConnectionString = "http://localhost.fiddler:9200";
        private const string ConnectionString = "http://localhost:9200";
        private readonly ElasticsearchContext _context;

        public FootballVideosSearchProvider()
        {
            _elasticsearchMappingResolver.AddElasticSearchMappingForEntityType(typeof(FootballVideosMappingDto), new FootballVideosMapping());
            _context = new ElasticsearchContext(ConnectionString, new ElasticsearchSerializerConfiguration(_elasticsearchMappingResolver))
            {
                TraceProvider = new ConsoleTraceProvider()
            };

        }
        public static Uri EsNode;
        public static ConnectionSettings EsConfig;
        public static ElasticClient EsClient;
        public void CreateIndex()
        {
            //_context.IndexCreate<FootballVideosMappingDto>(CreateNewIndexDefinition());
            EsNode = new Uri("http://localhost:9200/");
            EsConfig = new ConnectionSettings(EsNode);
            EsClient = new ElasticClient(EsConfig);

            var settings = new Nest.IndexSettings { NumberOfReplicas = 1, NumberOfShards = 2 };

            var indexConfig = new IndexState
            {
                Settings = settings
            };

            if (!EsClient.IndexExists("footballvideos").Exists)
            {
                EsClient.CreateIndex("footballvideos", c => c
                .InitializeUsing(indexConfig)
                .Mappings(m => m.Map<FootballVideo>(mp => mp.AutoMap())));
            }
        }

        public async void CreateData()
        {
            List<FootballVideo> tournaments = new List<FootballVideo>();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://192.168.6.120/api/tournament");
                    var response = await client.GetAsync("");
                    response.EnsureSuccessStatusCode(); // Throw in not success

                    var stringResponse = await response.Content.ReadAsStringAsync();
                    tournaments = JsonConvert.DeserializeObject<List<FootballVideo>>(stringResponse);
                    foreach (var t in tournaments)
                    {
                        t.Type = "tournament";
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
            foreach (var item in tournaments)
            {
                _context.AddUpdateDocument(item, item.Id);
            }
            List<FootballVideo> players = new List<FootballVideo>();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://192.168.6.120/api/players");
                    var response = await client.GetAsync("");
                    response.EnsureSuccessStatusCode(); // Throw in not success

                    var stringResponse = await response.Content.ReadAsStringAsync();
                    players = JsonConvert.DeserializeObject<List<FootballVideo>>(stringResponse);
                    foreach (var t in players)
                    {
                        t.Type = "player";
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
            foreach (var item in players)
            {
                _context.AddUpdateDocument(item, item.Id);
            }
            List<FootballVideo> teams = new List<FootballVideo>();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://192.168.6.120/api/team");
                    var response = await client.GetAsync("");
                    response.EnsureSuccessStatusCode(); // Throw in not success

                    var stringResponse = await response.Content.ReadAsStringAsync();
                    teams = JsonConvert.DeserializeObject<List<FootballVideo>>(stringResponse);
                    foreach (var t in teams)
                    {
                        t.Type = "team";
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
            foreach (var item in teams)
            {
                _context.AddUpdateDocument(item, item.Id);
            }
            _context.SaveChanges();

        }
        public IEnumerable<string> AutocompleteSearch(string term)
        {
            var search = new Search
            {
                Size = 0,
                Aggs = new List<IAggs>
                {
                    new TermsBucketAggregation("autocomplete", "autocomplete")
                    {
                        Order= new OrderAgg("_count", OrderEnum.desc),
                        Include = new IncludeExpression(term + ".*")
                    }
                }
                //Query = new Query(new PrefixQuery("autocomplete", term))
            };

            var items = _context.Search<FootballVideo>(search);
            var aggResult = items.PayloadResult.Aggregations.GetComplexValue<TermsBucketAggregationsResult>("autocomplete");
            IEnumerable<string> results = aggResult.Buckets.Select(t => t.Key.ToString());
            return results;
        }

        public IEnumerable<FootballVideo> QueryString(string term)
        {
            var results = _context.Search<FootballVideo>(BuildQueryStringSearch(term));

            return results.PayloadResult.Hits.HitsResult.Select(t => t.Source);
        }
        private Search BuildQueryStringSearch(string term)
        {
            var names = "";
            if (term != null)
            {
                names = term.Replace("+", " OR *");
            }

            var search = new Search
            {
                Query = new Query(new ElasticsearchCRUD.Model.SearchModel.Queries.QueryStringQuery(names + "*"))
            };

            return search;
        }
        public bool GetStatus()
        {
            return _context.IndexExists<FootballVideo>();
        }

    }
}

