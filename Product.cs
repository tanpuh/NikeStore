using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNike
{
    [Serializable]
    internal class Product
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ProductId { get; set; }

        [BsonElement("product_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string ProductName { get; set; }

    }
}
