using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRefLeft : MonoBehaviour {
	[SerializeField] Npc npc;
	public float dis;
	// Use this for initialization
	void Awake ()
	{
		dis = 14;

	}
	
	// Update is called once per frame
	void Update () {

		float y = npc.transform.position.y;

		float x = npc.transform.position.x;

		var deg = 30;
		var rad = deg * Mathf.PI / 180;

		dis = 14 - (y / Mathf.Tan (rad)) - x;
		float thisX = -dis - (dis - x);
		if (x > 0) {
			thisX = -2 * dis - 3 * x;
		}
		if (thisX < -dis) {
			thisX = -dis;
		}
		this.transform.position = new Vector3(thisX, y, transform.position.z);
	}
}
