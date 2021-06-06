using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class UserInteractionPlane : MonoBehaviour
{

    private ARPlaneManager planes;
    private ARRaycastManager rayMan;
    private Beans bean;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    public Camera arCamera;
    public GameObject searching;
    public GameObject select;
    public GameObject start_b;

    public GameObject boundary;

    public static ARPlane s_plane = null;
    static bool found = false;
     

    void Start()
    {
        bean = GetComponent<Beans>();
        planes = GetComponent<ARPlaneManager>();
        rayMan = GetComponent<ARRaycastManager>();

        planes.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (planes.trackables.count > 0 && !found)
        {
            searching.SetActive(false);
            select.SetActive(true);
        }

        if (Input.touchCount > 0 && !found)
        {
            if (rayMan.Raycast(Input.GetTouch(0).position, s_Hits))
            {
                // Only returns true if there is at least one hit
            }

            ARRaycastHit hit = s_Hits[0];

            if ((hit.hitType & TrackableType.Planes) != 0)
            {
                s_plane = planes.GetPlane(hit.trackableId);

                found = true;

                foreach (var plane in planes.trackables)
                {
                    if (plane.trackableId == s_plane.trackableId)
                    {
                        Destroy(plane.gameObject);
                    }
                }

                boundary.transform.position = new Vector3(s_plane.transform.position.x, s_plane.transform.position.y - 1, s_plane.transform.position.z);

                boundary.SetActive(true);

                planes.enabled = false;
                select.SetActive(false);
                bean.make_beans(s_plane);
                start_b.SetActive(true);
            }  
        }
    }
}

