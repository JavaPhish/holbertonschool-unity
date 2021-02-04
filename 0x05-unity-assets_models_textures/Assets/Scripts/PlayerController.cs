using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// How quickly the player can move.
	public float speed = 25;

	// How high a player jumps
	public float jumpForce = 200;

	// The rigidbody of the player (Used to apply force to the rigidbody comp)
	private Rigidbody player;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Jump (Space)
		if (Input.GetKeyDown(KeyCode.Space))
		{
			player.AddRelativeForce(0, jumpForce, 0);
		}

		// UP (W)
		if (Input.GetKey(KeyCode.W)) {
			player.AddRelativeForce(0, 0, speed);
		}

		// DOWN (S)
		if (Input.GetKey(KeyCode.S)) {
			player.AddRelativeForce(0, 0, speed * -1);
		}

		// RIGHT (D)
		if (Input.GetKey(KeyCode.D)) {
			player.AddRelativeForce(speed, 0, 0);
		}

		// LEFT (A)
		if (Input.GetKey(KeyCode.A)) {
			player.AddRelativeForce(speed * -1, 0, 0);
		}
	}
}
