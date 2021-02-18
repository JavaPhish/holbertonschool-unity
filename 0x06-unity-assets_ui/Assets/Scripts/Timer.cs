using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	// The timers text object in UI
	public Text TimerText;
	private float timer;
	private float minutes, seconds;
	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime;
		minutes = Mathf.FloorToInt(timer / 60f);
		seconds =  timer - minutes * 60;
		TimerText.text = string.Format("{0:0}:{1:00.00}", minutes, seconds);
	}
}
