using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class Glass : MonoBehaviour
{
    Range limitsY = new Range(1.11f, -1.388f);
    public bool isFilling = false;
    public float changer = 0;
    public bool mustHaveChild = false;
    public int branchLevel = 1;
    public int number;
    public Connection parentConnection = null;
    public bool setted = false;
    public bool isLast = false;
    public int children = 0;
    [SerializeField] public Counter full = new Counter(100);
    [SerializeField] bool isFull = false;
    [SerializeField] GameObject mask;
    [SerializeField] List<Connection> neighbors = new List<Connection>();
    [SerializeField] TextMeshProUGUI numberText;
    [SerializeField] public GameObject tube;
    [SerializeField] GameObject tubeLeft;
    [SerializeField] GameObject tubeRight;
    [SerializeField] public GameObject corner;
    Range yTube = new Range(1.4f, -1.108f);
    Range xTube =  new Range(1.15f, 0.5f);

    Dictionary<Side, bool> occupied = new Dictionary<Side, bool>
    {
        {Side.Left, false },
        {Side.Right, false}
    };
    void Start()
    {
        SetUp();
        Connection closest = GetClosestConnection();
        float maxFill = closest?.height ?? 100f;
        full.max = maxFill;
    }

    void Update()
    {
        Fill();
        PlaceAtPercent();
    }
    void SetUp()
    {
        changer = WaterGlass.instance.fillSpeed;
        WaterGlass.instance.glasses.Add(this);

        if (branchLevel < WaterGlass.instance.branching)
        {
            CreateChildren();
            return;
        }
        MakeSet();
    }

    void PlaceAtPercent() => mask.transform.localPosition = new Vector2(0, limitsY.GetPercentage(full.current));

    void Fill()
    {
        if (isFull || !isFilling) return;
        full.changer = changer * Time.deltaTime;
        isFull = full.Raise();
        if (isFull)
        {
            if (isLast) WaterGlass.instance.CheckValues();
            Connection closest = GetClosestConnection();
            if (closest != null) closest.child.isFilling = true;
        }
    }

    Connection GetClosestConnection()
    {
        if (neighbors.Count <= 0) return null;
        List<Connection> nonBlocked = GetNonBlocked();
        if (nonBlocked.Count <= 0) return null;
        return nonBlocked.OrderBy(i => i.height).ToList()[0];
    }

    List<Connection> GetNonBlocked() => neighbors.Where(i => !i.isBlocked).ToList();

    void CreateChildren()
    {
        children = Random.Range(mustHaveChild ? 1 : 1, 3);
        for (int i = 0; i < children; i++) CreateChild();
    }

    void CreateChild()
    {
        if (neighbors.Count > 1) return;
        float randomHeight = Random.Range(20, 80);
        if(neighbors.Where(i=>Mathf.Abs((float)i.height - randomHeight) < 20).ToList().Count>0) randomHeight += 20;
        bool isBlocked = Random.Range(0f, 1f) > .7f;

        Side randomSide = GetRandomUnoccupiedSide();
        occupied[randomSide] = true;

        GameObject child = Instantiate(WaterGlass.instance.prefab, WaterGlass.instance.glassParent);
        Glass glass = child.GetComponent<Glass>();
        glass.branchLevel = branchLevel + 1;
        Vector2 position = transform.localPosition;

        position+= (randomSide == Side.Left ? Vector2.left : Vector2.right) * (WaterGlass.instance.spacing * WaterGlass.instance.branching) / branchLevel;

        SetTube(randomSide, randomHeight, isBlocked,glass);
        position += Vector2.down * WaterGlass.instance.spacing;
        child.transform.localPosition = position;
        glass.parentConnection = new Connection(randomHeight, this, isBlocked, randomSide);
        neighbors.Add(new Connection(randomHeight, glass, isBlocked, randomSide));
    }

    Side GetRandomUnoccupiedSide()
    {
        Side[] sides = new Side[] { Side.Left, Side.Right };
        Side randomSide = Methods.GetRandomElement(sides);
        randomSide = occupied[randomSide] ? (randomSide == Side.Left ? Side.Right : Side.Left) : randomSide;
        return randomSide;
    }

    void SetTube(Side side, float height, bool isBlocked, Glass child)
    {
        GameObject childTube = child.tube;

        GameObject currentTube;
        Range currentRange = xTube;

        if (side == Side.Left)
        {
            currentTube = tubeLeft;
            currentRange = new Range(-xTube.max,-xTube.min);
            child.corner.GetComponent<SpriteRenderer>().flipX = false;
        }
        else currentTube = tubeRight;

        currentTube.transform.localScale = new Vector2(currentTube.transform.localScale.x,(0.53f * WaterGlass.instance.branching) / branchLevel);
        childTube.transform.localScale = new Vector2(childTube.transform.localScale.x, 0.54f * (height / 100));
        currentTube.SetActive(true);
        SpriteRenderer renderer = currentTube.GetComponent<SpriteRenderer>();
        SpriteRenderer tubeRenderer = child.tube.GetComponent<SpriteRenderer>();
        child.corner.transform.localPosition = (Vector2)childTube.transform.localPosition + Vector2.up * tubeRenderer.sprite.bounds.size.y * childTube.transform.localScale.y;
        child.corner.SetActive(true);

        if (isBlocked) renderer.sortingOrder = -1;
        currentTube.transform.localPosition = new Vector2(currentRange.GetPercentage(height), yTube.GetPercentage(height));
    }

    public bool CanGetFilled()
    {
        if (parentConnection.isBlocked) return false;
        List<Connection> nonBlocked = GetNonBlocked();
        if (nonBlocked.Count > 0) return false;
        return true;
    }

    public void MakeSet()
    {
        if (setted) return;
        if (children > 1) setted = neighbors.Where(i => i.child.setted).ToList().Count > 1;
        else setted = true;
        if (setted)
        {
            if (parentConnection.child != null) parentConnection.child.MakeSet();
            if (branchLevel == 1) WaterGlass.instance.OrderChildren();

        }
    }

    public void SetNumber(int number)
    {
        this.number = number;
        numberText.text = number.ToString();
    }

    public Glass GetFirstChildToFill()
    {
        Connection closest = GetClosestConnection();
        if (closest != null) return closest.child;
        return null;
    }

}
