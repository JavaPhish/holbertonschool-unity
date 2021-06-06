using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Projectile : MonoBehaviour
{

    private Vector2 drag_start;
    private Vector2 drag_end;
    private Vector2 force;

    public float dampener = .5f;
    public GameObject projman;

    private Rigidbody r_proj;
    //private ProjectilePrediction prediciton_line;
    //private LineRenderer line;
    private float destroy_height = -10;
    //public Text debug;

    void Start()
    {
        r_proj = GetComponent<Rigidbody>();
        //prediciton_line = GetComponent<ProjectilePrediction>();
        //line = GetComponent<LineRenderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        resetProjectile(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    drag_start = new Vector2(touch.position.x, touch.position.y);
                    //line.enabled = true;
                    break;
/*
                case TouchPhase.Moved:

                    drag_end = new Vector2(touch.position.x, touch.position.y);
                    force = drag_end - drag_start;

                    prediciton_line.PredictTrajectory(gameObject, new Vector3(-force.x, -force.y, -force.y), dampener);
                    break;
*/
                case TouchPhase.Ended:

                    drag_end = new Vector2(touch.position.x, touch.position.y);
                    force = drag_end - drag_start;

                    r_proj.constraints = RigidbodyConstraints.None;
                    r_proj.transform.parent = null;
                    r_proj.AddForce(new Vector3(-force.x, -force.y, -force.y) * dampener);
                    resetProjectile(5f);
                    //line.enabled = false;
                    break;
            }
        }
    }

    void resetProjectile(float time)
    {
        Wait(time);
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        r_proj.transform.parent = projman.transform;
        r_proj.constraints = RigidbodyConstraints.FreezeAll;
        r_proj.transform.position = projman.transform.position;
        r_proj.transform.rotation = projman.transform.rotation;
        
    }

}
