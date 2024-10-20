using MongoDB.Bson.Serialization.Attributes;
using System;

namespace QuanLiNike
{
    [Serializable]
    internal class signup
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("_username"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Username { get; set; } // Tên người dùng

        [BsonElement("_password"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Password { get; set; } // Mật khẩu

        // Bạn có thể thêm các trường khác nếu cần
    }
}
