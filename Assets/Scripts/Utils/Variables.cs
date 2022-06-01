using System.Collections.Generic;
using UnityEngine;
public class Variables
{
    public static string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    public static string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

    public static Dictionary<Topic, string> definitions = new()
    {
        { Topic.Nature, "Naturaleza" },
        { Topic.Countries, "Países" },
        { Topic.People, "Personas" },
        { Topic.Videogames, "Videojuegos" },
        { Topic.TV, "Televisión" },
        { Topic.Activities, "Actividades" }
    };

    public static Phrase[] phrases = new Phrase[]
    {
        new Phrase("Capitalista",Topic.People),
        new Phrase("Comunista",Topic.People),
        new Phrase("Europeo",Topic.People),
        new Phrase("Asiático",Topic.People),
        new Phrase("Latinoamericano",Topic.People),
        new Phrase("Alto",Topic.People),
        new Phrase("Bajo",Topic.People),
        new Phrase("Gordo",Topic.People),
        new Phrase("Flaco",Topic.People),
        new Phrase("Brasileño",Topic.People),
        new Phrase("Ñoño",Topic.People),
        new Phrase("Tonto",Topic.People),
        new Phrase("Inteligente",Topic.People),
        new Phrase("Guapo",Topic.People),
        new Phrase("Boxeador",Topic.People),
        new Phrase("Deportista",Topic.People),
        new Phrase("Beisbolista",Topic.People),
        new Phrase("Matemático",Topic.People),
        new Phrase("Astronauta",Topic.People),
        new Phrase("Físico",Topic.People),
        new Phrase("Químico",Topic.People),
        new Phrase("Psicólogo",Topic.People),
        new Phrase("Italia",Topic.Countries),
        new Phrase("Zimbabue",Topic.Countries),
        new Phrase("Qatar",Topic.Countries),
        new Phrase("Egipto",Topic.Countries),
        new Phrase("Costa Rica",Topic.Countries),
        new Phrase("Perú",Topic.Countries),
        new Phrase("Chile",Topic.Countries),
        new Phrase("Argentina",Topic.Countries),
        new Phrase("Brasil",Topic.Countries),
        new Phrase("México",Topic.Countries),
        new Phrase("Canadá",Topic.Countries),
        new Phrase("Inglaterra",Topic.Countries),
        new Phrase("Alemania",Topic.Countries),
        new Phrase("Arabia Saudita",Topic.Countries),
        new Phrase("Bélgica",Topic.Countries),
        new Phrase("China",Topic.Countries),
        new Phrase("Corea del Sur",Topic.Countries),
        new Phrase("Bosnia",Topic.Countries),
        new Phrase("Elefante",Topic.Nature),
        new Phrase("Arboleda", Topic.Nature),
        new Phrase("Planeta",Topic.Nature),
        new Phrase("Mario Bros",Topic.Videogames),
        new Phrase("Sonic El Erizo",Topic.Videogames),
        new Phrase("Super Smash Bros",Topic.Videogames),
        new Phrase("Los Simpsons",Topic.TV),
        new Phrase("La ley y el orden",Topic.TV),
        new Phrase("El rey leon",Topic.TV),
        new Phrase("Comunidad",Topic.People),
        new Phrase("Pokémon",Topic.Videogames),
        new Phrase("La leyenda de Zelda",Topic.Videogames),
        new Phrase("PAC MAN",Topic.Videogames),
        new Phrase("El chavo del 8",Topic.TV),
        new Phrase("Dragon Ball",Topic.TV),
        new Phrase("Arbusto", Topic.Nature),
        new Phrase("Grama",Topic.Nature),
        new Phrase("Perro",Topic.Nature),
        new Phrase("Jirafa",Topic.Nature),
        new Phrase("Flores",Topic.Nature),
        new Phrase("Orquidea",Topic.Nature),
        new Phrase("Venezolano",Topic.People),
        new Phrase("Japonés",Topic.People),
        new Phrase("Estadounidense",Topic.People),
        new Phrase("Cristiano",Topic.People),
        new Phrase("Budista",Topic.People),
        new Phrase("Famoso",Topic.People),
        new Phrase("Director",Topic.People),
        new Phrase("Actor",Topic.People),
        new Phrase("Ingeniero",Topic.People),
        new Phrase("Informático",Topic.People),
        new Phrase("Programador",Topic.People),
        new Phrase("Diseñador",Topic.People),
        new Phrase("Australiano",Topic.People),
        new Phrase("Guajiro",Topic.People),
        new Phrase("Fuego",Topic.Nature),
        new Phrase("Agua",Topic.Nature),
        new Phrase("Nieve",Topic.Nature),
        new Phrase("Arena",Topic.Nature),
        new Phrase("Rocas",Topic.Nature),
        new Phrase("Hierba",Topic.Nature),
        new Phrase("Tierra",Topic.Nature),
        new Phrase("Montaña",Topic.Nature),
        new Phrase("Volcán",Topic.Nature),
        new Phrase("Prado",Topic.Nature),
        new Phrase("Animales silvestres",Topic.Nature),
        new Phrase("Universo",Topic.Nature),
        new Phrase("Ecosistema",Topic.Nature),
        new Phrase("Tornados",Topic.Nature),
        new Phrase("Huracanes",Topic.Nature),
        new Phrase("Planetas",Topic.Nature),
        new Phrase("Gravedad",Topic.Nature),
        new Phrase("Diversión",Topic.Activities),
        new Phrase("Jugar",Topic.Activities),
        new Phrase("Comer",Topic.Activities),
        new Phrase("Dormir",Topic.Activities),
        new Phrase("Caminar",Topic.Activities),
        new Phrase("Correr",Topic.Activities),
        new Phrase("Saltar",Topic.Activities),
        new Phrase("Golpear",Topic.Activities),
        new Phrase("Estudio",Topic.Activities),
        new Phrase("Trabajo",Topic.Activities),
        new Phrase("Ejercicio",Topic.Activities),
    };

