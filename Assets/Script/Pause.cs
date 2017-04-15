using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject PauseUI;
	private bool paused = false;

	void Start(){
		PauseUI.SetActive (false); 

	}
	void Update (){
		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0; 
		}

		if (!paused) {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	
	}

	public void resume(){
		paused = false;
	}

	public void MainMenu(){
		PlayerPrefs.DeleteKey ("lives");
		PlayerPrefs.DeleteKey ("localScore");
		SceneManager.LoadScene ("Main Menu"); 
	}
	public void Quit(){
		Application.Quit (); 
	}
	
	public void buttonPushed(){
		paused = !paused;
			
	}

}
