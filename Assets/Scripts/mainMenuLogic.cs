using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuLogic : MonoBehaviour
{
    public static mainMenuLogic Instance;
    public GameObject mainMenuPanel;
    public GameObject rulesPanel;
    public GameObject ChooseNaturalDisasterPanel;
    public GameObject InputNamePanel;

    [SerializeField] public string userName;

    private void Awake()
    {
        if (mainMenuLogic.Instance == null)
        {
            mainMenuLogic.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        mainMenuPanel.SetActive(true);
        rulesPanel.SetActive(false);
        ChooseNaturalDisasterPanel.SetActive(false);
        InputNamePanel.SetActive(false);
    }

    private void Update()
    {
        LoadTest();
    }

    public void StartGameClick()
    {
        mainMenuPanel.SetActive(false);
        rulesPanel.SetActive(false);
        ChooseNaturalDisasterPanel.SetActive(false);
        InputNamePanel.SetActive(true);
    }

    public void LoadSimulationEarthquake()
    {
        SceneManager.LoadScene("Room_v2");
    }

    public void LoadTest()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Room_v2");
        }
    }

    public void RulesClicked()
    {
        mainMenuPanel.SetActive(false);
        rulesPanel.SetActive(true);
        ChooseNaturalDisasterPanel.SetActive(false);
        InputNamePanel.SetActive(false);
    }

    public void SendNameClicked()
    {
        mainMenuPanel.SetActive(false);
        rulesPanel.SetActive(false);
        ChooseNaturalDisasterPanel.SetActive(true);
        InputNamePanel.SetActive(false);
    }

    public void SaveName(string name)
    {
        userName = name;
        Debug.Log(userName);
    }

    public void ExitClicked()
    {
        Application.Quit();
    }

    public void BackClicked()
    {
        mainMenuPanel.SetActive(true);
        rulesPanel.SetActive(false);
        ChooseNaturalDisasterPanel.SetActive(false);
        InputNamePanel.SetActive(false);
    }


    //public void NoClicked()
    //{
        //mainMenuPanel.SetActive(true);
        //aboutPanel.SetActive(false);
        //exitPanel.SetActive(false);
    //}

    //public void YesGameClick()
    //{
    //    Application.Quit();
    //}

}
