using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    private Room[,,] rooms;
    private int numRoomsSpawned = 0;
    [SerializeField] Room lobby;
    [SerializeField] GameObject player;
    [SerializeField] float floorDimension = 10;

    public static Room[] roomTypes;
    public static Dictionary<Side, Vector2> sideVectors = new Dictionary<Side, Vector2>()
    {
        { Side.North, Vector2.up},
        {Side.South, Vector2.down},
        {Side.East, Vector2.right},
        {Side.West, Vector2.left}
    };

    

    
    
    //TODO: implement
    //x, y, and l is the position where the new room is to be created, it should be drawn randomply from acceptable rooms
    //for that level
    public bool createRoom(int x, int y, int l)
    {
        //check if the room already exists
        if (x < 0 || x >= rooms.GetLength(0) ||
            y < 0 || y >= rooms.GetLength(1) ||
            rooms[x, y, l] != null)
        {
            return false;
        }
        else
        {
            //room doesn't exist, make it
            //first select room
            int roomPos = Random.Range(0, roomTypes.Length);
            Room newRoom = Instantiate(roomTypes[roomPos]) as Room;
            numRoomsSpawned++;
            Vector3 posData = getPossition(x, y, l);
            newRoom.transform.position = new Vector3(posData.x, 1, posData.y);
            newRoom.roomStart(x, y, l, this, player);
            newRoom.GetComponent<Renderer>().enabled = false;
            rooms[x, y, l] = newRoom;
            return true;
        }
    }

    //x, y param are center possition, returns a dictionary of all the rooms that border the given positioned room
    public Dictionary<Side, Room> getNeighbors(int x, int y, int l)
    {
        Dictionary<Side, Room> neighbors = new Dictionary<Side, Room>();
        foreach (Side s in sideVectors.Keys)
        {
            neighbors.Add(s, rooms[(int)sideVectors[s].x + x, (int)sideVectors[s].y + y, l]);
        }
        return neighbors;
    }

    private Vector3 getPossition (int initX, int initY, int initL)
    {
        //TODO implement levels
        Vector3 dim = new Vector3();
        dim.x = (initX - (rooms.GetLength(0) / 2)) * floorDimension;
        dim.y = (initY - (rooms.GetLength(1) / 2)) * floorDimension;
        return dim;
    }

    

    // Use this for initialization
    void Start () {
        roomTypes = Resources.LoadAll<Room>("room prefabs");
        rooms = new Room[30, 30, 3];


        Debug.Log("length: " + roomTypes.GetLength(0));
        Debug.Log(roomTypes[0]);
        //create start rooms "the lobby"
        int middleX = rooms.GetLength(0) / 2;
        int middleY = rooms.GetLength(1) / 2;
        createRoom(middleX, middleY, 1);

        //create player
        GameObject p = Instantiate(player);
        Vector3 posData = getPossition(middleX, middleY, 1);
        p.transform.position = new Vector3(posData.x, floorDimension, posData.y);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
