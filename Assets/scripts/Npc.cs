using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

/// <summary>
/// Creates wandering behaviour 
/// </summary>
public class Npc : MonoBehaviour
{
	[Header("Animation")]
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
	public bool isDead;

	float heading;
	private int Count;
	private SpriteRenderer sprite;
	private int[] arr = {1,2,3,4,2,3,3,2,3,1,4,3,2,2,1,2,1,2,3,4,2,3,3,2,3,1,4,3,2,2,11,2,3,4,2,3,3,2,3,1,4,3,2,2,1,22,3,3,2,3,1,4,3,2,2,1,2,2,1,2,1,2,3,4,2,3,3,2,3,1,4,3,2,2,1,2};
	private int counter;

	// 0 = npc 1=player1 2=player2(Aswd)
	private int type;
	Npc scriptNpc; //creates that script data type
	player scriptPlayer;
	playerAswd scriptPlayerAswd;
	
	void Awake ()
	{
//		type = 0;
//		scriptNpc = GetComponent<Npc>();
//		scriptPlayer = GetComponents<player> ();
//		scriptPlayerAswd = GetComponents<playerAswd> ();
//		if (type == 0) {
//			scriptPlayer.enabled = false;
//			scriptPlayerAswd.enabled = false;
//		}
//		if (type == 1) {
//			scriptNpc.enabled = false;
//			scriptPlayerAswd.enabled = false;
//		}
//		if (type == 2) {
//			scriptPlayer.enabled = false;
//			scriptNpc.enabled = false;
//		}
		animator = GetComponent<Animator>();
		moveBollID = Animator.StringToHash(moveBoll);
		body = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		// Set random initial rotation 0 = up 1 = down 2 = left 3 = right 4 = stop
		heading = Random.Range(0, 5);
		isDead = false;
	}

	void Update ()
	{
		float y = transform.position.y;
		sort = Mathf.InverseLerp (-14, 14, y);  //todo updates
		int sortingLayerO = Mathf.FloorToInt(Mathf.Lerp (300, 0, sort));
		if (sprite)
			sprite.sortingOrder = sortingLayerO;
		counter++;
		if (counter == arr.Length)
		{
			heading  = Random.Range(0, 5);
			counter = 0;
		}

		var velocity = body.velocity;
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
			velocity.x = -xSpeed;
		}
		if (heading == 3) {
			move = true;
			velocity.x = xSpeed;
		}
		if (heading == 4) {
			move = false;
			velocity.x = 0;
			velocity.y = 0;
		}
		body.velocity = Vector2.Lerp(body.velocity, velocity, t);
		animator.SetBool(moveBollID, move);
	}

	public bool isMoving(){
		return move;
	}

	public void changeType(int typeGiven){
		type = typeGiven;
	}
	private bool facingRight = true; //Depends on if your animation is by default facing right or left

	void FixedUpdate()
	{
		float h = 0;
		if (heading == 2) {
			h = -1;
		}
		if (heading == 3) {
			h = 1;
		}


		if(h > 0 && !facingRight)
			Flip();
		else if(h < 0 && facingRight)
			Flip();
	}
	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public float getDirection(){
		return heading;
	}


}