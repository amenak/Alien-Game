using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMgr : MonoBehaviour {
	public AudioSource BGM;
	bool play = false;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject); 
		if (FindObjectsOfType<AudioSource> ().Length > 1)
			Destroy (gameObject);
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void audioPlay (){
		play = !play;
		if (play)
			BGM.Play ();
		else
			BGM.Stop ();
	}

	public void VolumeControl(float vc){
		BGM.volume = vc; 
	}

	public void changeBGM(AudioClip music){
	
		if (BGM.clip.name == music.name)
			return;
		BGM.Stop ();
		BGM.clip = music;
		BGM.Play (); 

	}

}
