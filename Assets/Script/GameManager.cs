using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public class GameManager : MonoBehaviour {
	public Text health;
	public Text Lives;
	float enemyHealth;
	float playerHealth;
	public GameObject ufo;
	public GameObject player;
	int scoreReset;
	public int livesNo = 2;
	// Use this for initialization

	void Start () {
		if (PlayerPrefs.HasKey ("lives"))
			livesNo = PlayerPrefs.GetInt ("lives");
		else 
			PlayerPrefs.SetInt ("lives", livesNo);
		
		PlayerPrefs.SetInt ("localScore", 0);
		if(PlayerPrefs.GetInt("lives") >= 0)
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
			scoreReset = PlayerPrefs.GetInt ("localScore") - GetComponent<Score> ().getLevelScore ();
			PlayerPrefs.SetInt ("localScore", scoreReset);
			livesNo--;
			if (livesNo < 1) {

				PlayerPrefs.DeleteKey ("lives");
				PlayerPrefs.DeleteKey ("localScore");
				SceneManager.LoadScene ("Main Menu");


			}
			PlayerPrefs.SetInt ("lives", livesNo);
			SceneManager.LoadScene ("GameMode");
		}
		if(enemyHealth == 0)
			SceneManager.LoadScene ("Level2"); 
	}
}
