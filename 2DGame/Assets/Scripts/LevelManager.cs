using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public GameObject CurrentCheckPoint;
	private Rigidbody2D Dude;
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
		Dude = FindObjectOfType<Rigidbody2D> ();
	}
	public void RespawnPlayer(){
		StartCoroutine ("RespawnDudeCo");
	}
	public IEnumerator RespawnPlayerCo(){
		//Generate Death Particle
		Instantiate (DeathParticle, Dude.transform.position, Dude.transform.rotation);
		//Hide Dude
		// PC.enabled = False;
		Dude.GetComponent<Renderer> ().enabled = false;
		//Gravity Reset
		GravityStore = Dude.GetComponent<Rigidbody2D>().gravityScale;
		Dude.GetComponent<Rigidbody2D>().gravityScale = 0f;
		Dude.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//point Penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		//Debug message
		Debug.Log ("Dude Respawn");
		//Respawn Delay
		yield return new WaitForSeconds (RespawnDelay);
		//Gravity Restore
		Dude.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		//Match Dudes transform position
		Dude.transform.position = CurrentCheckPoint.transform.position;
		//Show dude
		//dude.enabled = true;
		Dude.GetComponent<Renderer> ().enabled = true;
		//Spawn Dude
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
