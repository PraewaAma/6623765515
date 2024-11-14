using System;
using Google.Cloud.Firestore;
using Assignment.Models;

namespace Assignment.Services;

public class Assignment13Service
{
    private FirestoreDb db;
    public string StatusMessage;

    public Assignment13Service()
    {
        this.SetupAssignment13();
    }
    private async Task SetupAssignment13()
    {
        if (db == null)
        {
            var stream = await FileSystem.OpenAppPackageFileAsync("dx212-cd11f-firebase-adminsdk-dguxi-ac1f6a774b.json");
            var reader = new StreamReader(stream);
            var contents = reader.ReadToEnd();
            db = new FirestoreDbBuilder
            {
                ProjectId = "dx212-cd11f",

                JsonCredentials = contents
            }.Build();
        }
    }

    public async Task<List<Assignment13Model>> GetAllAssignment13()
    {
        try
        {
            await SetupAssignment13();
            var data = await db.Collection("Assignment13").GetSnapshotAsync();
            var assignment13 = data.Documents.Select(doc =>
            {
                var assignment13 = new Assignment13Model();
                assignment13.Id = doc.Id;
                assignment13.Id = doc.GetValue<string>("Id");
                assignment13.Code = doc.GetValue<string>("Code");
                assignment13.Name = doc.GetValue<string>("Name");
                return assignment13;
            }).ToList();
            return assignment13;
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }
    public async Task InsertAssignment13(Assignment13Model assignment13)
    {
        try
        {
            await SetupAssignment13();
            var assignment13Data = new Dictionary<string, object>
            {
                { "Id", assignment13.Id },
                { "Code", assignment13.Code },
                { "Name", assignment13.Name }
                // Add more fields as needed
            };

            await db.Collection("Assignment13").AddAsync(assignment13Data);
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
    }
    public async Task UpdateAssignment13(Assignment13Model assignment13)
    {
        try
        {
            await SetupAssignment13();

            // Manually create a dictionary for the updated data
            var assignment13Data = new Dictionary<string, object>
            {
                { "Id", assignment13.Id },
                { "Code", assignment13.Code },
                { "Name", assignment13.Name }
                // Add more fields as needed
            };

            // Reference the document by its Id and update it
            var docRef = db.Collection("Assignment13").Document(assignment13.Id);
            await docRef.SetAsync(assignment13Data, SetOptions.Overwrite);

            StatusMessage = "Assignment13 successfully updated!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }
    public async Task DeleteAssignment13(string id)
    {
        try
        {
            await SetupAssignment13();

            // Reference the document by its Id and delete it
            var docRef = db.Collection("Assignment13").Document(id);
            await docRef.DeleteAsync();

            StatusMessage = "Assignment13 successfully deleted!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

}
