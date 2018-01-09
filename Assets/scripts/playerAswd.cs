using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class playerAswd: MonoBehaviour
	{
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
			int sortingLayerO = Mathf.FloorToInt(Mathf.Lerp (300, 0, sort));
			if (sprite)
				sprite.sortingOrder = sortingLayerO;
			var velocity = body.velocity;
			if (Input.GetKey (KeyCode.W)) {
				velocity.y = ySpeed;
			}
			if (Input.GetKey (KeyCode.S)) {
				velocity.y = -ySpeed;
			}
			if (Input.GetKey (KeyCode.A)) {
				velocity.x = -xSpeed;
			}
			if (Input.GetKey (KeyCode.D)) {
				velocity.x = xSpeed;
			}
			if(Input.GetKeyUp(KeyCode.W)){
				velocity.y = 0;
			}
			if(Input.GetKeyUp(KeyCode.S)){
				velocity.y = 0;
			}
			if(Input.GetKeyUp(KeyCode.A)){
				velocity.x = 0;
			}
			if(Input.GetKeyUp(KeyCode.D)){
				velocity.x = 0;
			}
			body.velocity = Vector2.Lerp(body.velocity, velocity, t);
		}
	}
}

