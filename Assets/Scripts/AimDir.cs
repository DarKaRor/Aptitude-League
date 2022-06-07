using UnityEngine;

public class AimDir : MonoBehaviour
{
    public Vector2 target;
    public Vector2 position;

    void Start()
    {
        
    }

    void Update()
    {
        // Aim at mouse position
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 dir = target - position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }
}
