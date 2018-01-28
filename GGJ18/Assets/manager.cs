using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameObject.FindObjectsOfType<manager> ().Length == 1) {
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (transform.gameObject);
		}
	}

	void Update() {
		if (Input.GetAxis ("Cancel") != 0 && SceneManager.GetActiveScene().name != "mainMenu") {
			Instantiate (Resources.Load ("pauseMenu"));
		}
	}

	public void loadLevel(string level){
		SceneManager.LoadScene(level);
	}

	public void quit(){
		Application.Quit ();
	}

	public void reload(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}

