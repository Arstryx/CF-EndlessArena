using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameHandler : MonoBehaviour
{


    bool dead = false;
    public GameObject pauseMenu;
    public GameObject deathMenu;
    public TextMeshProUGUI timer, recordText;
    private int timeSurvived = 0;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !dead)
        {
            Pause();
        }

        if (player == null && !dead)
        {
            dead = true;
            GameOver();
        }
    }

    public void Pause()
    {
        if (Time.timeScale == 1f)
        {
            StopAllCoroutines();
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            StartCoroutine(Timer());
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }


    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }


    IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timeSurvived++;
            timer.text = "Survived: " + timeSurvived.ToString();
        }
        
    }


    public void GameOver()
    {
        StopAllCoroutines();
        Debug.Log("Stopped timer");
        deathMenu.SetActive(true);
        int lastRecord = PlayerPrefs.GetInt("Record");
        if (timeSurvived > lastRecord)
        {
            PlayerPrefs.SetInt("Record", timeSurvived);
            recordText.text = "New record: " + timeSurvived + "!";
        }
        else
        {
            recordText.text = "Goog luck next time!";
        }
    }


}
