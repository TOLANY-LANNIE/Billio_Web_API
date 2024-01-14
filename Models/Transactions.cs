using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BillioAPI.Models;

public class Transaction{


    /// <summary>
    ///  Get or set the <see cref="string"/> primary Id property
    /// </summary> 
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id{get;set;}
    
    /// <summary>
    ///  Get or set the <see cref="string"/>  Budget Name property
    /// </summary>
    public string name{get;set;} = null!;

    /// <summary>
    ///  Get or set the <see cref="decimal"/>  Budget Amount property
    /// </summary>
    public decimal budget{get;set;}

    /// <summary>
    ///  Get or set the <see cref="string"/>  Budget User property
    /// </summary>
    public string user_id{get;set;} = null!;

     /// <summary>
    ///  Get or set the <see cref="DateTime"/>  Budget User property
    /// </summary>
    public DateTime date{get; set;}

}