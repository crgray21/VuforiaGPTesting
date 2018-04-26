using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTable : MonoBehaviour
{
    // Use this for initialization
    public void onTableClick()
    {

        GameObject instance = Instantiate(Resources.Load("Table", typeof(GameObject))) as GameObject;
        instance.transform.parent = GameObject.Find("Ground Plane Stage").transform;
    }
}
