using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class Room : MonoBehaviour {

    [SerializeField] Side[] sidesWithDoors = { Side.North, Side.South, Side.East, Side.West };
    RoomManager rm;
    private int x;  //X possition  in the grid
    private int y;  //Y possition in the grid
    private int l;  //the level that this tile is on

    //constructor
    public Room(int x, int y, int l)
    {
        this.x = x;
        this.y = y;
        this.l = l;
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

        
        foreach (Side s in sidesWithDoors)
        {
            Room n = neighbors[s];
            if (n == null)
            {
                //create a room here
                //rm.createRoom(x + sideVectors[s].x, y + sideVectors[s].y);
            }
        }
    }

    //TODO: implement
    Dictionary<Side, Room> getNeighbors()
    {
        throw new NotImplementedException();
        return null;
    }
}
