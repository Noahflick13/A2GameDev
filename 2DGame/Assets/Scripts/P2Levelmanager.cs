using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Levelmanager : MonoBehaviour {
	public GameObject CurrentCheckPoint;
	public Rigidbody2D Guy;
	//particles
	public GameObject DeathParticle;
	public GameObject RespawnParticle;

	//Respawn Delay
	public float RespawnDelay;

	//point penalty on Death
	public int PointPenaltyOnDeath;

	//Store Gravity Value
	private float GravityStore;

	// Use this for initialization
	void Start () {
		//Dude = FindObjectOfType<Rigidbody2D> ();
	}
	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}
	public IEnumerator RespawnPlayerCo(){
		//Generate Death Particle
		Instantiate (DeathParticle, Guy.transform.position, Guy.transform.rotation);
		//Hide Dude
		// PC.enabled = False;
		Guy.GetComponent<Renderer> ().enabled = false;
		//Gravity Reset
		GravityStore = Guy.GetComponent<Rigidbody2D>().gravityScale;
		Guy.GetComponent<Rigidbody2D>().gravityScale = 0f;
		Guy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//point Penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		//Debug message
		Debug.Log ("Dude Respawn");
		//Respawn Delay
		yield return new WaitForSeconds (RespawnDelay);
		//Gravity Restore
		Guy.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		//Match Dudes transform position
		Guy.transform.position = CurrentCheckPoint.transform.position;
		//Show dude
		//dude.enabled = true;
		Guy.GetComponent<Renderer> ().enabled = true;
		//Spawn Dude
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
