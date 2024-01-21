using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public TextMeshProUGUI recordText;


    void Start()
    {
        recordText.text = "Best time survived: " + PlayerPrefs.GetInt("Record").ToString() + "sec";
    }

    

    public void StartNewRound()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }




    public void Author()
    {
        Application.OpenURL("https://www.instagram.com/arsenii_zakharenko/");
    }
}
