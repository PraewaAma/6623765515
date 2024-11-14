using System;
using Google.Cloud.Firestore;

namespace Assignment.Models;

public class Assignment13Model
{
    [FirestoreProperty]
    public string Id { get; set; }
    
    [FirestoreProperty]
    public string Code { get; set; }
    
    [FirestoreProperty]
    public string Name { get; set; }
}
