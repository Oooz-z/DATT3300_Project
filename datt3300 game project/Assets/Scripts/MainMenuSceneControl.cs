using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneControl : MonoBehaviour
{
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameManager gameManager;


    IEnumerator FadeOut()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        gameManager.LoadLevel("OpeningScene");

    }

    public void StartGame()
    {
        StartCoroutine(FadeOut());
    }
}
