using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour {
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
		if (Input.GetKey ("w")) {
			velocity.y = ySpeed;
		}
		if (Input.GetKey ("s")) {
			velocity.y = -ySpeed;
		}
		if (Input.GetKey ("a")) {
			velocity.x = -xSpeed;
		}
		if (Input.GetKey ("d")) {
			velocity.x = xSpeed;
		}
		if(Input.GetKeyUp("w")){
			velocity.y = 0;
		}
		if(Input.GetKeyUp("s")){
			velocity.y = 0;
		}
		if(Input.GetKeyUp("d")){
			velocity.x = 0;
		}
		if(Input.GetKeyUp("a")){
			velocity.x = 0;
		}
		body.velocity = Vector2.Lerp(body.velocity, velocity, t);
	}

}
