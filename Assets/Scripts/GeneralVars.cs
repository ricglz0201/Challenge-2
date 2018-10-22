using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GeneralVars : MonoBehaviour {

	public Text txt;
	public Text timer;
	public static int score;
	static float time;

	void Start() {
		score = 0;
		time = 59.59f;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		txt.text = "Score: " + score;
		timer.text = "Time: " + System.Math.Round(time, 2);

		if (score == 7 && time > 0) {
			SceneManager.LoadScene("WinScene");
		}

		if (time <= 0) {
			time = 0;
			SceneManager.LoadScene("GameOverScene");
		}
	}
}