    public static GrammarQuestion[] grammarQuestions = new GrammarQuestion[]
    {
        new GrammarQuestion("No ahi comida?", new string[]{
            "¿No hay comida?"
        }),
        new GrammarQuestion("¿Dónde está una tienda?", new string[]{
            "¿Dónde hay una tienda?",
            "¿Dónde está la tienda?"
        }),
        new GrammarQuestion("Cuando sabes a qué hora irás, avísame", new string[]{
            "Cuando sepas a qué hora irás, avísame"
        }),
        new GrammarQuestion("Aquella es la fortaleza mucha vieja de la ciudad", new string[]{
            "Aquella es la fortaleza más vieja de la ciudad",
            "Aquella es la fortaleza vieja de la ciudad"
        }),
        new GrammarQuestion("El teatro es cerca de la oficina", new string[]{
            "El teatro está cerca de la oficina",
            "El teatro estuvo cerca de la oficina",
            "El teatro se encuentra cerca de la oficina"
        }),
        new GrammarQuestion("Le gustaba tanto que lo llevaba siempre con sí", new string[]{
            "Le gustaba tanto que lo llevaba siempre consigo"
        }),
        new GrammarQuestion("Deberíamos ir a el cine", new string[]{
            "Deberíamos ir al cine"
        }),
        new GrammarQuestion("El doctor me dijo que tendría una alergia", new string[]{
            "El doctor me dijo que tengo una alergia",
            "El doctor me dijo que tendré una alergia",
            "El doctor me dijo que tendrá una alergia"
        }),
        new GrammarQuestion("Cuando sabes a qué hora irás, avísame", new string[]{
            "Cuando sepas a qué hora irás, avísame"
        }),
        new GrammarQuestion("Ayer no venía porque estaba enfermo", new string[]{
            "Ayer no vine porque estaba enfermo",
            "Ayer no venía, porque estaba enfermo"
        }),
    };

    public static string flutePath = "Notes/Flute/";
    public static string keySpritesPath = "Keys/";

    public static List<Note> notes = new List<Note>{
        new Note(new NoteSound(Methods.loadAudio(flutePath+"FluteAMed"),null),"FAm"),
        new Note(new NoteSound(Methods.loadAudio(flutePath+"FluteBMed"),null),"FBm"),
        new Note(new NoteSound(Methods.loadAudio(flutePath+"FluteDMed"),null),"FDm"),
        new Note(new NoteSound(Methods.loadAudio(flutePath+"FluteD2Med"),null),"FD2m"),
        new Note(new NoteSound(Methods.loadAudio(flutePath+"FluteFMed"),null),"FFm"),
    };


