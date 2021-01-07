using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// The object we are following
	public GameObject player;

	// The camera this script is attached to
	private Camera self;
	
	void Start () {
		// Fetch the camera, need this to set its position (transform)
		self = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () {
		/* 
		Every frame we check the location (x, z) of the player and update the camera to the same
		X and Y offset for the camera angle.
		*/
		self.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 26f, player.transform.position.z - 7f);
	}
}
