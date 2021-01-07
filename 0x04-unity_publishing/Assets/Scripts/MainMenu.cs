using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Material trapMat;
	public Material goalMat;
	public Toggle colorblindMode;

	// Loads scene related to given button
	public void PlayMaze() {
		
		if (colorblindMode.isOn) {
			trapMat.color = new Color32(255, 112, 0, 1);
			goalMat.color = Color.blue;
		} else {
			trapMat.color = new Color32(255, 0, 0, 1);
			goalMat.color = Color.green;
		}

		SceneManager.LoadScene("maze");
	}

	// Quits the game
	public void QuitMaze() {
		Application.Quit();
		Debug.Log("Quit Game");
	}
}
