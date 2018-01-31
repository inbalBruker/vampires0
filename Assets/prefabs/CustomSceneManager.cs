using UnityEngine;
using UnityEngine.SceneManagement;

namespace AssemblyCSharp
{
	public class CustomSceneManager : MonoBehaviour
	{
		
		static string startSecene = "mainMenu";
		static string gameScene = "game";
		static string endScene = "Quit";



		private static bool pressedSpace;
		void start (){
			

		}

		void Update()
		{
			
			if ((Input.GetKeyDown(KeyCode.Space) && !pressedSpace) || Input.GetMouseButtonDown(0))
			{
				print (Input.GetKeyDown (KeyCode.Space));
				print (" " + !pressedSpace);
				pressedSpace = true;
				CustomSceneManager.MoveToScene(gameScene);
			}
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				MoveToScene("Quit");
			}


		}
		 static void MoveToScene(string sceneName)
		{
			print (sceneName);
			if (sceneName.Equals("Quit"))
			{
				Application.Quit();
			}
			else
			{
				SceneManager.LoadScene(sceneName);
			}
			// if the game has ended we will start listening to our space key again
			if (sceneName == endScene)
			{
				pressedSpace = false;
			}
		}
	}
}