using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTest : MonoBehaviour {
	[SerializeField] player npc;
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
		float sort = Mathf.InverseLerp (-14, 0, y);
		dis = Mathf.FloorToInt(Mathf.Lerp (14, 0, sort));
		float x = npc.transform.position.y;
		float thisX = -dis - (dis - x);
		this.transform.position = new Vector3(thisX, y, transform.position.z);
	}
}