    public static Dictionary<KeyCode, Sprite> keySprites = new()
    {
        { KeyCode.Space, Methods.loadSprite(keySpritesPath + "SpaceBar") },
        { KeyCode.LeftArrow, Methods.loadSprite(keySpritesPath + "left") },
        { KeyCode.RightArrow, Methods.loadSprite(keySpritesPath + "right") },
        { KeyCode.DownArrow, Methods.loadSprite(keySpritesPath + "down") },
        { KeyCode.UpArrow, Methods.loadSprite(keySpritesPath + "up") }
    };

    public static Song[] songs = new Song[]
    {
        new Song("toreador","FNAF/", 1.5f)
    };

    public static string SSPath = "ExtremeSS/";

    public static SimonItem[] simonItems = new SimonItem[]
    {
        new SimonItem("Rojo",Methods.loadAudio($"{SSPath}Rojo"),null,Color.red),
        new SimonItem("Azul",Methods.loadAudio($"{SSPath}Azul"),null,Color.blue),
        new SimonItem("Verde",Methods.loadAudio($"{SSPath}Verde"),null,Color.green),
        new SimonItem("Amarillo",Methods.loadAudio($"{SSPath}Amarillo"),null, Color.yellow),
        new SimonItem("Violeta",Methods.loadAudio($"{SSPath}Violeta"),null,new Color32(143,0,255,255)),
        new SimonItem("Naranja",Methods.loadAudio($"{SSPath}Naranja"),null, new Color32(255, 140, 0,255)),
        new SimonItem("Marrón",Methods.loadAudio($"{SSPath}Marrón"),null, new Color32(128, 64, 0,255)),
        new SimonItem("Celeste",Methods.loadAudio($"{SSPath}Celeste"),null, new Color32(173, 216, 230,255)),
        new SimonItem("Rosado",Methods.loadAudio($"{SSPath}Rosado"),null, new Color32(255, 0, 128,255)),
        new SimonItem("Blanco",Methods.loadAudio($"{SSPath}Blanco"),null),
        new SimonItem("Dólar",Methods.loadAudio($"{SSPath}Dólar"),Methods.loadSprite($"{SSPath}dollar")),
        new SimonItem("❤",Methods.loadAudio($"{SSPath}Corazon"),Methods.loadSprite($"{SSPath}heart")),
        new SimonItem("π",Methods.loadAudio($"{SSPath}Pi"),Methods.loadSprite($"{SSPath}pi")),
        new SimonItem("@",Methods.loadAudio($"{SSPath}Arroba"),Methods.loadSprite($"{SSPath}arroba")),
        new SimonItem(",",Methods.loadAudio($"{SSPath}Coma"),Methods.loadSprite($"{SSPath}coma")),
        new SimonItem(".",Methods.loadAudio($"{SSPath}Punto"),Methods.loadSprite($"{SSPath}dot")),
        new SimonItem("Raíz",Methods.loadAudio($"{SSPath}Raíz"),Methods.loadSprite($"{SSPath}sqr")),
        new SimonItem("[]",Methods.loadAudio($"{SSPath}Corchetes"),Methods.loadSprite($"{SSPath}brackets")),
        new SimonItem("Diamante",Methods.loadAudio($"{SSPath}Diamante"),Methods.loadSprite($"{SSPath}diamond")),
    };

    public static Identify[] animalItems = new Identify[]
    {
        new Identify(
            new string[]
            {
                "perro",
                "cachorro",
                "canino",
                "can"
            },
            "dog","Woof, woof!"
        ),
        new Identify(
            new string[]
            {
                "gato",
                "felino",
                "minino",
                "micho"
            },
            "cat","Miau"
        ),
        new Identify(
            new string[]
            {
                "loro",
                "cacatua",
                "papagayo",
                "cotorro",
                "cotorra",
                "perico"
            },
            "loro",null
        ),
    };


    public static Identify[] emotionItems = new Identify[]
    {
        new Identify(
            new string[]
            {
                "felicidad",
                "feliz",
                "alegria",
                "alegre"
            },
            "feliz"
        ),
        new Identify(
            new string[]
            {
                "tristeza",
                "triste",
                "pena",
                "melancolia",
                "pesadumbre"
            },
            "triste"
        )
    };


}
