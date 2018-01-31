using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRefLeft : MonoBehaviour {
	[Header("Animation")]
	[SerializeField] string moveBoll;
	private bool move;
	private int moveBollID;
	private Animator animator;

	[SerializeField] Npc npc;
	[SerializeField] Wall leftWall;
	public float dis;
	// Use this for initialization
	public Renderer rend;
	void Awake ()
	{
		animator = GetComponent<Animator>();
		moveBollID = Animator.StringToHash(moveBoll);
		rend = GetComponent<Renderer>();
		dis = 14;

	}
	
	// Update is called once per frame
	void Update () {
		if (npc == null) {
			Destroy (this.gameObject);
			return;
		}


		Vector3 npcPos = npc.transform.position;
		dis = Mathf.Sqrt ((this.transform.position.x - npcPos [0]) * (this.transform.position.x - npcPos [0]) + (this.transform.position.y - npcPos [1]) * (this.transform.position.y - npcPos [1]));
		float sort = Mathf.InverseLerp (0, 18, dis);  //todo updates
		float colorOp;
		colorOp = (Mathf.Lerp (1, 0, sort));
		rend.material.color = new Color(rend.material.color.r,rend.material.color.g, rend.material.color.b, colorOp);
		Vector3 temp = leftWall.calcPosForNpc(npc.transform.position);
//		temp [0] += 1.7f;
		temp [1] += 0.95f;  //todo updates
		this.transform.position = temp;
		move = npc.isMoving();
		animator.SetBool(moveBollID, move);
	}


}
