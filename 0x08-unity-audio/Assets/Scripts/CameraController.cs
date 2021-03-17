using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

	public float sensitivity = 3.0f;

	public Transform player;
	public Transform camAnchor;
	
	float x, y;
	
	public bool isInverted;

	void Start () {
		isInverted = Convert.ToBoolean(PlayerPrefs.GetInt("isInverted"));
		transform.SetParent(camAnchor);
	}

	// Update is called once per frame
	void LateUpdate () {
		x += Input.GetAxis("Mouse X") * sensitivity;
		y += Input.GetAxis("Mouse Y") * sensitivity;
		
		transform.LookAt(player);
		//player.rotation = Quaternion.Euler(0, x, 0);

		if (isInverted)
			camAnchor.rotation = Quaternion.Euler(-y, x, 0);
		else
			camAnchor.rotation = Quaternion.Euler(y, x, 0);
	}
}
