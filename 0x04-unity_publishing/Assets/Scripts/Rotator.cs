using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		// Just slowly rotates the coin...
		transform.Rotate(Vector3.right * 45 *  Time.deltaTime);
	}
}
