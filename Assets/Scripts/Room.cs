using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Room : MonoBehaviour {

    private enum Side
    {
        North = new int[] {1, 0} ,
        South = 2,
        East  = 3,
        West  = 4
    };


    [SerializeField] Dictionary<Side, bool> sidesWithDoors = { 0, 1, 2, 3 };
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
                rm.createRoom(x + s.x, y +s.y);
            }
            
        }
    }
}
