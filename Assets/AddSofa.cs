using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSofa : MonoBehaviour {

	public void onSofaClick()
    {
        GameObject gameObject = GameObject.Find("Ground Plane Stage");
        Transform parent = gameObject.transform;
        parent.GetChild(0).Rotate(0, 180, 0);
        parent.GetChild(0).localScale.Set((float).001, (float).001, (float).001);

    }
}
