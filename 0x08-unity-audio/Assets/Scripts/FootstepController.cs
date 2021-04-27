using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour {

	private bool onGround;
	public CharacterController controller;
	private string floorType = "None";

	public AudioSource grass;
	public AudioSource rock; 


	// Update is called once per frame
	void Update () {
		//Debug.Log(floorType);
		onGround = controller.isGrounded;

	}

	void playStepSound()
	{
		if (!onGround)
			return;

		if (floorType == "Grass")
		{
			grass.Play(0);
		}
		else
		{
			rock.Play(0);
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
    {
		// Debug.Log(hit.gameObject.tag);
		floorType = hit.gameObject.tag;
    }
}
