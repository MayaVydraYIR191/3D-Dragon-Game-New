using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomCamera : MonoBehaviour
{
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel")>0)
        {
            GetComponent<Camera>().fieldOfView--;
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y - .6f, transform.position.z + .2f);
            transform.Rotate(-2, 0, 0);
        }
        if(Input.GetAxis("Mouse ScrollWheel")<0)
        {
            GetComponent<Camera>().fieldOfView++;
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + .6f, transform.position.z - .2f);
            transform.Rotate(2, 0, 0);
        }
    }
}
