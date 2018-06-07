using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] Rigidbody playerRB;
    [SerializeField] float movementSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        movement(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
	}

    // Player Movement handled here
    // vert -vertical movement modifier
    // horz -horizontal movement modifier
    void movement (float vert, float horz) {
        Vector3 playerV = playerRB.velocity;
        playerV.x = horz * movementSpeed;
        playerV.z = vert * movementSpeed;
        playerRB.velocity = playerV;
    }
}
