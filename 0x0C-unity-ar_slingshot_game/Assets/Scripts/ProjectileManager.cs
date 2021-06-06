using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject ammo;
    public int ammo_count = 5;


    private GameObject ball;

    void Start()
    {

    }

    public void setAmmo(int nammo)
    {
        ammo_count = nammo;

        if (ammo_count <= 0)
        {

        }
    }
}

