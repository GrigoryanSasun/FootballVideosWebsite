using ElasticsearchCRUD;
using System;

namespace FootballVideosWebsite.Server.Elasticsearch
{
    public class FootballVideosMapping : ElasticsearchMapping
    {
        public override string GetIndexForType(Type type)
        {
            return "footballvideos";
        }

        public override string GetDocumentType(Type type)
        {
            return "footballvideo";
        }
    }
}
