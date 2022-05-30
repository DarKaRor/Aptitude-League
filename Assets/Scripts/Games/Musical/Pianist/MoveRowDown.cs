using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRowDown : MonoBehaviour
{
    bool stop = false;
    void Update()
    {
        if (stop) return;
        transform.Translate(Vector2.down * Pianist.instance.scrollSpeed * Time.deltaTime);
    }
}
