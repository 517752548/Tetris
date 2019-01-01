using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    
    public void playAgain() {
        SceneManager.LoadScene("Game");

    }

    public void exit() {
        SceneManager.LoadScene("Welcome");
    }

    public void about() {
        SceneManager.LoadScene("About");
    }
}
