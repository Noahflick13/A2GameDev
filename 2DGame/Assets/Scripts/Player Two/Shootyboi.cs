using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootyboi : MonoBehaviour {
	public Transform FirePoint;
	public GameObject player2projectile;

	// Use this for initialization
	void Start () {
		player2projectile = GameObject.Find("player2projectile");
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
		Instantiate(player2projectile,FirePoint.position, FirePoint.rotation);
		
	}
}
