using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// How quickly the player can move.
	public float speed = 5;

	// The rigidbody of the player (Used to apply force to the rigidbody comp)
	private Rigidbody player;

	// Number of coins collected so far
	private int score = 0;

	// Player health, can be affected by traps
	public int health = 5;

	// Controls the score text s
	public Text scoreText;

	// Text to control the health section of UI
	public Text healthText;

	// background color for win loss
	public GameObject WinLossObject;
	private Image WinLossImg;
	public Text WinLossTxt;

	// Use this for initialization
	void Start () {
		// Initialize the rigidbody on our player (Using this for movement :)
		player = GetComponent<Rigidbody>();
		WinLossImg = WinLossObject.GetComponent("Image") as Image;
	}

	// Updates the UI text to show the players current score
	void SetScoreText() {
		scoreText.text = "Score: " + score;
	}

	// Updates the health text to show users health
	void SetHealthText() {
		healthText.text = "Health: " + health;
	}

	// When this object contacts a collider with "onTrigger" enabled
	void OnTriggerEnter(Collider other) {
		/*
		 * If this collider is a Pickup, increment score
		 * Output the updated score, and destroy the Pickup
		 */
		if (other.tag == "Pickup")
		{
			score += 1;
			// Debug.Log("Score: " + score);
			SetScoreText();
			Destroy(other.gameObject);
		}

		/*
		 * If the player hits a trap, take off 1 hp
		 * we uhhh dont actually 'kill' the player though?
		 * idk man maybe ive just played too many violent video games
		 *
		 * Update. I was fooled, we do reset the scene on 0 hp (see update function)
		 */
		if (other.tag == "Trap")
		{
			health -= 1;
			//Debug.Log("Health: " + health);
			SetHealthText();
		}

		// Win condition
		if (other.tag == "Goal")
		{
			WinLossObject.SetActive(true);
			WinLossImg.color = Color.green;
			WinLossTxt.color = Color.black;
			WinLossTxt.text = "You Win!";
			//Debug.Log("You win!");
		}
	}

	void Update() {
		// Loss condition, shows game over and resets
		if (health == 0)
		{
			WinLossObject.SetActive(true);
			WinLossImg.color = Color.red;
			WinLossTxt.color = Color.white;
			WinLossTxt.text = "Game Over!";

			health = 5;
			score = 0;
			//Debug.Log("Game Over!");
			StartCoroutine(LoadScene(3f));
		}

		if (Input.GetKey(KeyCode.Escape)) {
			SceneManager.LoadScene("menu");
		}
	}
	
	// Waits n seconds and resets the scene
	IEnumerator LoadScene(float seconds) {
		yield return new WaitForSeconds(seconds);
		health = 5;
		score = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	// FixedUpdate is called consistently on time
	void FixedUpdate() {

		/* 
			Essentially just Addforce in the direction
		   	that the player is pressing. Using AddForce.
		   	3 inputs are X Y Z. Speed is the amount of force
		   	being added to the rigidbody WHILE (button) is
		   	pressed

			We're ignore Y because that would make the ball
			levitate. We do not want that as that would be lame.
		*/

		// UP (W)
		if (Input.GetKey(KeyCode.W)) {
			player.AddForce(0, 0, speed);
		}

		// DOWN (S)
		if (Input.GetKey(KeyCode.S)) {
			player.AddForce(0, 0, speed * -1);
		}

		// RIGHT (D)
		if (Input.GetKey(KeyCode.D)) {
			player.AddForce(speed, 0, 0);
		}

		// LEFT (A)
		if (Input.GetKey(KeyCode.A)) {
			player.AddForce(speed * -1, 0, 0);
		}

	}
}
