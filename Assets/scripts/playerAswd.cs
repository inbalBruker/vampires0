using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerAswd : MonoBehaviour
{
	private const float COOLDOWN_BETWEEN_STABS_CONST = 5;
	[Header("Animation")] [SerializeField] string stabBoll;
	private bool stab;
	private int stabBollAnimID;
	[SerializeField] string moveBoll;
	private bool move;
	private int moveBollID;
	private Animator animator;

	[Header("Movement")] [SerializeField] float xSpeed;
	[SerializeField] float ySpeed;
	[Range(0, 1)] [SerializeField] float t;
	[Range(0, 1)] [SerializeField] float sort;
	private Rigidbody2D body;
	private SpriteRenderer sprite;
	private bool kill;

	private float killCounter;

	//col 1 = npc , col 2 = player2
	private int col;

	private Transform collid;
	private bool playerMoved;
	float heading;
	private int counter;

	//dealy for destroing gameObject

	GameObject toDestroy;
	int dealyCounter;
	bool usedStab;

	void Awake()
	{
		animator = GetComponent<Animator>();
		stabBollAnimID = Animator.StringToHash(stabBoll);
		moveBollID = Animator.StringToHash(moveBoll);
		collid = null;
		body = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		playerMoved = false;

	}

	void Update()
	{
		if (dealyCounter == 30 && usedStab) {
			dealyCounter = 0;
			usedStab = false;
			DestroyObject (toDestroy);
		}
		if (usedStab) {
			++dealyCounter;
		}
		move = false;
		var velocity = body.velocity;
		velocity.y = 0; velocity.x = 0;
		if (velocity.y != 0 || velocity.x != 0) {
			move = true;
		}

		if (!playerMoved)
		{
			counter++;
			if (counter == 15)
			{
				heading = Random.Range(0, 5);
				counter = 0;
			}

			velocity = body.velocity;
			if (heading == 0)
			{
				move = true;
				velocity.y = ySpeed;
			}
			if (heading == 1)
			{
				move = true;
				velocity.y = -ySpeed;
			}
			if (heading == 2)
			{
				move = true;
				velocity.x = -xSpeed;
			}
			if (heading == 3)
			{
				move = true;
				velocity.x = xSpeed;
			}
			if (heading == 4)
			{
				move = false;
				velocity.x = 0;
				velocity.y = 0;
			}
			body.velocity = Vector2.Lerp(body.velocity, velocity, t);
		}


		float y = transform.position.y;
		sort = Mathf.InverseLerp(-14, 14, y); //todo updates
		int sortingLayerO = Mathf.FloorToInt(Mathf.Lerp(300, 0, sort));
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
			heading = 2;
			//facingRight = false;
			velocity.x = -xSpeed;
		}
		if (Input.GetKey (KeyCode.D)) {
			playerMoved = true;
			move = true;
			heading = 3;
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

		stab = false;
		kill = false;
		killCounter -= Time.deltaTime;

		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			// if the cooldown ended
			if (killCounter < 0)
			{
				kill = true;
				stab = true;
				//if we actually killed someone
				if (collid != null)
				{
					//reset cooldown only if he killed someone
					killCounter = COOLDOWN_BETWEEN_STABS_CONST;

					if (collid.transform.tag =="player1")
					{
						//game is over
						print("player1 won");
						SceneManager.LoadScene("player2 win");
					}
					//destroy the object npc otherwise
					//DestroyObject(collid.gameObject);
					usedStab = true;
					toDestroy = collid.gameObject;
				}
			}
		}

		animator.SetBool(moveBollID, move);
		animator.SetBool(stabBollAnimID, stab);
		body.velocity = Vector2.Lerp(body.velocity, velocity, t);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "player1" || other.transform.tag == "npc") {
			collid = other.transform;
		}

	}

	private void OnTriggerExit2D(Collider2D other)
	{
		collid = null;
	}

	//    void OnCollisionExit2D(Collision2D collision)
	//    {
	//        if (collision.otherCollider.isTrigger)
	//        {
	//            collid = null;
	//        }
	//        
	//    }
	//
	//    protected void OnCollisionEnter2D(Collision2D collision)
	//    { 
	//        if (collision.otherCollider.isTrigger)
	//        {
	//            collid = collision.transform;
	//        }
	//    }

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
}