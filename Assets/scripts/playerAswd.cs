﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class playerAswd: MonoBehaviour
	{
		[Header("Animation")]
		[SerializeField] string stabBoll;
		private bool stab;
		private int stabBollAnimID;
		[SerializeField] string moveBoll;
		private bool move;
		private int moveBollID;
		private Animator animator;

		[Header("Movement")]
		[SerializeField] float xSpeed;
		[SerializeField] float ySpeed;
		[Range(0, 1)]
		[SerializeField] float t;
		[Range(0, 1)]
		[SerializeField] float sort;
		private Rigidbody2D body;
		private SpriteRenderer sprite;
		private bool kill;
		private int killCounter;
		private Transform collid;
		//col 1 = npc , col 2 = player2
		private int col;
		private bool playerMoved;
		float heading;
		private int counter;
		void Awake ()
		{
			animator = GetComponent<Animator>();
			stabBollAnimID = Animator.StringToHash(stabBoll);
			moveBollID = Animator.StringToHash(moveBoll);
			collid = null;
			playerMoved = false;
			body = GetComponent<Rigidbody2D>();
			sprite = GetComponent<SpriteRenderer>();

		}
		//private bool facingRight = true;
		void Update ()
		{
			var velocity = body.velocity;
			stab = false;
			if (!playerMoved) {
				counter++;
				if (counter == 15)
				{
					heading  = Random.Range(0, 5);
					counter = 0;
				}

				velocity = body.velocity;
				if (heading == 0) {
					move = true;
					velocity.y = ySpeed;
				}
				if (heading == 1) {
					move = true;
					velocity.y = -ySpeed;
				}
				if (heading == 2) {
					move = true;
					//facingRight = false;
					velocity.x = -xSpeed;
				}
				if (heading == 3) {
					move = true;
					//facingRight = true;
					velocity.x = xSpeed;
				}
				if (heading == 4) {
					move = false;
					velocity.x = 0;
					velocity.y = 0;
				}
				body.velocity = Vector2.Lerp(body.velocity, velocity, t);
			}
			if (killCounter > 5) {
				killCounter = 0;
				kill = false;
			}
			if (kill) {
				killCounter++;
			}
			float y = transform.position.y;
			sort = Mathf.InverseLerp (-14, 14, y); //todo updates
			int sortingLayerO = Mathf.FloorToInt(Mathf.Lerp (300, 0, sort));
			if (sprite)
				sprite.sortingOrder = sortingLayerO;
			if (Input.GetKey (KeyCode.W)) {
				playerMoved = true;
				move = true;
				velocity.y = ySpeed;
			}
			if (Input.GetKey (KeyCode.S)) {
				move = true;
				playerMoved = true;
				velocity.y = -ySpeed;
			}
			if (Input.GetKey (KeyCode.A)) {
				playerMoved = true;
				move = true;
				//facingRight = false;
				velocity.x = -xSpeed;
			}
			if (Input.GetKey (KeyCode.D)) {
				playerMoved = true;
				move = true;
				//facingRight = true;
				velocity.x = xSpeed;
			}
			if(Input.GetKeyUp(KeyCode.W)){
				move = false;
				velocity.y = 0;
			}
			if(Input.GetKeyUp(KeyCode.S)){
				move = false;
				velocity.y = 0;
			}
			if(Input.GetKeyUp(KeyCode.A)){
				move = false;
				velocity.x = 0;
			}
			if(Input.GetKeyUp(KeyCode.D)){
				move = false;
				velocity.x = 0;
			}
			if(Input.GetKeyUp(KeyCode.LeftShift)){
				kill = true;
				stab = true;
				if (collid != null) {
					DestroyObject (collid.gameObject);
				}

			}
			animator.SetBool(moveBollID, move);

			animator.SetBool(stabBollAnimID, stab);
			body.velocity = Vector2.Lerp(body.velocity, velocity, t);
		}

		void OnCollisionExit2D(Collision2D collision)
		{
			collid = null;
		}

		protected void OnCollisionEnter2D(Collision2D collision){

			if (collision.transform.tag == "npc") {
				collid = collision.transform;
				if (kill) {

					//				DestroyObject (collision.gameObject);
				}
			}
			if (collision.transform.tag == "player1") {
				collid = collision.transform;
				if (kill) {
					//				DestroyObject (collision.gameObject);
				}
			}
		}
		 //Depends on if your animation is by default facing right or left

//		void FixedUpdate()
//		{
//			float h = Input.GetAxis("Horizontal");
//			if(h > 0 && !facingRight)
//				Flip();
//			else if(h < 0 && facingRight)
//				Flip();
//		}
//		void Flip ()
//		{
//			print ("hi");
//			facingRight = !facingRight;
//			Vector3 theScale = transform.localScale;
//			theScale.x *= -1;
//			transform.localScale = theScale;
//		}
	}
}

