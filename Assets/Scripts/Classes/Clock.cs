using UnityEngine;
using TMPro;


[System.Serializable]
public class Clock
{
    [SerializeField] public Counter timer;
    [SerializeField] public bool countDown;
    [SerializeField] public TextMeshProUGUI outputText;
    [SerializeField] public GameObject target;
    [HideInInspector] public AudioSource tickAudio;
    [SerializeField] public AudioClip sound;
    [SerializeField] public float changer;
    [SerializeField] public int triggerSecond;
    float originalChanger;
    public bool stop = false;
    public Color color = Color.black;

    public void Start()
    {
        tickAudio = target.AddComponent<AudioSource>();
        tickAudio.clip = sound;
        originalChanger = timer.changer;
    }

    public int Update()
    {
        if (stop) return 0;
        int previous = GetRoundedTime();
        timer.changer = changer == -1 ? Time.deltaTime : originalChanger;

        if (timer.Raise()) return 1;

        int current = GetRoundedTime();
        outputText.text = current.ToString();

        if (current < previous && previous == triggerSecond + 1)
        {
            if (!tickAudio.isPlaying) tickAudio.Play();
            outputText.color = Color.red;
        }

        return 0;
    }

    int GetRoundedTime() => Mathf.RoundToInt(countDown ? timer.GetReverseValue() : timer.current);

    public void Reset()
    {
        Resume();
        timer.Reset();
        StopTrigger();
    }

    public void StopTrigger()
    {
        tickAudio.Stop();
        outputText.color = color;
    }

    public void Stop()
    {
        stop = true;
        tickAudio.Stop();
    }

    public bool CheckTrigger() => timer.current >= timer.max - triggerSecond;
    public void Resume() => stop = false;
}
