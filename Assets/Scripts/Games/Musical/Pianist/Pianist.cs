using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pianist : MonoBehaviour
{
    public static Pianist instance;

    int gameId = 8;
    [SerializeField] GameObject tiles;
    [SerializeField] public Dictionary<TileType, Sprite> sprites = new Dictionary<TileType, Sprite>();
    [SerializeField] Sprite white;
    [SerializeField] Sprite black;
    [SerializeField] Sprite gray;
    [SerializeField] GameObject rowPrefab;

    [HideInInspector] public float scrollSpeed = 2f;
    [HideInInspector] public float yGap = 1.5f;
    [HideInInspector] public int row = 0;
    public int currentRow = 0;
    int currentNote = 0;
    float initialScroll = 2f;
    [HideInInspector] public AudioClip[] clips;
    string songName;
    List<Row> rows = new List<Row>();
    float spawnTime = .3f;
    int maxRows = 20;
    int maxPoints = 50;
    public bool lost = false;
    int lastColumn = -1;
    int lastCount = 0;


    private void Awake() => instance = instance ? instance : this;

    void Start()
    {
        GameManager.sharedInstance.currentGame = gameId;
        GetRandomSong();
        StartCoroutine(SpawnRows());

        sprites = new Dictionary<TileType, Sprite>
        {
            {TileType.White, white },
            {TileType.Black, black },
            { TileType.Gray, gray }
        };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) PressColumn(0);
        if (Input.GetKeyDown(KeyCode.F)) PressColumn(1);
        if (Input.GetKeyDown(KeyCode.J)) PressColumn(2);
        if (Input.GetKeyDown(KeyCode.K)) PressColumn(3);
    }

    public void CheckWin()
    {
        if (currentRow < maxPoints) return;
        Win();
    }

    public void GetRandomSong()
    {
        Song song = Methods.GetRandomElement(Variables.songs);
        clips = Methods.GetClipsFromSong(song);
        scrollSpeed = initialScroll * song.speed;
    }

    public void PlayCurrent()
    {
        if (currentNote >= clips.Length) currentNote = 0;
        GameManager.sharedInstance.PlayEffect(clips[currentNote]);
        currentNote++;
    }

    void SpawnRow()
    {
        GameObject newRow = (Instantiate(rowPrefab, tiles.transform));
        Row rowScript = newRow.GetComponent<Row>();
        if (rows.Count > 0)
        {
            Row lastRow = rows[rows.Count - 1];
            Vector2 pos = lastRow.transform.localPosition;
            pos = new Vector2(pos.x, pos.y + yGap);
            newRow.transform.localPosition = pos;
        }
        rowScript.number = row;
        rows.Add(rowScript);
        row++;
    }

    void PressColumn(int column)
    {

        List<Row> nonTouched = rows.Where(i => !i.touched).ToList();
        Row lastRow = nonTouched[0];
        lastRow.tiles[column].Press();
    }

    public void DeleteRow(Row row)
    {
        rows.Remove(row);
        Destroy(row.gameObject);
    }

    public void StopAll()
    {
        foreach (Row row in rows) row.stop = true;
        StopAllCoroutines();
        StartCoroutine(Lose());
    }

    void DeleteLast() => DeleteRow(rows[0]);

    IEnumerator SpawnRows()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            if (rows.Count <= maxRows) SpawnRow();
        }
    }

    void Win()
    {
        lost = true;
        foreach (Row row in rows) row.stop = true;
        GameManager.sharedInstance.Win();
    }

    IEnumerator Lose()
    {
        lost = true;
        yield return new WaitForSeconds(2);
        GameManager.sharedInstance.GameOver();
    }

    public bool CheckColumn(int column)
    {
        bool equal = column == lastColumn;
        if (!equal)
        {
            lastColumn = column;
            lastCount = 0;
        }
        else lastCount++;
        return lastCount < 2 || !equal;
    }


}
