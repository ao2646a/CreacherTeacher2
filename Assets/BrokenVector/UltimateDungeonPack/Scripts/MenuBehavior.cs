using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame()
    {
        SceneManager.LoadScene("Mage_Room_Demo");
    }


    public void exitGame()
    {
        Application.Quit();
    }
}
