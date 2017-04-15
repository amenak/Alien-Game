using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class UfoControl : MonoBehaviour
{

	public float enemySpeed = 0.03f;
	bool right = true;
	public int health = 10;
	public GameObject bullet;
	Transform firepos;
	public GameObject explosionAnim;
	public float bulletNumber = 2;
	//to follow the player
	public Transform target;
	public int moveSpeed = 3;
	public int rotationSpeed = 3;
	float range = 10f;
	float range2 = 10f;
	public float stop = 0;
	Transform myTransform;
	float distance;
	int score = 0;
	Scene scene;
	public GameObject scoreScript;



	//public GameObject scoreGO;

	void Awake ()
	{
		myTransform = transform; //cache transform data for easy access/preformance
	}


	void Start ()
	{
		//score = PlayerPrefs.GetInt ("localScore");
		firepos = transform.FindChild ("Enemy fire");
		InvokeRepeating ("Fire", 1f, bulletNumber);
		scene = SceneManager.GetActiveScene (); 
	
	}

	void Update ()
	{
		if (scene.name == "GameMode")
			ufoMovement2 ();
		else
			ufoMovement1 ();

		if (health == 0) {
			playExplosion (); 
			Destroy (gameObject);
		}
	    


	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "bullet") {
			Destroy (other.gameObject);
			health--; 
			scoreScript.GetComponent<Score> ().ScoreGain ();



		}


	}

	void Fire ()
	{
		//Vector3 direction = GameObject.Find ("airplane").transform.position - bullet.tra
		Instantiate (bullet, firepos.position, Quaternion.identity);	
	}

	void playExplosion ()
	{
		GameObject explosion = (GameObject)Instantiate (explosionAnim); 
		explosion.transform.position = transform.position; 

	}

	public int GetHealth ()
	{
		return health;
	}

	void ufoMovement1 ()
	{
		//rotate to look at the player
		distance = Vector3.Distance (myTransform.position, target.position);
		if (distance <= range2 && distance >= range) {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
				Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		} else if (distance <= range && distance > stop) {

			//move towards the player
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
				Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		} else if (distance <= stop) {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
				Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		}

		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
	
	}

	void ufoMovement2 ()
	{
		//automatic movement
		if (transform.position.x < 5.8f && right == true)
			transform.Translate (Vector3.right * enemySpeed);
		else
			right = false;
		
		if (transform.position.x > -5.8f && right == false)
			transform.Translate (Vector3.left * enemySpeed);
		else
			right = true; 
		
	}

	public int GetScore(){
		return score;
	}
}
	






