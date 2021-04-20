using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            SceneManager.LoadScene(2);
        }   
        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            SceneManager.LoadScene(3);
        }   
        if(Input.GetKeyDown(KeyCode.Keypad3))
        {
            SceneManager.LoadScene(4);
        }   
    }
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
