using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSofaClick : MonoBehaviour {

//    Transform m_prefab;

    public void OnSofaClick()
    {
        //Transform gameObject = Instantiate(m_prefab, new Vector3 (0, 0, 0), Quaternion.identity) as Transform;
        //gameObject.parent = transform;
        GameObject instance = Instantiate(Resources.Load("SofaFab", typeof(GameObject))) as GameObject;
        instance.transform.parent = GameObject.Find("Ground Plane Stage").transform;
    }
}
