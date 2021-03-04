using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// How quickly the player can move.
	public float speed = 3.0f;

	// How high a player jumps
	public float jumpForce = 2.0f;

	public CharacterController controller;

	private Vector3 velocity;

	private bool onGround;

	public float gravity_force = 15f;

	// The height we respawn the player at
	public float respawn_height;
	public float kill_height;
	



	// Update is called once per frame
	void FixedUpdate () {
		onGround = controller.isGrounded;
		// If the player falls off a platform, respawn them
		if (transform.position.y < kill_height)
		{
			velocity = Vector3.zero;
			transform.position = new Vector3(0, respawn_height, 0);
		}

		if (onGround)
		{
			velocity.y = 0f;
		}

		Vector3 player_move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		controller.Move(player_move * Time.deltaTime * speed);

		if (player_move != Vector3.zero)
		{
			gameObject.transform.forward = player_move;
		}

		//gravity...
		if (Input.GetButtonDown("Jump") && onGround)
		{
			velocity.y += Mathf.Sqrt(jumpForce * -3.0f * -gravity_force);
		}

		velocity.y -= gravity_force * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
	}
}
