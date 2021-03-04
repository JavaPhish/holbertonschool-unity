using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject menu;
	public GameObject player;
	public GameObject camera;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape"))
		{
			if (Time.timeScale == 0)
				Resume();
			else
				Pause();
		}
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Pause()
	{
		// Disable timer
		player.gameObject.GetComponent<Timer>().enabled = false;

		// Disable controls from player
		camera.gameObject.GetComponent<CameraController>().enabled = false;

		menu.SetActive(true);
		Time.timeScale = 0;
	}

	public void Resume()
	{
		player.gameObject.GetComponent<Timer>().enabled = true;

		// Enable controls to player
		camera.gameObject.GetComponent<CameraController>().enabled = true;

		menu.SetActive(false);
		Time.timeScale = 1;
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void Options()
	{
		SceneManager.LoadScene("Options");
	}
}
