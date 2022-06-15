using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRowDown : MonoBehaviour
{
    void Update()
    {
        if (Pianist.instance.stop) return;
        transform.Translate(Vector2.down * Pianist.instance.scrollSpeed * Time.deltaTime);
    }
}
