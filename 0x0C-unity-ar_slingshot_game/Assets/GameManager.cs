using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // Score related stuff
    public Text score_t;
    private int score;

    // Ammo related stuff
    public Text ammo_t;
    public int ammo = 5;

    public GameObject projectileManager;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        score_t.text = "Score: " + score;

        ammo_t.text = "Ammo: " + ammo;
    }

    public void givePoints(int value)
    {
        score = score + value;

        score_t.text = "Score: " + score;
    }

    public void useAmmo()
    {
        ammo = ammo - 1;

        ammo_t.text = "Ammo: " + ammo;

        if (ammo <= 0)
        {
            projectileManager.SetActive(false);
            // End game
        }
    }
}
