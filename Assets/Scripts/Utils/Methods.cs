using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

public static class Methods
{
    public static bool isAny<T>(T element, T[] elements)
    {
        foreach (T e in elements)
        {
            if (e.Equals(element))
                return true;
        }
        return false;
    }

    public static string RemoveLast(string s) => s.Length > 1 ? s.Remove(s.Length - 1) : "?";

    public static T GetRandomElement<T>(T[] array) => array[Random.Range(0, array.Length)];


    // This function will check if the number is prime by using all the previous
    // numbers. There's no need to check further than the square root 
    // Returns true or false.
    public static bool isPrime(int number)
    {
        double sqrNum = Mathf.Sqrt(number);
        for (int i = 2; i <= sqrNum; i++) if (number % 2 == 0) return false;
        return true;
    }


    // This function is essentially the same
    // but will only compare with numbers from a prime number list
    public static bool isPrime(int number, int[] primeList)
    {
        double sqrNum = Mathf.Sqrt(number);

        foreach (int prime in primeList)
        {
            if (prime > sqrNum) return true;
            else if (number % prime == 0) return false;
        }
        return true;
    }

    public static Vector2 Clamp(Vector2 input, float min, float max)
    {
        float x = Mathf.Clamp(input.x, min, max);
        float y = Mathf.Clamp(input.y, min, max);
        return new Vector2(x, y);
    }

    public static string SinTildes(string s)
    {
        return string.Concat(Regex.Replace(s, @"(?i)[\p{L}-[ña-z]]+", m =>
        m.Value.Normalize(NormalizationForm.FormD))
            .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
    }

    public static AudioClip loadAudio(string path) => Resources.Load<AudioClip>("Sound/" + path);
    

    public static Sprite loadSprite(string path) => Resources.Load<Sprite>("Sprites/" + path);


    public static Dictionary<string, Note> NotesByCode()
    {
        Dictionary<string, Note> notes = new Dictionary<string, Note>();
        foreach(Note note in Variables.notes) notes.Add(note.code, note);
        return notes;
    }

    public static AudioClip[] GetClipsFromSong(Song song)
    {
        List<AudioClip> audioClips = new List<AudioClip>();
        bool wasEmpty = false;
        int i = 1;
        while (!wasEmpty) { 
            AudioClip current = loadAudio($"{song.path}{song.name}-{i.ToString("00")}");
            i++;
            wasEmpty = current == null;
            if (!wasEmpty) audioClips.Add(current);
        }
        return audioClips.ToArray();
    }

    public static AudioClip LoadOST(string name) => loadAudio($"Aptitude League OST/{name}");

    public static bool FlipCoin() => Random.Range(0, 2) == 0;

    public static bool Roll(int number) => Random.Range(1, 101) <= number;
    
}
