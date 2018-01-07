
using UnityEngine;
using System.Collections;

/// <summary>
/// Creates wandering behaviour 
/// </summary>
public class Npc : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField] float xSpeed;
	[SerializeField] float ySpeed;
	[Range(0, 1)]
	[SerializeField] float t;
	[Range(0, 1)]
	[SerializeField] float sort;
	private Rigidbody2D body;

	float heading;
	private int Count;
	private SpriteRenderer sprite;

	void Awake ()
	{
		body = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		// Set random initial rotation 0 = up 1 = down 2 = left 3 = right
		heading = Random.Range(0, 4);


	}

	void Update ()
	{
		float y = transform.position.y;
		sort = Mathf.InverseLerp (-14, 0, y);
		int sortingLayerO = Mathf.FloorToInt(Mathf.Lerp (300, 0, sort));
		if (sprite)
			sprite.sortingOrder = sortingLayerO;
		Count++;
		if (Count == 15) {
			heading = Random.Range(0, 4);
			Count = 0;
		}

		var velocity = body.velocity;
		if (heading == 0) {
			velocity.y = ySpeed;
		}
		if (heading == 1) {
			velocity.y = -ySpeed;
		}
		if (heading == 2) {
			velocity.x = -xSpeed;
		}
		if (heading == 3) {
			velocity.x = xSpeed;
		}
		body.velocity = Vector2.Lerp(body.velocity, velocity, t);
	}


}