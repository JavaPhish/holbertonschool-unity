using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour {
	void OnDestroy()
	{
		PlayerPrefs.SetString("previous_scene", SceneManager.GetActiveScene().name);
	}
}
