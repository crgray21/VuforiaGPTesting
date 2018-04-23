using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBookShelf : MonoBehaviour
{
    // Use this for initialization
    public void onBookShelfClick()
    {
        GameObject instance = Instantiate(Resources.Load("BookCaseFab", typeof(GameObject))) as GameObject;
        instance.transform.parent = GameObject.Find("Ground Plane Stage").transform;
    }
}
