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
//		float sort = Mathf.InverseLerp (-14, 0, y);
//		print ("sort: " + sort);
//		dis = Mathf.FloorToInt(Mathf.Lerp (14, 1, sort));
//		if (y < 0) {
//			dis = 14;
//		}
//		print ("dis:" + dis);
		float x = npc.transform.position.y;

		var deg = 60;
		var rad = deg * Mathf.PI / 180;

		dis = 14 - (y / Mathf.Tan (rad)) - x;
		float thisX = -dis - (dis - x);
		if (thisX < -dis) {
			thisX = -dis;
		}
		this.transform.position = new Vector3(thisX, y, transform.position.z);
	}
}
