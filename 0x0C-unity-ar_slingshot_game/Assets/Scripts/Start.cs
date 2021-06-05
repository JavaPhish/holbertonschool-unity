using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{

    public GameObject spawner;

    public void enableProjectileSpawner()
    {
        spawner.SetActive(true);
    }

    public void hideStartButton()
    {
        gameObject.SetActive(false);
    }

}
