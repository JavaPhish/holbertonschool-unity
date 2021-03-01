using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public void Back()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
	
}
