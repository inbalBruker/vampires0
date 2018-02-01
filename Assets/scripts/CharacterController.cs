using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "PlayerController")]
public class PlayerController : ScriptableObject
{
	[SerializeField] KeyCode up;
	[SerializeField] KeyCode down;
	[SerializeField] KeyCode left;
	[SerializeField] KeyCode right;

	public bool move;
	public bool moveUp;
	public bool moveDown;
	public bool moveRight;
	public bool moveLeft;

	public void ProcessInput()
	{
		move = false;
		moveUp = false;
		moveDown = false;
		moveRight = false;
		moveLeft = false;
		if (Input.GetKey (up)) {
			move = true;
			moveUp = true;
		}
	}
}