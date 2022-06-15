using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Persona
{
    public Sprite sprite;
    public string[] caracteristicas;

    public Persona(Sprite sprite, string[] caracteristicas)
    {
        this.sprite = sprite;
        this.caracteristicas = caracteristicas;

    }
}
public class EveryoneIsTheSame : MonoBehaviour
{

    int gameID = 14;
    [SerializeField] Clock clock;
    [SerializeField] Image image1;
    [SerializeField] Image image2;
    [SerializeField] Button[] buttons;
    [SerializeField] LivesCounter livesCounter;
    Persona persona1;
    Persona persona2;
    Counter chances = new Counter(3);
    Counter rounds = new Counter(10);
    int amount = 2;
    int roundsToChange = 0;

    int changed = 1;

    string[] lowPriority = new string[]{
        "Masculino",
        "Femenino",
        "Piel",
        "Adulto"
    };


    void Start()
    {
        GameManager.sharedInstance.currentGame = gameID;
        clock.Start();
        roundsToChange = Mathf.RoundToInt(rounds.max / (5 - amount));
        StartRound();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        if (clock.Update() == 1) StartCoroutine(LoseCoroutine());
    }

    void StartRound()
    {
        clock.Reset();
        persona1 = GetRandomPersona();
        persona2 = GetSimilarPersona(persona1);
        if (rounds.current >= roundsToChange * changed)
        {
            changed++;
            amount++;
        }

        foreach(Button button in buttons)
        {
            button.interactable = true;
            button.GetComponent<CanvasGroup>().alpha = 1;   
        }
        SetPersonas();
    }

    Persona GetSimilarPersona(Persona persona)
    {
        string[] caracteristicas = persona.caracteristicas;
        List<Persona> similares = Variables.personas.Where(i => ComparePersonas(persona, i) && i != persona).ToList();
        if (similares.Count <= 0) return null;
        Persona randomPerson = Methods.GetRandomElement(similares.ToArray());
        return randomPerson;
    }

    bool ComparePersonas(Persona persona1, Persona persona2)
    {
        for (int i = 0; i < persona2.caracteristicas.Length; i++)
        {
            if (Methods.isAny(persona2.caracteristicas[i], persona1.caracteristicas)) return true;
        }
        return false;
    }

    Persona GetRandomPersona() => Methods.GetRandomElement(Variables.personas.ToArray());

    void SetPersonas()
    {
        image1.sprite = persona1.sprite;
        image2.sprite = persona2.sprite;

        string[] characteristics = GetRandomCharacteristics(persona1, persona2, amount);
        DisableAll();
        for (int i = 0; i < characteristics.Length; i++)
        {
            Button btn = buttons[i];
            btn.gameObject.SetActive(true);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = characteristics[i];
        }
    }

    public void CheckValues(int index)
    {
        //Debug.Log("Called from index " + index);
        string answer = buttons[index].GetComponentInChildren<TextMeshProUGUI>().text;

        bool isSimilarity = Methods.isAny(answer, persona1.caracteristicas) && Methods.isAny(answer, persona2.caracteristicas);

        if (isSimilarity)
        {
            if (rounds.Raise())
            {
                DisableAll();
                GameManager.sharedInstance.Win();
                return;
            }

            StartRound();
            GameManager.sharedInstance.PlayAudioWin();
            return;
        }

        livesCounter.LoseLife();
        StartCoroutine(LoseCoroutine());
    }

    IEnumerator LoseCoroutine()
    {
        GameManager.sharedInstance.PlayAudioLose();
        clock.Stop();
        string[] similarities = GetSimilarities(persona1, persona2);

        foreach(Button button in buttons) button.interactable = false;

        foreach (Button btn in buttons)
        {
            
            TextMeshProUGUI text = btn.GetComponentInChildren<TextMeshProUGUI>();
            if (!Methods.isAny(text.text, similarities))
            {
                CanvasGroup cg = btn.GetComponent<CanvasGroup>();
                cg.DOFade(0, 0.5f);
                yield return new WaitForSeconds(0.5f);
            }
        }

        yield return new WaitForSeconds(2f);
        if (chances.Raise())
        {
            GameManager.sharedInstance.GameOver();
            yield break;
        }

        StartRound();
    }

