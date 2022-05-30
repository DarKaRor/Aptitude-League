using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Collectables
{
    Trash,
    Speed,
    Magnet,
    Collision,
    None
}

public class TrashCleaner : MonoBehaviour
{
    public static TrashCleaner instance;

    public Collectables[] powerUps = new Collectables[]
    {
        Collectables.Speed,
        Collectables.Magnet,
        Collectables.Collision
    };

    Sprite[] collectableSprites;


    private void Awake() => instance = instance ? instance : this;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
