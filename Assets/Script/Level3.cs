using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class Level3 : MonoBehaviour {

	public Text health; 
	public Text Lives;
	float enemyHealth;
	float playerHealth;
	public GameObject ufo;
	public GameObject player;
	int livesNo; 
	// Use this for initialization
	void Start () {
		ufo = GameObject.Find("UFO"); 
		player = GameObject.Find("airplane");
		livesNo = PlayerPrefs.GetInt ("lives");
		Lives.text = "LIVES: " + PlayerPrefs.GetInt("lives");
	}

	// Update is called once per frame
	void Update () {
		if (ufo)
			enemyHealth = ufo.GetComponent<UfoControl> ().GetHealth (); 
		if (player)
			playerHealth = player.GetComponent<AirplaneControl> ().GetHealth (); 

		if(enemyHealth >= 0 || playerHealth >=0)
			health.text = "Enemy Health: " + enemyHealth + "\nPlayer Health: " + playerHealth; 

		if (playerHealth == 0) {
			livesNo--;
			if (livesNo < 1) {
				PlayerPrefs.DeleteKey ("lives");
				PlayerPrefs.DeleteKey ("localScore");
				SceneManager.LoadScene ("Main Menu");
			}
			else
				PlayerPrefs.SetInt ("lives", livesNo);
			SceneManager.LoadScene ("Level3");
		}
		if (enemyHealth == 0) {
			PlayerPrefs.DeleteKey ("localScore");
			PlayerPrefs.DeleteKey ("lives");
			SceneManager.LoadScene ("Main Menu"); 
		}
	}
}
