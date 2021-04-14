using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectedRole : MonoBehaviour
{
    private Button btn_roleArcher;
    private Button btn_roleKnight;
    private Button btn_roleWizard;
    private Button btn_roleGuard;
    private Button btn_roleAssasin;
    private Button btn_roleWarrior;

    public GameObject[] roleGoArray;

    public Text nameText;
    public Text infoText;
    public int roleIndex = 0;

    private Button btnStart;

    void Start()
    {
        btn_roleArcher = transform.Find("RolePanel/role_Archer/headIcon").GetComponent<Button>();
        btn_roleArcher.onClick.AddListener(OnArcherClick);

        btn_roleKnight = transform.Find("RolePanel/role_knight/headIcon").GetComponent<Button>();
        btn_roleKnight.onClick.AddListener(OnKnightClick);

        btn_roleWizard = transform.Find("RolePanel/role_wizard/headIcon").GetComponent<Button>();
        btn_roleWizard.onClick.AddListener(OnWizardClick);

        btn_roleGuard = transform.Find("RolePanel/role_guard/headIcon").GetComponent<Button>();
        btn_roleGuard.onClick.AddListener(OnGuardClick);

        btn_roleAssasin = transform.Find("RolePanel/role_assasin/headIcon").GetComponent<Button>();
        btn_roleAssasin.onClick.AddListener(OnAssasinClick);

        btn_roleWarrior = transform.Find("RolePanel/role_warrior/headIcon").GetComponent<Button>();
        btn_roleWarrior.onClick.AddListener(OnWarriorClick);

        btnStart = transform.Find("btn_Start").GetComponent<Button>();
        btnStart.onClick.AddListener(OnBtnStartClick);

        PlayerPrefs.SetInt("roleIndex", roleIndex);
        PlayerPrefs.Save();
    }

    void Update()
    {
        
    }


    #region Button click event
    private void OnBtnStartClick()
    {
        SceneManager.LoadScene(1);
    }
    public void OnBtnExitClick()
    {
        Application.Quit();
    }

    private void OnArcherClick()
    {
        roleIndex = 0;
        roleGoArray[0].SetActive(true);

        roleGoArray[1].SetActive(false);
        roleGoArray[2].SetActive(false);
        roleGoArray[3].SetActive(false);
        roleGoArray[4].SetActive(false);
        roleGoArray[5].SetActive(false);

        nameText.text = "Archer";
        infoText.text = "This is an archer. Can give the enemy a fatal blow from a distance!";

        PlayerPrefs.SetInt("roleIndex", roleIndex);
        PlayerPrefs.Save();

    }
    private void OnKnightClick()
    {
        roleIndex = 1;
        roleGoArray[1].SetActive(true);

        roleGoArray[0].SetActive(false);
        roleGoArray[2].SetActive(false);
        roleGoArray[3].SetActive(false);
        roleGoArray[4].SetActive(false);
        roleGoArray[5].SetActive(false);

        nameText.text = "Knight";
        infoText.text = "This is a knight. Force again!";

        PlayerPrefs.SetInt("roleIndex", roleIndex);
        PlayerPrefs.Save();
    }
    private void OnWizardClick()
    {
        roleIndex = 2;
        roleGoArray[2].SetActive(true);

        roleGoArray[1].SetActive(false);
        roleGoArray[0].SetActive(false);
        roleGoArray[3].SetActive(false);
        roleGoArray[4].SetActive(false);
        roleGoArray[5].SetActive(false);

        nameText.text = "Wizard";
        infoText.text = "This is a warlock. Master magic!";

        PlayerPrefs.SetInt("roleIndex", roleIndex);
        PlayerPrefs.Save();
    }
    private void OnGuardClick()
    {
        roleIndex = 3;
        roleGoArray[3].SetActive(true);

        roleGoArray[1].SetActive(false);
        roleGoArray[0].SetActive(false);
        roleGoArray[2].SetActive(false);
        roleGoArray[4].SetActive(false);
        roleGoArray[5].SetActive(false);

        nameText.text = "Guard";
        infoText.text = "City guard.";

        PlayerPrefs.SetInt("roleIndex", roleIndex);
        PlayerPrefs.Save();
    }
    private void OnAssasinClick()
    {
        roleIndex = 4;
        roleGoArray[4].SetActive(true);

        roleGoArray[1].SetActive(false);
        roleGoArray[0].SetActive(false);
        roleGoArray[3].SetActive(false);
        roleGoArray[2].SetActive(false);
        roleGoArray[5].SetActive(false);

        nameText.text = "Assasin";
        infoText.text = "assassin. It can attack the enemy quickly.";

        PlayerPrefs.SetInt("roleIndex", roleIndex);
        PlayerPrefs.Save();
    }
    private void OnWarriorClick()
    {
        roleIndex = 5;
        roleGoArray[5].SetActive(true);

        roleGoArray[1].SetActive(false);
        roleGoArray[0].SetActive(false);
        roleGoArray[3].SetActive(false);
        roleGoArray[4].SetActive(false);
        roleGoArray[2].SetActive(false);

        nameText.text = "Warrior";
        infoText.text = "Soldiers. Stab the enemy hard!";

        PlayerPrefs.SetInt("roleIndex", roleIndex);
        PlayerPrefs.Save();
    }


    #endregion

}
