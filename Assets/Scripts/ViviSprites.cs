using System.Collections.Generic;

public enum ViviSprite
{
    Default,
    Sad,
    Excited,
    Explain1,
    Explain2,
    Explain3,
    Happy,
    Upset,
    Upset2,
    Dizzy,
    Nervous,
    Normal,
    Serious,
    Serious2,
    Calm
}

public static class ViviSprites
{
    static string path(string str) => $"Vivi/Vivi {str}";

    static UnityEngine.Sprite load(string name) => Methods.loadSprite(path(name));


    public static Dictionary<ViviSprite, UnityEngine.Sprite> viviSprites = new Dictionary<ViviSprite, UnityEngine.Sprite>()
    {
        {ViviSprite.Default, load("Default")},
        {ViviSprite.Sad, load("Deprimida")},
        {ViviSprite.Excited, load("Emocionada")},
        {ViviSprite.Explain1, load("Explicando1")},
        {ViviSprite.Explain2, load("Explicando2")},
        {ViviSprite.Explain3, load("Explicando3")},
        {ViviSprite.Happy, load("Feliz")},
        {ViviSprite.Upset, load("Malhumorada")},
        {ViviSprite.Upset2, load("Malhumorada2")},
        {ViviSprite.Dizzy, load("Mareada")},
        {ViviSprite.Nervous, load("Nerviosa")},
        {ViviSprite.Normal, load("Normal")},
        {ViviSprite.Serious, load("Seria 1")},
        {ViviSprite.Serious2, load("Seria 2")},
        {ViviSprite.Calm, load("Tranquila")},
    };

    public static UnityEngine.Sprite GetSprite(ViviSprite sprite) => viviSprites[sprite];

    public static UnityEngine.Sprite Happy() => viviSprites[ViviSprite.Happy];
    public static UnityEngine.Sprite Sad() => viviSprites[ViviSprite.Sad];
    public static UnityEngine.Sprite Excited() => viviSprites[ViviSprite.Excited];
    public static UnityEngine.Sprite Normal() => viviSprites[ViviSprite.Normal];
    public static UnityEngine.Sprite Serious() => viviSprites[ViviSprite.Serious];
    public static UnityEngine.Sprite Serious2() => viviSprites[ViviSprite.Serious2];
    public static UnityEngine.Sprite Calm() => viviSprites[ViviSprite.Calm];
    public static UnityEngine.Sprite Dizzy() => viviSprites[ViviSprite.Dizzy];
    public static UnityEngine.Sprite Nervous() => viviSprites[ViviSprite.Nervous];
    public static UnityEngine.Sprite Upset() => viviSprites[ViviSprite.Upset];
    public static UnityEngine.Sprite Upset2() => viviSprites[ViviSprite.Upset2];
    public static UnityEngine.Sprite Explain1() => viviSprites[ViviSprite.Explain1];
    public static UnityEngine.Sprite Explain2() => viviSprites[ViviSprite.Explain2];
    public static UnityEngine.Sprite Explain3() => viviSprites[ViviSprite.Explain3];
    public static UnityEngine.Sprite Default() => viviSprites[ViviSprite.Default];


}