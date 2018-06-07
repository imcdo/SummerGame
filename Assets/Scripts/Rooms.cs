using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour {

    [SerializeField]private Rigidbody floor;
    [SerializeField] private GameObject player;
    private bool loadedNeighbors;
    
   
	// Use this for initialization
	void Start ()
    {
		//TODO: determine if neibors have already been calculated
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (loadedNeighbors == false)
        {
            //create the neighbors
        }
    }
}
