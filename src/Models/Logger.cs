using api_infor_cell.src.Models.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_infor_cell.src.Models
{
    public class Logger : ModelBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        
        [BsonElement("path")]
        public string Path {get;set;} = string.Empty;
        
        [BsonElement("method")]
        public string Method {get;set;} = string.Empty;
        
        [BsonElement("statusCode")]
        public int StatusCode {get;set;} = 0;
        
        [BsonElement("message")]
        public string Message {get;set;} = string.Empty;
        
        [BsonElement("audit")]
        public bool Audit {get;set;} = false;
    }
}