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

	void Awake ()
	{
		body = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();

	}

	void Update ()
	{
		float y = transform.position.y;
		sort = Mathf.InverseLerp (-14, 0, y);
		print (sort);
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
		body.velocity = Vector2.Lerp(body.velocity, velocity, t);
	}

}
