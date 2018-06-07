using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Room : MonoBehaviour {

    private enum Side
    {
        North,
        South,
        East,
        West
    };

    Dictionary<Side, Vector2> sideVectors = new Dictionary<Side, Vector2>()
    {
        { Side.North, Vector2.up},
        {Side.South, Vector2.down},
        {Side.East, Vector2.right},
        {Side.West, Vector2.left}
    };
       
    RoomManager rm;
    private int x;  //X possition  in the grid
    private int y;  //Y possition in the grid
    private int l;  //the level that this tile is on

    //constructor
    public Room(int x, int y, int l)
    {

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        //load the neighboring tiles if they havnet spawned
        Dictionary<Side, Room> neighbors = getNeighbors();

        
        foreach (Side s in Enum.GetValues(typeof(Side)))
        {
            Room n = neighbors[s];
            if (n == null)
            {
                //create a room here
                rm.createRoom(x + sideVectors[s].x, y + sideVectors[s].y);
            }
        }
    }
}
