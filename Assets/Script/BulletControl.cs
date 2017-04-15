using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {
	//public float bulletSpeed = 0.05f;
	public Vector2 speed;
	Rigidbody2D rb;

	void Start (){
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = speed; 
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = speed; 
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{


	}
	

}
