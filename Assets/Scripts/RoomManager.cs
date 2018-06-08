using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    public static Dictionary<Side, Vector2> sideVectors = new Dictionary<Side, Vector2>()
    {
        { Side.North, Vector2.up},
        {Side.South, Vector2.down},
        {Side.East, Vector2.right},
        {Side.West, Vector2.left}
    };

    private Rooms[,,] rooms;

    
    //TODO:
    //x, y param are center possition, returns a dictionary of all the rooms that border the given positioned room
    public Dictionary<Side, Room> getNeighbors(int x, int y, int l)
    {
        return null;
    }

    //TODO: implement
    //x, y, and l is the position where the new room is to be created, it should be drawn randomply from acceptable rooms
    //for that level
    public void createRoom(int x, int y, int l)
    {
        //check if the room already exists
    }

    // Use this for initialization
    void Start () {
        rooms = new Rooms[100, 100,3];

		//create start rooms "the lobby"
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
