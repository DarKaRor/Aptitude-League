using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    [SerializeField] public Tile[] tiles;
    public int number = 0;
    public bool stop = false;
    public bool touched = false;
    void Start()
    {
        GetBlackTile();
    }

    void Update()
    {
        if (stop) return;
        transform.Translate(Vector2.down * Pianist.instance.scrollSpeed * Time.deltaTime);
    }

    void GetBlackTile()
    {
        int column = Random.Range(0, 4);
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
