using UnityEngine;
using System.Collections.Generic;

public static class Piano
{
    public static Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();

    static string pianoKey = "C|Db|D|Eb|E|F|Gb|G|Ab|A|Bb|B";
    static string[] pianoKeys = pianoKey.Split('|');

    public static AudioClip loadNote(string note) => Methods.loadAudio($"PianoNotes/Piano.ff.{note}");

    public static void SetClips(){
        clips = new Dictionary<string, AudioClip>
        {
            { "Gb3", loadNote("Gb3") },
            { "Db5", loadNote("Db5") },
            { "Bb4", loadNote("Bb4") },
            { "Ab4", loadNote("Ab4") },
            { "Gb4", loadNote("Gb4") },
            { "F3", loadNote("F3") },
            { "B4", loadNote("B4") },
            { "Eb4", loadNote("Eb4") },
            { "G4", loadNote("G4") },
            { "F4", loadNote("F4") },
            { "E4", loadNote("E4") },
            { "D4", loadNote("D4") },
            { "C4", loadNote("C4") },
            { "Bb3", loadNote("Bb3") },
            { "D3", loadNote("D3") },
            { "G3", loadNote("G3") },
            { "Ab3", loadNote("Ab3") },
            { "B3", loadNote("B3") },
            { "C5", loadNote("C5") },
            { "Eb3", loadNote("Eb3") },
            { "Db4", loadNote("Db4") },
            { "C3", loadNote("C3") },
            { "A4", loadNote("A4") },
            { "A3", loadNote("A3") },
            { "A5", loadNote("A5")},
            { "D5", loadNote("D5") },
            { "E5", loadNote("E5") },
            { "F5", loadNote("F5") },
            { "G5", loadNote("G5") },
            { "E3", loadNote("E3") },
            { "Db3", loadNote("Db3") },
            { "A2", loadNote("A2") },
            { "B2", loadNote("B2") },
        };

    }

}