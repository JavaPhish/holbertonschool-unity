using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bean : MonoBehaviour
{
    
    private int max_speed = 2;
    private int max_distance = 1;
    private char axis;
    private float speed;
    private float distance;

    void Start()
    {
        // Randomly pick which axis to move on
        if (Random.Range(0, 2) > 1)
            axis = 'x';
        else
            axis = 'z';

        // Randomly decide how quickly it moves
        speed = Random.Range(0.5f, max_speed);

        // Randomly decide how far it will move
        distance = Random.Range(0f, max_distance);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime ,0 , 0);
        transform.Rotate(speed * Time.deltaTime, 0, 0);
    }
}
