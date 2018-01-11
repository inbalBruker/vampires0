using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
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
	//col 1 = npc , col 2 = player2
	private int col;
	private Transform collid;
	void Awake ()
	{
		collid = null;
		body = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();

	}

	void Update ()
	{
		if (killCounter > 60) {
			killCounter = 0;
			kill = false;
		}
		if (kill) {
			killCounter++;
		}
		float y = transform.position.y;
		sort = Mathf.InverseLerp (-14, 0, y);
		int sortingLayerO = Mathf.FloorToInt(Mathf.Lerp (300, 0, sort));
		if (sprite)
			sprite.sortingOrder = sortingLayerO;
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
		if(Input.GetKeyUp(KeyCode.RightShift)){
			kill = true;
			if (collid != null) {
				print ("you killed " + collid.name);
				DestroyObject (collid.gameObject);
			}

		}
		body.velocity = Vector2.Lerp(body.velocity, velocity, t);
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		collid = null;
		print ("L");
	}

	protected void OnCollisionEnter2D(Collision2D collision){
		
		print ("col");
			if (collision.transform.tag == "npc") {
			collid = collision.transform;
				if (kill) {
				
				print ("hihihihihi");
//				DestroyObject (collision.gameObject);
				}
			}
			if (collision.transform.tag == "player2") {
			collid = collision.transform;
				if (kill) {
				print ("player1 Win!!!!");
//				DestroyObject (collision.gameObject);
				}
			}
	}

}
