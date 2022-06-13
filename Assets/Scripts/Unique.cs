using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unique : MonoBehaviour
{   
    [SerializeField] string tagName;

    private void Awake() {
        // Find objects with the same tag
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tagName);
        // If there are more than one object with the same tag, destroy the current object
        if (objects.Length > 1)  Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
}
