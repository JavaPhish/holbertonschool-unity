using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ProjectileBehavior : MonoBehaviour
{

    private Vector2 drag_start;
    private Vector2 drag_end;
    private Vector2 force;

    public float multiplier = .5f;

    private Transform parnt;
    private Rigidbody rb;

    private ProjectilePrediction traj;
    private LineRenderer line;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        parnt = gameObject.transform.parent;
        traj = GetComponent<ProjectilePrediction>();
        line = GetComponent<LineRenderer>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bean")
        {
            gm.givePoints(10);
        }

        gameObject.transform.SetParent(parnt, false);
        gameObject.transform.localPosition = Vector3.zero;
        rb.isKinematic = true;
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
                    line.enabled = true;
                break;

                case TouchPhase.Moved:

                    drag_end = new Vector2(touch.position.x, touch.position.y);
                    force = drag_end - drag_start;

                    traj.PredictTrajectory(gameObject, new Vector3(-force.x, -force.y, -force.y) * multiplier);
                break;

                case TouchPhase.Ended:
                    drag_end = new Vector2(touch.position.x, touch.position.y);

                    gameObject.transform.parent = null;
                    rb.isKinematic = false;
                    rb.AddForce(new Vector3(-force.x, -force.y, -force.y) * multiplier);
                    line.enabled = false;
                    gm.useAmmo();


                break;
            }
        }
    }
}
