
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
	private Rigidbody2D body;

	float heading;
	private int Count;

	void Awake ()
	{
		body = GetComponent<Rigidbody2D>();
		// Set random initial rotation 0 = up 1 = down 2 = left 3 = right
		heading = Random.Range(0, 4);


	}

	void Update ()
	{
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