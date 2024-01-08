using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BillioAPI.Models;

public class Budget{


    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id{get;set;}
    public string name{get;set;} = null!;
    public decimal budget{get;set;}
    public string user_id{get;set;} = null!;

}