using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class Beans : MonoBehaviour
{

    public int bean_count = 5;
    public GameObject bean;

    private MeshCollider m_plane;

    public void make_beans(ARPlane plane)
    {
        while (bean_count > 0)
        {
            m_plane = plane.GetComponent<MeshCollider>();

            GameObject n_bean = Instantiate(bean, m_plane.bounds.center, Quaternion.identity);

            n_bean.transform.position = new Vector3(Random.Range(m_plane.bounds.min.x, m_plane.bounds.extents.x),
                                                    m_plane.bounds.center.y,
                                                    Random.Range(m_plane.bounds.min.z, m_plane.bounds.extents.z));

            bean_count--;         
        }

    }
}
