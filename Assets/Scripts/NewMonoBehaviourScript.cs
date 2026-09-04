using SQLite;
using UnityEngine;
using System.IO;

public class DatabaseManager : MonoBehaviour
{
    private SQLiteConnection db;

    void Start()
    {
        string dbPath = Path.Combine(Application.streamingAssetsPath, "game.db");
        db = new SQLiteConnection(dbPath);
        TestRead();
    }

    void TestRead()
    {
        var query = db.Query<Planet>("SELECT * FROM planets");
        foreach (var planet in query)
        {
            Debug.Log("Planet: " + planet.name);
        }
    }
}

public class Planet
{
    public int id { get; set; }
    public string name { get; set; }
    public int unlock_level { get; set; }
}