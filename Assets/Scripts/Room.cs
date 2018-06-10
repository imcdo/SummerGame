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

    private int playerLevel;
    private bool neighborsCalculated;
    private GameObject player;

    //constructor
    public void roomStart(int x, int y, int l, RoomManager rm, GameObject player)
    {
        this.x = x;
        this.y = y;
        this.l = l;
        this.rm = rm;
        this.player = player;
        
    }

	// Use this for initialization
	void Start () {
        neighborsCalculated = false;
        playerLevel = LayerMask.NameToLayer("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        //load the neighboring tiles if they havnet spawned
        Dictionary<Side, Room> neighbors = rm.getNeighbors(x, y, l);
        Debug.Log(col.gameObject.name +  "has collided with tile x: " + x + ", y: " + y);

        gameObject.GetComponent<Renderer>().enabled = true;
        if (col.gameObject.layer.Equals(playerLevel))
        {
            if (!neighborsCalculated)
            {
                foreach (Side s in sidesWithDoors)
                {
                    Debug.Log("detecting side:" + s.ToString());
                    Room n = neighbors[s];
                    if (n == null)
                    {
                        Debug.Log("Originial x: " + x + "new x: " + (x + (int)RoomManager.sideVectors[s].x));
                        Debug.Log("Originial y: " + y + "new y: " + (y + (int)RoomManager.sideVectors[s].y));
                        //create a room here
                        rm.createRoom(x + (int)RoomManager.sideVectors[s].x, y + (int)RoomManager.sideVectors[s].y, 1);
                    }
                }
                neighborsCalculated = true;
            }
        }
    }
}
