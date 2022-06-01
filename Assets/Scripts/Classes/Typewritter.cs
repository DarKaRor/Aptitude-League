using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public enum TypeWritterAction
{
    Return,
    Backspace,
    Pass,
    Sent
}

[System.Serializable]
public class Typewritter
{
    [SerializeField] public TextMeshProUGUI output;
    [SerializeField] public AudioClip hit;
    [SerializeField] public AudioClip type;
    [SerializeField] public int maxLength;
    [SerializeField] public char lastChar;
    [SerializeField] public string defaultString;
    public bool types = true;
    public bool checkLower = false;
    AudioSource audio;
    public List<string> writtable = new List<string>();
    Dictionary<string, string> replacements = new()
    {
        { "Alpha", "" },
        { "Keypad", "" },
        { "Period", "." },
        { "Comma", "," },
        { "Minus", "-" },
        { "BackQuote", "ñ" }
    };

    public void Start()
    {
        audio = GameManager.sharedInstance.gameObject.GetComponent<AudioSource>();
        Debug.Log(audio);
        if(types) output.text = defaultString;
    }
    
    public TypeWritterAction Update()
    {
        if (PauseMenu.instance.paused) return TypeWritterAction.Pass;
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) return TypeWritterAction.Return; // Si se presiona enter, revisar
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (types) Delete();
            else return TypeWritterAction.Backspace;
        }

        if(types) if (output.text.Length > maxLength) return TypeWritterAction.Pass;
        // Pasar por todas las teclas posibles
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            // Verificar si esa tecla si tocó en el frame indicado.
            if (Input.GetKeyDown(vKey))
            {
              
                // Si forma parte de los carácters aceptados
                bool shouldSend = false;
                string key = ReplaceAll(vKey.ToString(), replacements);

                key = checkLower ? key.ToLower() : key;

                if (key.Length > 1) return TypeWritterAction.Pass;
                shouldSend = Methods.isAny(key, writtable.ToArray());

                if (shouldSend) // Si se puede enviar, agregar la letra.
                {
                    lastChar = char.Parse(key);
                    return TypeWritterAction.Sent;
                }
            }
        }

        return TypeWritterAction.Pass;
    }

    public string ReplaceAll(string str, Dictionary<string,string> keys)
    {
        foreach(KeyValuePair<string,string> kvp in keys) str = str.Replace(kvp.Key, kvp.Value);
        
        return str;
    }

    public void Type(string key = "")
    {
        if (key == "") key = lastChar.ToString();
        if (output.text == defaultString) output.text = key;
        else output.text += key;
        PlayType();
    }

    public void Delete()
    {
        output.text = Methods.RemoveLast(output.text); // Si se presiona backspace, borrar un caracter
        PlayHit();
    }

    public string last2String() => lastChar.ToString();

    public void PlayHit() => audio.PlayOneShot(hit);
    public void PlayType() => audio.PlayOneShot(type);
}
