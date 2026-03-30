using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public int gridWidth = 5;
    public int gridHeight = 5;
    public float roomSize = 16f;
    public GameObject roomPrefab;

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                int roll = Random.Range(0, 3);
                if (roll > 0)
                {
                    Vector3 pos = new Vector3(x * roomSize, y * roomSize, 0);
                    Instantiate(roomPrefab, pos, Quaternion.identity);
                }
            }
        }
    }
}