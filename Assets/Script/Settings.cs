using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class Settings: MonoBehaviour {
	

	void Start(){
		
		DontDestroyOnLoad (gameObject.GetComponent<AudioSource>()); 

	}

	void Update(){
		


	}



	public void LoadScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}

	public void exitGame(){
		Application.Quit (); 
	}
}
