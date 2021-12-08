using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    
    public void playGame()
    {
        SceneManager.LoadScene("Isa");
    }


    public void exitGame()
    {
        Application.Quit();
    }
}
