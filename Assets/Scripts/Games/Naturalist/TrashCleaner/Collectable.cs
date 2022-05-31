using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectable : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Collectables type;
    float rotSpeed = 50f;
    public bool isPowerUp = false;
    public bool collected = false;
    public bool targetPlayer = false;
    GameObject player;
    Transform GFX;

    private void Start()
    {

        isPowerUp = type != Collectables.None && type != Collectables.Trash;
        GFX = transform.Find("GFX");
        spriteRenderer = GFX.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = TrashCleaner.instance.GetCollectableSprite(type);

       if(!isPowerUp) TrashCleaner.instance.collectables.Add(this);
    }

    private void Update()
    {
        Rotate();
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        if (!targetPlayer) return;
        if (player == null) player = FindObjectOfType<TCPlayer>().gameObject;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 10f * Time.deltaTime);
    }
    public void Rotate()
    {
        GFX.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        if(type == Collectables.Trash) TrashCleaner.instance.collectables.Remove(this);
    }

}
