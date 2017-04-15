using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMcheck : MonoBehaviour {

	public GameObject audioMan;
	// Use this for initialization
	void Start () {
		if (FindObjectOfType<AudioSource> ())
			return;
		else
			Instantiate (audioMan, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
