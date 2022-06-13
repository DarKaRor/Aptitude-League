
public class Song
{
    public string name;
    public string sheet;
    public int key;
    public float speed;

    public Song(string name, string sheet, float speed, int key = 4)
    {
        this.name = name;
        this.sheet = sheet;
        this.speed = speed;
        this.key = key;
    }
}
