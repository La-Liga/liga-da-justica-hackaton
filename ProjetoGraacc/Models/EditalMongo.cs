using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjetoGraacc.Models
{
    public class EditalMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Titulo")]
        public string Titulo { get; set; }

        public string Texto { get; set; }

        public string TextoHtml { get; set; }

        public string NumeroProcesso { get; set; }

        public string DataPublicacao { get; set; }

        public string Link { get; set; }
    }
}