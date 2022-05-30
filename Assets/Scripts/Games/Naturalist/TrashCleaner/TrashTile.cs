using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTile : MonoBehaviour
{
    public Collectables type = Collectables.None;
    public bool isPowerUp = false;
    void Start()
    {
        if (Methods.FlipCoin())
        {
            type = Collectables.Trash;
            if (Methods.Roll(10)) GetPowerUp();
        }
    }

    void Update()
    {

    }

    void GetPowerUp()
    {

        isPowerUp = true;
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