    void DisableAll()
    {
        foreach (Button btn in buttons) btn.gameObject.SetActive(false);
    }

    string[] GetSimilarities(Persona p1, Persona p2)
    {
        List<string> similarities = new List<string>();

        foreach (string s in p1.caracteristicas)
        {
            if (Methods.isAny(s, persona2.caracteristicas)) similarities.Add(s);
        }

        return similarities.ToArray();
    }

    //string GetRandomSimilarity(Persona p1, Persona p2) => Method s.GetRandomElement(GetSimilarities(p1, p2));

    string[] GetRandomCharacteristics(Persona p1, Persona p2, int amount)
    {
        // Forzando que la cantidad sea mayor igual a 2
        if (amount <= 1) amount = 2;

        // Obteniendo las similitudes entre ambas personas.
        string[] similarities = GetSimilarities(p1, p2);
        string[] highPriority = similarities.Where(i => !Methods.ContainsAny(i, lowPriority)).ToArray();  // Todas aquellas similitudes que no sean baja prioridad.
        foreach (string str in highPriority) Debug.Log(str);
        string randomSimilarity;

        // Si existen similitudes que no sean baja prioridad, se toman esas. Caso contrario se toma cualquiera.
        if (highPriority.Length > 0) randomSimilarity = Methods.GetRandomElement(highPriority);
        else randomSimilarity = Methods.GetRandomElement(similarities);

        List<string> characteristics = new List<string>();
        characteristics.Add(randomSimilarity);

        // Se obtienen todas las características de ambas personas sin repetir.
        List<string> all = new List<string>();
        all.AddRange(p1.caracteristicas);
        all.AddRange(p2.caracteristicas);
        all = all.Distinct().ToList();

        // Se calcula la cantidad de todas las características que no son similitudes
        int nonSimilar = all.Count - similarities.Length - 1;

        //Debug.Log($"There are {all.Count} characteristics, {similarities.Length} similarities. There are {nonSimilar} characteristics that are not similar");
        //foreach (string str in all) Debug.Log(str);

        int j = 0;

        // Se pasará por cada característica requerida (menos la similitud que ya ha sido escogida) y se escogerá una características aleatoria que no sea una similitud, a menos que no hayan más.
        // Si no hay características que no sean similitud, se escogerá una característica en general incluyendo similitudes extras.
        // Si no hay más características, se termina el proceso.
        for (int i = 0; i < amount - 1; i++)
        {
            // Filtrado de las caracteristicas ya incluídas.
            List<string> filter = new List<string>();
            filter.AddRange(characteristics);

            // Mientras que existan características no similares, se filtran las similitudes extras.
            if (j < nonSimilar)
            {
                j++;
                //Debug.Log($"Similarities won't be taken in count. {nonSimilar - j} Left available.");
                filter.AddRange(similarities);
            }
            string[] arr = filter.Distinct().ToArray();

            // Se escoge una persona aleatoria.
            bool first = Methods.FlipCoin();
            string random = first ? GetRandomCharacteristic(persona1, arr) : GetRandomCharacteristic(persona2, arr);

            // Si esa persona ya no tiene características, se intenta con la otra. Si ambas no tienen, se termina el for.
            if (random == null)
            {
                random = first ? GetRandomCharacteristic(persona2, arr) : GetRandomCharacteristic(persona1, arr);
                if (random == null) break;
            }
            characteristics.Add(random);
        }

        // Colocando similitud aleatoria en un espacio aleatorio para que no est� siempre en el mismo sitio.
        int randomIndex = Random.Range(1, characteristics.Count);
        string aux = characteristics[0];
        characteristics[0] = characteristics[randomIndex];
        characteristics[randomIndex] = aux;

        return characteristics.ToArray();
    }

    string GetRandomCharacteristic(Persona persona, string[] filter = null) => Methods.GetRandomElement(persona.caracteristicas.Where(i => !Methods.isAny(i, filter)).ToArray());

}
