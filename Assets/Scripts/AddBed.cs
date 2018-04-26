using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBed : MonoBehaviour {

    GameObject instance;
    GameObject groundPlane;

    public void OnBedClick()
    {
        instance = Instantiate(Resources.Load("Bed", typeof(GameObject))) as GameObject;
        groundPlane = GameObject.Find("Ground Plane Stage");
        instance.transform.parent = groundPlane.transform;
    }
}
