using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class UserInteractionPlane : MonoBehaviour
{

    private ARPlaneManager planes;

    public GameObject searching;
    public GameObject select;

    void Start()
    {
        planes = GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (planes.trackables.count > 0)
        {
            searching.SetActive(false);
            select.SetActive(true);
        }
    }
}
