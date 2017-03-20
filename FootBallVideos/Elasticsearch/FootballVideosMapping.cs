using ElasticsearchCRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootBallVideos.Elasticsearch
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
