using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scenes : MonoBehaviour {

    public void PlayGame()
    {

        Application.LoadLevel("Main");

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
