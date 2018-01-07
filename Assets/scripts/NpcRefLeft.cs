using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRefLeft : MonoBehaviour {
	[SerializeField] Npc npc;
	public float dis;
	// Use this for initialization
	void Awake ()
	{
//		
		dis = 14;

	}
	
	// Update is called once per frame
	void Update () {
		float y = npc.transform.position.y;
		float x = npc.transform.position.y;
		float thisX = -dis - (dis - x);
		if (thisX < -dis) {
			thisX = -dis;
		}
		this.transform.position = new Vector3(thisX, y, transform.position.z);
	}
}
