using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Score : MonoBehaviour {

	//textbox
	public Text scoretxt; 
	public Text highscoretxt;

	//counters
	public int scoreCount; 
	public int hiScoreCount;
	int levelScore;


	void Start (){
		scoreCount = PlayerPrefs.GetInt ("localScore");
	}

	// Update is called once per frame
	void Update () {
	if(scoreCount > hiScoreCount)
				hiScoreCount = scoreCount; 

		setScore (); 

		printScore (); 
	}

	void setScore (){
		PlayerPrefs.SetInt ("localScore", scoreCount);
		string key = PlayerPrefs.GetString ("highScore");
		if (hiScoreCount > PlayerPrefs.GetInt (key)) {
			
			PlayerPrefs.SetInt (key, hiScoreCount);
		}
	}

	void printScore(){
		if (PlayerPrefs.GetInt ("localScore") >= 0)
		scoretxt.text = "Score: " + PlayerPrefs.GetInt("localScore");
		string key = PlayerPrefs.GetString ("highScore");
		highscoretxt.text = "High Score: " + PlayerPrefs.GetInt (key);
	}

	public void ScoreGain (){
		scoreCount = scoreCount + 10;
		levelScore = levelScore + 10;
	}

	public void ScoreLoss (){
		scoreCount = scoreCount - 10; 
		levelScore = levelScore - 10;
	}

	public int getLevelScore (){
		return levelScore;
	}

}
