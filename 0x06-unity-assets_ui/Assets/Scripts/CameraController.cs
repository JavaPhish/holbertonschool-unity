using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float sensitivity = 3.0f;

	public Transform player;
	
	float x;
	
	void Start () {
		transform.SetParent(player);
	}

	// Update is called once per frame
	void LateUpdate () {
		x += Input.GetAxis("Mouse X") * sensitivity;
		transform.LookAt(player);
		player.rotation = Quaternion.Euler(0, x, 0);
	}
}
