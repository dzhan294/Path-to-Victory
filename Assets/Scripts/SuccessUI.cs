using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SuccessUI : MonoBehaviour
{
    private Button btn_continue;
    private Button btn_playAgain;
    private Button btn_main;
    int sceneIndex = 0;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        btn_continue = transform.Find("btn_continue").GetComponent<Button>();
        btn_continue.onClick.AddListener(OnBtnContinueClick);

        btn_playAgain = transform.Find("btn_playAgain").GetComponent<Button>();
        btn_playAgain.onClick.AddListener(OnBtnPlayAgainClick);

        btn_main = transform.Find("btn_main").GetComponent<Button>();
        btn_main.onClick.AddListener(OnBtnMainClick);
    }

    private void OnBtnContinueClick()
    {
        if (sceneIndex<6)
        {
            SceneManager.LoadSceneAsync(sceneIndex + 1);
        }  
    }

    private void OnBtnPlayAgainClick()
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    private void OnBtnMainClick()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
