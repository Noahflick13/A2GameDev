﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public Transform FirePoint;
	public GameObject Projectile;

	// Use this for initialization
	void Start () {
		// load projectile from resources/Prefabs folder
		Projectile = Resources.Load("Prefabs/Projectile") as GameObject;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftShift))
		Instantiate(Projectile,FirePoint.position, FirePoint.rotation);
		
	}
}
