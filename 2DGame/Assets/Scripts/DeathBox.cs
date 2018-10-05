using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour {

	void OnTriggerEnter2D (Rigidbody2D other){

		if(other.name == "Dude")
		{
			Debug.Log("You Died");
			Destroy(other);
		}

	}
}
	