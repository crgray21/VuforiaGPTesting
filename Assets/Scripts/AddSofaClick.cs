using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSofaClick : MonoBehaviour {

    GameObject instance;
    GameObject groundPlane;

    public void OnSofaClick()
    {
        instance = Instantiate(Resources.Load("SofaFab", typeof(GameObject))) as GameObject;
        groundPlane = GameObject.Find("Ground Plane Stage");
        instance.transform.parent = groundPlane.transform;
    }
}
