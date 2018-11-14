using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float Speed;
	public float TimeOut;
	public GameObject Dude;
	public GameObject EnemyDeath;
	public GameObject ProjectileParticle;
	public int PointsForKill;

	// Use this for initialization
	void Start () {
		Dude = GameObject.Find("Dude");

		EnemyDeath = Resources.Load("Prefabs/DeathPS") as GameObject;

		ProjectileParticle = Resources.Load("Prefabs/RespawnPS") as GameObject;

		if(Dude.transform.localScale.x < 0)
			Speed = -Speed;

		//Destroys Projectile after X seconds
		Destroy(gameObject,TimeOut);	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);		
	}

	void onTriggerEnter2D(Collider2D other){
		//Destroys enemy on contact with projectile. Adds points.
		if(other.tag == "Enemy"){
				Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
				Destroy (other.gameObject);
				ScoreManager.AddPoints (PointsForKill);
		}

		// Instantiate
		Destroy(gameObject);
	}

		void OnCollisionEnter2D(Collision2D other)
		{
			Instantiate(ProjectileParticle, transform.position, transform.rotation);
			Destroy (gameObject);	
		}
}
