using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public GameObject CurrentCheckPoint;
	public Rigidbody2D Dude;
	public GameObject Dude2;
	public Animator animator;
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
		Dude = GameObject.Find("Dude").GetComponent<Rigidbody2D>();
		Dude2 = GameObject.Find("Dude");
		animator.SetBool("isDead",false);
	}
	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}
	public IEnumerator RespawnPlayerCo(){
		//Generate Death Particle
		Instantiate (DeathParticle, Dude.transform.position, Dude.transform.rotation);
		//Hide Dude
		//PC.enabled = False;
		Dude2.SetActive(false);
		animator.SetBool("isDead",true);
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
		//Dude.enabled = true;
		Dude2.SetActive(true);
		//Dude.GetComponent<Renderer> ().enabled = true;
		//Spawn Dude
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
		animator.SetBool("isDead",false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
