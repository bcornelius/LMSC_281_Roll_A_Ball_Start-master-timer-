using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown_Timer : MonoBehaviour {

	float timeRemaining = 30;
	public Text countText;
	private int count;

	void Start () {

	}

	void Update () {
		timeRemaining -= Time.deltaTime;
		if (count >= 12)
			timeRemaining = timeRemaining;
	}

	void OnGUI(){
		if (timeRemaining > 0) {
			GUI.Label (new Rect (450, 10, 200, 300), "Time Remaining : " + (int)timeRemaining);


		} else {
			if (GUI.Button(new Rect(59, 10, 150, 100), "Restart Level"))
			SceneManager.LoadScene ("Mini_Game");
			}
		}

		}




