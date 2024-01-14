using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace BillioAPI.Models;


public class Bills{


    /// <summary>
    /// Get or set the <see cref="string"/> primary Id property
    /// </summary> 
    [BsonId] 
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id{get;set;}

    /// <summary>
    ///  Get or set the <see cref="string"/>  Bill Description property
    /// </summary>
    public string description{get;set;} = null!;

    /// <summary>
    ///  Get or set the <see cref="Date"/>  Bill Due Date property
    /// </summary>
    public DateTime due_date{get;set;}

    /// <summary>
    ///  Get or set the <see cref="string"/>  Bill Budget property
    /// </summary>
    public string? budget_id{get; set;}

    /// <summary>
    ///  Get or set the <see cref="decimal"/>  Bill Amount property
    /// </summary>
    public decimal amount{get;set;}

    /// <summary>
    ///  Get or set the <see cref="string"/>  Bill Status property
    /// </summary>
    public string status{get;set;} = null!;

    /// <summary>
    ///  Get or set the <see cref="string"/>  Bill User property
    /// </summary>
    public string user_id{get;set;} = null!;

}