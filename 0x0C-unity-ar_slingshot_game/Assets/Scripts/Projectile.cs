using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{

    private Vector2 drag_start;
    private Vector2 drag_end;
    private Vector2 force;

    public float dampener = .005f;

    private Rigidbody r_proj;

    //public Text debug;

    void Start()
    {
        r_proj = GetComponent<Rigidbody>();
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
                    break;

                case TouchPhase.Ended:

                    drag_end = new Vector2(touch.position.x, touch.position.y);;
                    force = drag_end - drag_start;

                    //debug.text = (y_start - y_end).ToString();

                    r_proj.constraints = RigidbodyConstraints.None;
                    r_proj.AddForce(new Vector3(-force.x, -force.y, -force.y) * dampener);
                    r_proj.transform.parent = null;

                    break;
            }


        }
 
    }
}
