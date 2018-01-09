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

	void Awake ()
	{
		body = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();

	}

	void Update ()
	{
		if (killCounter > 5) {
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
			print ("hi");
			kill = true;
		}
		body.velocity = Vector2.Lerp(body.velocity, velocity, t);
	}

	protected void OnCollisionEnter2D(Collision2D collision){
		if (kill) {
			if (collision.transform.tag == "npc") {
				DestroyObject (collision.gameObject);
			}
			if (collision.transform.tag == "player2") {
				print ("player1 Win!!!!");
				DestroyObject (collision.gameObject);
			}
		}
		
	}

}
