using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class AirplaneControl : MonoBehaviour {
	public Rigidbody2D rigid;
	float horizontal;
	float vertical;
	public float speed = 7.0f;
	bool isFacingRight = true;
	public float force = 300.0f;
	public GameObject bullet; 
	Transform firepos; 
	public int health = 10; 
	public GameObject explosionAnim; 
	int score = 0;
	//public Text scoretxt; 
	public GameObject scoreScript;

	// Use this for initialization
	void Start () {
		if (rigid == null) {
			rigid = GetComponent<Rigidbody2D> ();
		}
		force = 300.0f;
		firepos = transform.FindChild ("firePos");
		//score = PlayerPrefs.GetInt ("localScore");
	}

	// Update is called once per frame, better for input
	void Update () {
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");
		if(Input.GetKeyDown(KeyCode.Space))
			Fire();  
		if (health == 0) {
			playExplosion (); 
			Destroy (gameObject);
		}


	}

	void FixedUpdate()
	{
		
		//player movement
		rigid.velocity = new Vector2 (vertical * speed, rigid.velocity.y);
		rigid.velocity = new Vector2 (horizontal * speed, rigid.velocity.x);

	}

	public void Flip()
	{
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x * -1;
		transform.localScale = playerScale;
		isFacingRight = !isFacingRight;
	}
	
	void Fire (){
		Instantiate (bullet, firepos.position, Quaternion.identity);	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//If player gets hit by enemy bullet, destroy the bllet, lower the health, and if score is greater than 0 lower it by 10
		if (other.tag == "enemy bullet") {
			Destroy (other.gameObject);
			health--; 
			scoreScript.GetComponent<Score> ().ScoreLoss ();

		}
		//if player gets touched by UFO, lower your health
		if (other.tag == "ufo") {
			health = health - 2; 
		}
	}

	void playExplosion(){
		GameObject explosion = (GameObject)Instantiate (explosionAnim); 
		explosion.transform.position = transform.position; 

	}

	public int GetHealth(){
		return health;
	}
	public int GetScore(){
		return score;
	}

	public void setScore(int x){
		score = score + x;
	}


}
