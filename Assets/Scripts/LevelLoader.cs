using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    public bool allowTransition { get; set; } = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (allowTransition)
        {
            CharacterControl player = col.GetComponent<CharacterControl>();
            if (player != null)
                LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        if ((SceneManager.GetActiveScene().buildIndex + 1) != 4)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else
            StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
