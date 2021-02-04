using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour {

    void OnCollisionExit(Collision other)
    {
		// Activate the timer and destroy the trigger (it has a collider on it)
        other.gameObject.GetComponent<Timer>().enabled = true;
		Destroy(gameObject);
    }
}
