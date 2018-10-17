using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Kill : MonoBehaviour {

	public P2Levelmanager P2Levelmanager;
	
	// Use this for initialization
	void Start () {
		P2Levelmanager = FindObjectOfType<P2Levelmanager>();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "Guy") {
			P2Levelmanager.RespawnPlayer();
		}
	}
}
