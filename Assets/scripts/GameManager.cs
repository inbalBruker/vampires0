using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class GameManager  : MonoBehaviour
	{
		[SerializeField] Npc man1;
		[SerializeField] NpcRefLeft man1left;
		[SerializeField] NpcRefRight man1right;
		[SerializeField] Npc man2;
		[SerializeField] NpcRefLeft man2left;
		[SerializeField] NpcRefRight man2right;
		[SerializeField] Npc man3;
		[SerializeField] NpcRefLeft man3left;
		[SerializeField] NpcRefRight man3right;
		[SerializeField] Npc man4;
		[SerializeField] NpcRefLeft man4left;
		[SerializeField] NpcRefRight man4right;
		[SerializeField] Npc man5;
		[SerializeField] NpcRefLeft man5left;
		[SerializeField] NpcRefRight man5right;
		[SerializeField] Npc man6;
		[SerializeField] NpcRefLeft man6left;
		[SerializeField] NpcRefRight man6right;
		[SerializeField] Npc man7;
		[SerializeField] NpcRefLeft man7left;
		[SerializeField] NpcRefRight man7right;
		[SerializeField] Npc man8;
		[SerializeField] NpcRefLeft man8left;
		[SerializeField] NpcRefRight man8right;
		[SerializeField] Npc woman1;
		[SerializeField] NpcRefLeft woman1left;
		[SerializeField] NpcRefRight woman1right;
		[SerializeField] Npc woman2;
		[SerializeField] NpcRefLeft woman2left;
		[SerializeField] NpcRefRight woman2right;
		[SerializeField] Npc woman3;
		[SerializeField] NpcRefLeft woman3left;
		[SerializeField] NpcRefRight woman3right;
		[SerializeField] Npc woman4;
		[SerializeField] NpcRefLeft woman4left;
		[SerializeField] NpcRefRight woman4right;
		[SerializeField] Npc woman5;
		[SerializeField] NpcRefLeft woman5left;
		[SerializeField] NpcRefRight woman5right;
		[SerializeField] Npc woman6;
		[SerializeField] NpcRefLeft woman6left;
		[SerializeField] NpcRefRight woman6right;
		[SerializeField] Npc woman7;
		[SerializeField] NpcRefLeft woman7left;
		[SerializeField] NpcRefRight woman7right;
		[SerializeField] Npc woman8;
		[SerializeField] NpcRefLeft woman8left;
		[SerializeField] NpcRefRight woman8right;

		[SerializeField] RuntimeAnimatorController man1anim;
		[SerializeField] RuntimeAnimatorController man2anim;
		[SerializeField] RuntimeAnimatorController man3anim;
		[SerializeField] RuntimeAnimatorController man4anim;
		[SerializeField] RuntimeAnimatorController man5anim;
		[SerializeField] RuntimeAnimatorController man6anim;
		[SerializeField] RuntimeAnimatorController man7anim;
		[SerializeField] RuntimeAnimatorController man8anim;
		[SerializeField] RuntimeAnimatorController woman1anim;
		[SerializeField] RuntimeAnimatorController woman2anim;
		[SerializeField] RuntimeAnimatorController woman3anim;
		[SerializeField] RuntimeAnimatorController woman4anim;
		[SerializeField] RuntimeAnimatorController woman5anim;
		[SerializeField] RuntimeAnimatorController woman6anim;
		[SerializeField] RuntimeAnimatorController woman7anim;
		[SerializeField] RuntimeAnimatorController woman8anim;



		// Use this for initialization
		void Start () {
			


			int player1 = Random.Range(0, 16);
			int player2 = Random.Range(0, 16);
			print (player1 + " " + player2);
			while (player1 == player2) {
				player2 = Random.Range(0, 16);
			}
			if (player1 == 0 || player2 == 0) {
				Destroy (man1left.gameObject);
				Destroy (man1right.gameObject);
				if (player1 == 0) {
					man1.transform.tag = "player1";
					man1.GetComponent<Npc>().enabled=false;
					man1.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 0) {
					man1.transform.tag = "player2";
					man1.GetComponent<Npc>().enabled=false;
					man1.GetComponent<player>().enabled=false;
				}
				Animator animator = man1.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = man1anim;
			}
			if (player1 == 1 || player2 == 1) {
				Destroy (man2left.gameObject);
				Destroy (man2right.gameObject);
				if (player1 == 1) {
					man2.transform.tag = "player1";
					man2.GetComponent<Npc>().enabled=false;
					man2.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 1) {
					man2.transform.tag = "player2";

					man2.GetComponent<Npc>().enabled=false;
					man2.GetComponent<player>().enabled=false;
				}
				Animator animator = man2.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = man2anim;
			}
			if (player1 == 2 || player2 == 2) {
				Destroy (man3left.gameObject);
				Destroy (man3right.gameObject);
				if (player1 == 2) {
					man3.transform.tag = "player1";
					man3.GetComponent<Npc>().enabled=false;
					man3.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 2) {
					man3.transform.tag = "player2";

					man3.GetComponent<Npc>().enabled=false;
					man3.GetComponent<player>().enabled=false;
				}
				Animator animator = man3.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = man3anim;//Resources.Load("man3conPlayer2") as RuntimeAnimatorController;
			}
			if (player1 == 3 || player2 == 3) {
				Destroy (man4left.gameObject);
				Destroy (man4right.gameObject);
				if (player1 == 3) {
					man4.transform.tag = "player1";
					man4.GetComponent<Npc>().enabled=false;
					man4.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 3) {
					man4.transform.tag = "player2";

					man4.GetComponent<Npc>().enabled=false;
					man4.GetComponent<player>().enabled=false;
				}
				Animator animator = man4.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = man4anim;
			}
			if (player1 == 4 || player2 == 4) {
				Destroy (man5left.gameObject);
				Destroy (man5right.gameObject);
				if (player1 == 4) {
					man5.transform.tag = "player1";
					man5.GetComponent<Npc>().enabled=false;
					man5.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 4) {
					man5.transform.tag = "player2";

					man5.GetComponent<Npc>().enabled=false;
					man5.GetComponent<player>().enabled=false;
				}
				Animator animator = man5.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = man5anim;
			}
			if (player1 == 5 || player2 == 5) {
				Destroy (man6left.gameObject);
				Destroy (man6right.gameObject);
				if (player1 == 5) {
					man6.transform.tag = "player1";
					man6.GetComponent<Npc>().enabled=false;
					man6.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 5) {
					man6.transform.tag = "player2";

					man6.GetComponent<Npc>().enabled=false;
					man6.GetComponent<player>().enabled=false;
				}
				Animator animator = man6.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = man6anim;
			}
			if (player1 == 6 || player2 == 6) {
				Destroy (man7left.gameObject);
				Destroy (man7right.gameObject);
				if (player1 == 6) {
					man7.transform.tag = "player1";
					man7.GetComponent<Npc>().enabled=false;
					man7.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 6) {
					man7.transform.tag = "player2";

					man7.GetComponent<Npc>().enabled=false;
					man7.GetComponent<player>().enabled=false;
				}
				Animator animator = man7.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = man7anim;
			}
			if (player1 == 7 || player2 == 7) {
				Destroy (man8left.gameObject);
				Destroy (man8right.gameObject);
				if (player1 == 7) {
					man8.transform.tag = "player1";
					man8.GetComponent<Npc>().enabled=false;
					man8.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 7) {
					man8.transform.tag = "player2";
					man8.GetComponent<Npc>().enabled=false;
					man8.GetComponent<player>().enabled=false;
				}
				Animator animator = man8.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = man8anim;
			}
			if (player1 == 8 || player2 == 8) {
				Destroy (woman1left.gameObject);
				Destroy (woman1right.gameObject);
				if (player1 == 8) {
					woman1.transform.tag = "player1";
					woman1.GetComponent<Npc>().enabled=false;
					woman1.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 8) {
					woman1.transform.tag = "player2";
					woman1.GetComponent<Npc>().enabled=false;
					woman1.GetComponent<player>().enabled=false;
				}
				Animator animator = woman1.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = woman1anim;
			}
			if (player1 == 9 || player2 == 9) {
				Destroy (woman2left.gameObject);
				Destroy (woman2right.gameObject);
				if (player1 == 9) {
					woman2.transform.tag = "player1";
					woman2.GetComponent<Npc>().enabled=false;
					woman2.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 9) {
					woman2.transform.tag = "player2";
					woman2.GetComponent<Npc>().enabled=false;
					woman2.GetComponent<player>().enabled=false;
				}
				Animator animator = woman2.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = woman2anim;
			}
			if (player1 == 10 || player2 == 10) {
				Destroy (woman3left.gameObject);
				Destroy (woman3right.gameObject);
				if (player1 == 10) {
					woman3.transform.tag = "player1";

					woman3.GetComponent<Npc>().enabled=false;
					woman3.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 10) {
					woman3.transform.tag = "player2";
					woman3.GetComponent<Npc>().enabled=false;
					woman3.GetComponent<player>().enabled=false;
				}
				Animator animator = woman3.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = woman3anim;
			}
			if (player1 == 11 || player2 == 11) {
				Destroy (woman4left.gameObject);
				Destroy (woman4right.gameObject);
				if (player1 == 11) {
					woman4.transform.tag = "player1";

					woman4.GetComponent<Npc>().enabled=false;
					woman4.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 11) {
					woman4.transform.tag = "player2";
					woman4.GetComponent<Npc>().enabled=false;
					woman4.GetComponent<player>().enabled=false;
				}
				Animator animator = woman4.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = woman4anim;
			}
			if (player1 == 12 || player2 == 12) {
				Destroy (woman5left.gameObject);
				Destroy (woman5right.gameObject);
				if (player1 == 12) {
					woman5.transform.tag = "player1";

					woman5.GetComponent<Npc>().enabled=false;
					woman5.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 12) {
					woman5.transform.tag = "player2";
					woman5.GetComponent<Npc>().enabled=false;
					woman5.GetComponent<player>().enabled=false;
				}
				Animator animator = woman5.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = woman5anim;
			}
			if (player1 == 13 || player2 == 13) {
				Destroy (woman6left.gameObject);
				Destroy (woman6right.gameObject);
				if (player1 == 13) {
					woman6.transform.tag = "player1";

					woman6.GetComponent<Npc>().enabled=false;
					woman6.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 13) {
					woman6.transform.tag = "player2";

					woman6.GetComponent<Npc>().enabled=false;
					woman6.GetComponent<player>().enabled=false;
				}
				Animator animator = woman6.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = woman6anim;
			}
			if (player1 == 14 || player2 == 14) {
				Destroy (woman7left.gameObject);
				Destroy (woman7right.gameObject);
				if (player1 == 14) {
					woman7.transform.tag = "player1";

					woman7.GetComponent<Npc>().enabled=false;
					woman7.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 14) {
					woman7.transform.tag = "player2";

					woman7.GetComponent<Npc>().enabled=false;
					woman7.GetComponent<player>().enabled=false;
				}
				Animator animator = woman7.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = woman7anim;
			}
			if (player1 == 15 || player2 == 15) {
				Destroy (woman8left.gameObject);
				Destroy (woman8right.gameObject);
				if (player1 == 15) {
					woman8.transform.tag = "player1";

					woman8.GetComponent<Npc>().enabled=false;
					woman8.GetComponent<playerAswd>().enabled=false;
				}
				if (player2 == 15) {
					woman8.transform.tag = "player2";

					woman8.GetComponent<Npc>().enabled=false;
					woman8.GetComponent<player>().enabled=false;
				}
				Animator animator = woman8.gameObject.GetComponent<Animator>();
				animator.runtimeAnimatorController = woman8anim;
			}

			if (player1 != 0 && player2 != 0) {
				man1.GetComponent<playerAswd>().enabled=false;
				man1.GetComponent<player>().enabled=false;
			}
			if (player1 != 1 && player2 != 1) {
				man2.GetComponent<playerAswd>().enabled=false;
				man2.GetComponent<player>().enabled=false;
			}
			if (player1 != 2 && player2 != 2) {
				man3.GetComponent<playerAswd>().enabled=false;
				man3.GetComponent<player>().enabled=false;
			}
			if (player1 != 3 && player2 != 3) {
				man4.GetComponent<playerAswd>().enabled=false;
				man4.GetComponent<player>().enabled=false;
			}
			if (player1 != 4 && player2 != 4) {
				man5.GetComponent<playerAswd>().enabled=false;
				man5.GetComponent<player>().enabled=false;
			}
			if (player1 != 5 && player2 != 5) {
				man6.GetComponent<playerAswd>().enabled=false;
				man6.GetComponent<player>().enabled=false;
			}
			if (player1 != 6 && player2 != 6) {
				man7.GetComponent<playerAswd>().enabled=false;
				man7.GetComponent<player>().enabled=false;
			}
			if (player1 != 7 && player2 != 7) {
				man8.GetComponent<playerAswd>().enabled=false;
				man8.GetComponent<player>().enabled=false;
			}
			if (player1 != 8 && player2 != 8) {
				woman1.GetComponent<playerAswd>().enabled=false;
				woman1.GetComponent<player>().enabled=false;
			}
			if (player1 != 9 && player2 != 9) {
				woman2.GetComponent<playerAswd>().enabled=false;
				woman2.GetComponent<player>().enabled=false;
			}
			if (player1 != 10 && player2 != 1) {
				woman3.GetComponent<playerAswd>().enabled=false;
				woman3.GetComponent<player>().enabled=false;
			}
			if (player1 != 11 && player2 != 11) {
				woman4.GetComponent<playerAswd>().enabled=false;
				woman4.GetComponent<player>().enabled=false;
			}
			if (player1 != 12 && player2 != 12) {
				woman5.GetComponent<playerAswd>().enabled=false;
				woman5.GetComponent<player>().enabled=false;
			}
			if (player1 != 13 && player2 != 13) {
				woman6.GetComponent<playerAswd>().enabled=false;
				woman6.GetComponent<player>().enabled=false;
			}
			if (player1 != 14 && player2 != 14) {
				woman7.GetComponent<playerAswd>().enabled=false;
				woman7.GetComponent<player>().enabled=false;
			}
			if (player1 != 15 && player2 != 15) {
				woman8.GetComponent<playerAswd>().enabled=false;
				woman8.GetComponent<player>().enabled=false;
			}
	

		}

		// Update is called once per frame
		void Update () {

		}
	}
}

