using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSofaClick : MonoBehaviour {

    public void OnSofaClick()
    {
        GameObject gameObject = GameObject.Find("Ground Plane Stage");
        Transform parent = gameObject.transform;
 //       parent.GetChild(0).gameObject.AddComponent<String>() as String;


    }
}
