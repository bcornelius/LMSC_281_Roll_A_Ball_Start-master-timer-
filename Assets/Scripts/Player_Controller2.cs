/*
 *Roll-A-Ball Tutorial from Unity3D.com 
 */
//Antonio Espinosa Holguín (AntonioEspinosa branch)
//October 20th, 2016
//This script, essentially identical to the original Player_Controller one, is now "level 2."
//The only real alteration has been a modification in the number of objects to collide with, so that level 2 is "harder" than level 1.
//Also to this end, the variable for the "push" has been changed to 20 in the inspector, so the player is harder to control.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller2 : MonoBehaviour {

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
		if (count >= 15) {
			winText.text = "You've Won the Game!!!";
			timeRemaining = 30;
		}
	}

	void OnGUI(){
		if (timeRemaining > 0) {
			GUI.Label (new Rect (450, 10, 200, 300), "Time Remaining : " + (int)timeRemaining);


		} else {
			if (GUI.Button(new Rect(100, 10, 150, 100), "Restart Level"))
				SceneManager.LoadScene ("Level2");
		}

	}
}
