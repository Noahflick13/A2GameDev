using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public Transform FirePoint;
	public GameObject Projectile;
	public Animator animator;
	
	
	

	// Use this for initialization
	void Start () {
		// load projectile from resources/Prefabs folder
		Projectile = Resources.Load("Prefabs/Projectile") as GameObject;
		animator.SetBool("isShooting",false);
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftShift)){
		animator.SetBool("isShooting",true);
		Instantiate(Projectile,FirePoint.position, FirePoint.rotation);
	}

		
		else if(Input.GetKeyDown(KeyCode.LeftShift)){
			animator.SetBool("isShooting",false);
		}

	}
}
