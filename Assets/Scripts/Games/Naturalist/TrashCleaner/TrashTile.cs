using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrashTile : MonoBehaviour
{
    public Collectables type = Collectables.None;
    void Start()
    {
        if (true)
        {
            type = Collectables.Trash;
            if (Methods.Roll(10)) GetPowerUp();

            GameObject collectableObj = Instantiate(TrashCleaner.instance.collectablePrefab, transform);
            collectableObj.transform.localPosition = Vector3.zero;
            Collectable collectable = collectableObj.GetComponent<Collectable>();
            collectable.type = type;
        }
    }

    void GetPowerUp()
    {
        if (Methods.Roll(10))
        {
            type = Collectables.Collision;
            return;
        }
        if (Methods.Roll(40))
        {
            type = Collectables.Magnet;
            return;
        }
        type = Collectables.Speed;
    }
}
