using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    [SerializeField] public Tile[] tiles;
    public int number = 0;
    public bool touched = false;
    void Start()
    {
        GetBlackTile();
    }

    void Update()
    {
        if (Pianist.instance.stop) return;
        transform.Translate(Vector2.down * Pianist.instance.scrollSpeed * Time.deltaTime);
    }

    void GetBlackTile()
    {
        int column = Random.Range(0, 4);
        if (!Pianist.instance.CheckColumn(column))
        {
            column++;
            if (column > 3) column = 0;
            Pianist.instance.CheckColumn(column);
        }
        Tile tile = tiles[column];
        tile.type = TileType.Black;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Remover"))
        {
            if (!touched)
            {
                foreach(Tile tile in GetComponentsInChildren<Tile>()) tile.MissHit();
                return;
            }
            Pianist.instance.DeleteRow(this);
            Destroy(gameObject);
        }
    }
}
