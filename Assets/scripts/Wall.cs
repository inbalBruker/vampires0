using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
	[SerializeField] Transform origin;
	[SerializeField] Transform wallEnd;
	[SerializeField] Transform prependicular;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 public Vector3 calcPosForNpc(Vector3 curPos)
	{
		float m13 = (prependicular.position[1] - origin.position[1]) / (prependicular.position[0] - origin.position[0]);
		float m23 = (wallEnd.position[1] - origin.position[1]) / (wallEnd.position[0] - origin.position[0]);
		float newX = (m13 * curPos[0] - m23 * wallEnd.position[0] + wallEnd.position[1] - curPos[1]) / (m13-m23);
		float newY = m13*(newX - curPos[0]) + curPos[1];
		var mirror = new Vector3 (newX, newY, 10);
		return mirror - curPos + mirror;
	}
}
