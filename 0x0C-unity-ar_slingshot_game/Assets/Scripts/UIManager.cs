using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text score_t;
    public Text endScore;
    public Text ammo_t;
    public Canvas game;
    public Canvas endGame;

    public int score;
    public int ammo = 5;


    void Start()
    {
        ammo_t.text = "Ammo: 5";
    }

    public void setAmmo(int u_ammo)
    {
        ammo = u_ammo;

        ammo_t.text = "Ammo: " + u_ammo;

        if (ammo == 0)
            gameOver();
    }

    public void setScore(int u_score)
    {
        score = u_score;
        endScore.text = "Score: " + u_score;
        score_t.text = "Score: " + u_score;
    }

    public void gameOver()
    {
        game.enabled = false;
        endGame.enabled = true;
    }
}
