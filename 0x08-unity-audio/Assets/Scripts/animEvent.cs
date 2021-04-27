using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animEvent : MonoBehaviour {

	public FootstepController thing;

	public AudioSource fallGround;

	void playStepSound()
	{
		thing.playStepSound();
	}

	void splat()
	{
		fallGround.Play(0);
	}
}
