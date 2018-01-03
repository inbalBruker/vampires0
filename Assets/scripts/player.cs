﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	[Header("Movement")]
	[SerializeField] float xSpeed;
	[SerializeField] float ySpeed;
	[Range(0, 1)]
	[SerializeField] float t;
	private Rigidbody2D body;


	void Awake ()
	{
		body = GetComponent<Rigidbody2D>();


	}

	void Update ()
	{

		var velocity = body.velocity;
		if (Input.GetKey ("up")) {
			velocity.y = ySpeed;
		}
		if (Input.GetKey ("down")) {
			velocity.y = -ySpeed;
		}
		if (Input.GetKey ("left")) {
			velocity.x = -xSpeed;
		}
		if (Input.GetKey ("right")) {
			velocity.x = xSpeed;
		}
		if(Input.GetKeyUp("up")){
			velocity.y = 0;
		}
		if(Input.GetKeyUp("down")){
			velocity.y = 0;
		}
		if(Input.GetKeyUp("right")){
			velocity.x = 0;
		}
		if(Input.GetKeyUp("left")){
			velocity.x = 0;
		}
		body.velocity = Vector2.Lerp(body.velocity, velocity, t);
	}

}
