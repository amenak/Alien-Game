using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class menu2 : MonoBehaviour {

	public Text highscoretxt;
	public Text nameTxt;
	string key; 

	void Start(){
		
		/*if (PlayerPrefs.HasKey (key)) {
			highscoretxt.text = "High Score:\n" + PlayerPrefs.GetInt (key);
		} else {*/
			highscoretxt.text = "High Score:\n" + 0;
			PlayerPrefs.SetString ("highScore", key);

			
	}

	void Update(){
		key = nameTxt.text;
		if (PlayerPrefs.HasKey (key)) {
			highscoretxt.text = "High Score:\n" + PlayerPrefs.GetInt (key);
		} else {
			highscoretxt.text = "High Score:\n" + "No Score";
			PlayerPrefs.SetString ("highScore", key);
		}


	}

	public void LoadScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}

	public void exitGame(){
		Application.Quit (); 
	}
}
