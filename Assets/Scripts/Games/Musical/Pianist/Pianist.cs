using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

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
    [SerializeField] Sprite[] backgrounds;
    [SerializeField] Image left;
    [SerializeField] Image right;

    [HideInInspector] public float scrollSpeed = 2f;
    [HideInInspector] public float yGap = 1.5f;
    [HideInInspector] public int row = 0;
    public int currentRow = 0;
    int currentNote = 0;
    float initialScroll = 2f;
    string songName;
    List<Row> rows = new List<Row>();
    float spawnTime = .3f;
    int maxRows = 20;
    int maxPoints = 50;
    public bool lost = false;
    int lastColumn = -1;
    int lastCount = 0;


    private void Awake() => instance = instance ? instance : this;

    // Testing purposes
    //string song = "Db+|Db+|Bb|Ab|Gb|Db+|Db+|Db+|Bb|Ab|Gb|B|Bb|Db+|Db+|Bb|Ab|Gb|Db+|Db+|Db+|Bb|Ab|Gb|Ab|Gb|Eb";
    string song = "";
    List<string[]> notes = new List<string[]>();
    int pianoKey = 4;

    List<string[]> GetSongByKey(int key, string song){
        string[] noteGroups = song.Split('|');
        List<string[]> newNoteGroups = new List<string[]>();


        foreach(string noteGroup in noteGroups){
            List<string> newNotes = new List<string>();
            string[] notes = noteGroup.Split('/');

            foreach(string note in notes){
                int numPlus = note.Count(c => c == '+');
                int numMinus = note.Count(c => c == '-');
                string noteName = note.Replace("+", "").Replace("-", "");

                newNotes.Add(noteName + (key + numPlus - numMinus));
            }

            newNoteGroups.Add(newNotes.ToArray());
        }

        return newNoteGroups;
    }

    void Start()
    {
        GameManager.sharedInstance.currentGame = gameId;
        Piano.SetClips();
        GetRandomSong();
        GetRandomBackground();
        if(!GameManager.sharedInstance.isFreePlay) GetRandomNote();
        else maxPoints = notes.Count;
        StartCoroutine(SpawnRows());

        sprites = new Dictionary<TileType, Sprite>
        {
            {TileType.White, white },
            {TileType.Black, black },
            { TileType.Gray, gray }
        };

        // Testing purposes
        //maxPoints = 1000;
    }

    void GetRandomBackground(){
        Sprite randomSprite = Methods.GetRandomElement(backgrounds);
        left.sprite = randomSprite;
        right.sprite = randomSprite;
    }

    void GetRandomNote()
    {
        currentNote = Random.Range(0, notes.Count);
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
        Song songObj = Methods.GetRandomElement(Variables.songs);
        //songObj = Variables.songs[2];
        song = songObj.sheet;
        pianoKey = songObj.key;
        notes = GetSongByKey(pianoKey, song);
        scrollSpeed = initialScroll * songObj.speed;
        spawnTime = .3f / songObj.speed;
    }

    public void PlayCurrent(){
        if(currentNote >= notes.Count) currentNote = 0;
        foreach(string note in notes[currentNote]){
            GameManager.sharedInstance.PlayEffect(Piano.clips[note]);
            //Debug.Log(note);
        }
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
