/*
 *Roll-A-Ball Tutorial from Unity3D.com 
 */
//Antonio Espinosa Holguín (Antonio Espinosa branch)
//October 20th, 2016
//This script has been altered so that it functions as the "level 1" script.
//To that end the "you've won!" behaviour has been changed to a LoadScene function.

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour {

	private Rigidbody objectRigidbody;
	public float push;
	private int count;
	public Text countText;
	public Text winText;
	float timeRemaining = 30;

	// Use this for initialization
	void Start () {
		objectRigidbody = GetComponent<Rigidbody>();
		count = 0;
		SetCounter();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		objectRigidbody.AddForce(movement*push);

		// establishes the time
		timeRemaining -= Time.deltaTime;
	}

	void OnTriggerEnter (Collider collObject) {
		if (collObject.gameObject.CompareTag("PickUp")) {
			collObject.gameObject.SetActive(false);
			count++;
			SetCounter();
		}
	}

	void SetCounter() {
		countText.text = "Count: " + count.ToString();

		}
		

	void OnGUI(){
		if (timeRemaining > 0) {
			GUI.Label (new Rect (450, 10, 200, 300), "Time Remaining : " + (int)timeRemaining);


		} else {
			if (GUI.Button(new Rect(100, 10, 150, 100), "Restart Game"))
				SceneManager.LoadScene ("Mini_Game");
		}
		if (count >= 12) {
			if (GUI.Button(new Rect(100, 10, 150, 100), "Next Level"))
				SceneManager.LoadScene ("Level2");
			timeRemaining = 30;
		}
	}
	}



