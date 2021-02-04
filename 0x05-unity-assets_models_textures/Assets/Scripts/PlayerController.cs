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

	// The height we respawn the player at
	public float respawn_height;
	public float kill_height;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody>();
	}
	
	void Update() {

		// If the player falls off a platform, respawn them
		if (transform.position.y < kill_height)
		{
			player.velocity = Vector3.zero;
			transform.position = new Vector3(0, respawn_height, 0);
		}
	
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
