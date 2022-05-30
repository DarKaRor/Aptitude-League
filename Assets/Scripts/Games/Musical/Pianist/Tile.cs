using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TileType
{
    White,
    Black,
    Gray,
    Blocked
}
public class Tile : MonoBehaviour
{
    public int row = 0;
    public TileType type = TileType.White;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetType();
    }

    private void OnMouseDown() => Press();
    

    public void Press()
    {
        if (PauseMenu.instance.paused) return;
        if (Pianist.instance.lost) return;
        if (type == TileType.Gray || type == TileType.Blocked) return;
        switch (type)
        {
            case TileType.White:
                MissHit();
                break;
            case TileType.Black:
                Row parent = GetComponentInParent<Row>();
                if (parent.number > Pianist.instance.currentRow)
                {
                    MissHit();
                    return;
                }
                Pianist.instance.currentRow++;
                Pianist.instance.PlayCurrent();
                Pianist.instance.CheckWin();
                parent.touched = true;
                type = TileType.Gray;
                SetType();
                break;
        }
    }

    public void MissHit()
    {
        type = TileType.White;
        SetType();
        GameManager.sharedInstance.PlayAudioLose();
        spriteRenderer.color = Color.red;
        Pianist.instance.StopAll();
    }
    public void SetType()
    {
        if (type == TileType.Blocked) return;
        spriteRenderer.sprite = Pianist.instance.sprites[type];
    }
}
