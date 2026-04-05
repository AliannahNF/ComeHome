using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DungeonGenerator : MonoBehaviour
{
    public int roomCount = 10;
    public int roomWidth = 10;
    public int roomHeight = 8;
    public Tilemap tilemap;
    public TileBase wallTile;

    private List<Vector2Int> rooms = new List<Vector2Int>();

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        tilemap.ClearAllTiles();
        rooms.Clear();

        Vector2Int current = Vector2Int.zero;
        rooms.Add(current);

        Vector2Int[] dirs = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

        for (int i = 0; i < roomCount - 1; i++)
        {
            Vector2Int dir = dirs[Random.Range(0, dirs.Length)];
            current += dir;
            if (!rooms.Contains(current))
                rooms.Add(current);
        }

        foreach (var room in rooms)
        {
            DrawRoom(room);
        }

        foreach (var room in rooms)
        {
            foreach (var dir in dirs)
            {
                if (rooms.Contains(room + dir))
                    DrawDoorway(room, dir);
            }
        }

        // Spawn daughter in a random middle room
        if (rooms.Count > 1)
        {
            Vector2Int daughterRoom = rooms[Random.Range(1, rooms.Count - 1)];
            int dx = daughterRoom.x * (roomWidth + 1) + roomWidth / 2;
            int dy = daughterRoom.y * (roomHeight + 1) + roomHeight / 2;

            GameObject daughter = GameObject.Find("Daughter");
            if (daughter != null)
                daughter.transform.position = new Vector3(dx, dy, 0);
        }

        // Spawn escape trigger in the last room
        Vector2Int exitRoom = rooms[rooms.Count - 1];
        int ex = exitRoom.x * (roomWidth + 1) + roomWidth / 2;
        int ey = exitRoom.y * (roomHeight + 1) + roomHeight / 2;

        GameObject escape = GameObject.Find("EscapeTrigger");
        if (escape != null)
            escape.transform.position = new Vector3(ex, ey, 0);
    }

    void DrawRoom(Vector2Int roomPos)
    {
        int ox = roomPos.x * (roomWidth + 1);
        int oy = roomPos.y * (roomHeight + 1);

        for (int x = 0; x <= roomWidth; x++)
        {
            for (int y = 0; y <= roomHeight; y++)
            {
                bool isWall = x == 0 || x == roomWidth || y == 0 || y == roomHeight;
                if (isWall)
                    tilemap.SetTile(new Vector3Int(ox + x, oy + y, 0), wallTile);
            }
        }
    }

    void DrawDoorway(Vector2Int roomPos, Vector2Int dir)
    {
        int ox = roomPos.x * (roomWidth + 1);
        int oy = roomPos.y * (roomHeight + 1);

        int midX = ox + roomWidth / 2;
        int midY = oy + roomHeight / 2;

        if (dir == Vector2Int.right)
        {
            tilemap.SetTile(new Vector3Int(ox + roomWidth, midY, 0), null);
            tilemap.SetTile(new Vector3Int(ox + roomWidth, midY + 1, 0), null);
        }
        else if (dir == Vector2Int.left)
        {
            tilemap.SetTile(new Vector3Int(ox, midY, 0), null);
            tilemap.SetTile(new Vector3Int(ox, midY + 1, 0), null);
        }
        else if (dir == Vector2Int.up)
        {
            tilemap.SetTile(new Vector3Int(midX, oy + roomHeight, 0), null);
            tilemap.SetTile(new Vector3Int(midX + 1, oy + roomHeight, 0), null);
        }
        else if (dir == Vector2Int.down)
        {
            tilemap.SetTile(new Vector3Int(midX, oy, 0), null);
            tilemap.SetTile(new Vector3Int(midX + 1, oy, 0), null);
        }
    }
}