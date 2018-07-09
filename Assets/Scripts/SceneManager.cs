using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManager: MonoBehaviour {

	public void PlayGame(){

        Application.LoadLevel("Main"); 

	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void MainMenu(){
		Application.LoadLevel ("Menu");
	}

	public void PLOT(){
		Application.LoadLevel ("Plot");
	}

	public void Credits(){
		Application.LoadLevel ("Credits");
	}

     
} 