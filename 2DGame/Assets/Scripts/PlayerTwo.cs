﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour {

	//player movement variables
	public int moveSpeed;
	public float jumpHeight;
	private bool doubleJump;

	//Player grounded variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	//non-Slide player
	private float moveVelocity;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {

		//this code makes the character jump
		if(Input.GetKeyDown (KeyCode.UpArrow)&& grounded){
			Jump();
		}

		//double jump code
		if(grounded)
			doubleJump = false;

		if(Input.GetKeyDown (KeyCode.UpArrow)&& !doubleJump && !grounded){
			Jump();
			doubleJump = true;
		}
		//Non-slide player
		moveVelocity = 0f;

		//This code makes the character move from side to side using the A&D keys
		if(Input.GetKey (KeyCode.RightArrow)){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = moveSpeed;
		}
		if(Input.GetKey (KeyCode.LeftArrow)){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = -moveSpeed;
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

		//player flip
		if (GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(0.1f,0.1f,1f);

		else if (GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(-0.1f,0.1f,1f);
		
	}
	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
}
