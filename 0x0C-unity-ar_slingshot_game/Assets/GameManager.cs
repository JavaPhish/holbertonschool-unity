using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    // Game over related stuff
    public GameObject gameOver;
    public GameObject gamePlay;
    public Text e_score;

    // Leaderboard
    public Text first;
    public Text second;
    public Text third;


    // Score related stuff
    public Text score_t;
    private int score;

    // Ammo related stuff
    public Text ammo_t;
    public int ammo = 7;

    // Managers
    public GameObject projectileManager;
    public Beans targetManager;

    // ARPlane for restart persisting
    public ARPlane arp;

    // Score buffers
    private int[] scores = new int[4];

    public void PlayAgain()
    {
        // resets ammo, targets and score
        score = 0;
        ammo = 7;

        score_t.text = "Score: " + score;

        ammo_t.text = "Ammo: " + ammo;

        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Bean");

        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }

        targetManager.make_beans(arp);
    }

    public void Restart()
    {
        SceneManager.LoadScene("ARSlingshotGame");
    }

    public void Exit()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        getScores();
        score = 0;
        score_t.text = "Score: " + score;

        ammo_t.text = "Ammo: " + ammo;
    }

    public void givePoints(int value)
    {
        score = score + value;

        score_t.text = "Score: " + score;
    }

    void Update()
    {
        if (score == 50)
            endGame();
    }

    public void useAmmo()
    {
        ammo = ammo - 1;

        ammo_t.text = "Ammo: " + ammo;

        if (ammo <= 0 || score == 50)
        {
            endGame();
        }
    }

    public void endGame()
    {
        if (score == 50 && ammo > 0)
        {
            while (ammo > 0)
            {
                score = score + 5;
                ammo = ammo - 1;
            }
        }

        e_score.text = "Your score: " + score;
        projectileManager.SetActive(false);


        gamePlay.SetActive(false);
        gameOver.SetActive(true);
        setScore(score);
        getScores();        
    }

    void setScore(int new_score)
    {
        scores[3] = new_score;
        Array.Sort(scores);
        Array.Reverse(scores);

        PlayerPrefs.SetInt("1", scores[0]);
        PlayerPrefs.SetInt("2", scores[1]);
        PlayerPrefs.SetInt("3", scores[2]);

        PlayerPrefs.Save();
    }

    void getScores()
    {
        scores[0] = PlayerPrefs.GetInt("1", 0);
        scores[1] = PlayerPrefs.GetInt("2", 0);
        scores[2] = PlayerPrefs.GetInt("3", 0);
        scores[3] = 0;

        Array.Sort(scores);
        Array.Reverse(scores);

        first.text = "1st - " + scores[0];
        second.text = "2nd - " + scores[1];
        third.text = "3rd - " + scores[2];
    }
}
