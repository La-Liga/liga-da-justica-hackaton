using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjetoGraacc.Models
{
    [BsonIgnoreExtraElements]
    public class EditalMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("titulo")]
        public string Titulo { get; set; }

        [BsonElement("texto")]
        public string Texto { get; set; }

        [BsonElement("textoHtml")]
        public string TextoHtml { get; set; }

        [BsonElement("numeroProcesso")]
        public string NumeroProcesso { get; set; }

        [BsonElement("dataPublicacao")]
        public string DataPublicacao { get; set; }

        [BsonElement("link")]
        public string Link { get; set; }
    }
}