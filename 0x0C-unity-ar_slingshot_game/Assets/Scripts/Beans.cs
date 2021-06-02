using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class Beans : MonoBehaviour
{

    public Text debug;

    public void make_beans(int count, ARPlane plane)
    {
        debug.text = (plane.boundary[0].ToString() + " \n"  + plane.boundary[1].ToString());
    }
}
