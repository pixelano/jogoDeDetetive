using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repocisionarLanterna : MonoBehaviour
{
    public Camera cam;
    private void Start()
    {
        if(cam == null)
        {
            cam = Camera.main;
        }
    }
    private void Update()
    {
        transform.rotation = cam.transform.rotation; // Quaternion.LookRotation(cam.ro, Vector3.up)
    }
}
