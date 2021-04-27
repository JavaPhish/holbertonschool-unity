using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animEvent : MonoBehaviour {

	public FootstepController thing;

	void playStepSound()
	{
		thing.playStepSound();
	}
}
