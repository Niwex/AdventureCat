using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSplashScreen : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    void Start()
    {
        LoadNextLevel();
    }
    public void LoadNextLevel()
    {
            StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
