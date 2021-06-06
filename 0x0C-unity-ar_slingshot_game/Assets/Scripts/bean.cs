using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bean : MonoBehaviour
{
    
    private float max_speed = 2f;
    private float max_distance = .3f;
    private float speed;
    private float distance;
    private Vector3 anchor;
    private float currentAngle;

    void Start()
    {
        // Randomly decide how quickly it moves
        speed = Random.Range(0.01f, max_speed);

        // Randomly decide how far it will move
        distance = Random.Range(0.07f, max_distance);

        anchor = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentAngle += speed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Sin(currentAngle) * distance, 0, Mathf.Cos(currentAngle) * distance);
        transform.position = anchor + offset;            
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            GetComponent<AudioSource>().Play(0);
            Destroy(gameObject);
        }
    }
}
