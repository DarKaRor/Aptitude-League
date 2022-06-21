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
        new GrammarQuestion("No __ comida?", new string[]{
            "Hay",
            "Ahí",
            "Ay",
        }),
        new GrammarQuestion("¿Dónde está __ tienda?", new string[]{
            "La",
            "Una",
            "El",
            "Las"
        }),
        new GrammarQuestion("Cuando __ a qué hora irás, avísame", new string[]{
            "Sepas",
            "Sabes",
            "Saber"
        }),
        new GrammarQuestion("Aquella es la fortaleza __ vieja de la ciudad", new string[]{
            "Más",
            "Mucha",
            "Que"
        }),
        new GrammarQuestion("El teatro __ cerca de la oficina", new string[]{
            "Está",
            "Es",
            "En"
        }),
        new GrammarQuestion("Le gustaba tanto que lo llevaba siempre __", new string[]{
            "Consigo",
            "Con si",
            "Si"
        }),
        new GrammarQuestion("Deberíamos ir __ cine", new string[]{
            "Al",
            "A el",
            "A"
        }),
        new GrammarQuestion("El doctor me dijo que __ una alergia", new string[]{
            "Tendré",
            "Tener",
            "Tuveré"
        }),
        new GrammarQuestion("Ayer no __ porque estaba enfermo", new string[]{
            "Vine",
            "Venía",
            "Vendré"
        }),
        new GrammarQuestion("Realizó el pedido __ de su hermano.", new string[]{
            "A través",
            "Através",
            "A traves"
        }),
        new GrammarQuestion("No pudo __ las paredes", new string[]{
            "Atravesar",
            "Atravezar",
            "A travezar"
        }),
        new GrammarQuestion("Estás __ con tu cónyugue", new string[]{
            "De acuerdo",
            "Acuerdo",
            "Deacuerdo"
        }),
        new GrammarQuestion("Es __ este trabajo que realizo.", new string[]{
            "Desastroso",
            "Dezastroso",
            "Desastrozo"
        }),
        new GrammarQuestion("Yo __ una película.", new string[]{
            "Dirijo",
            "Dirigo",
            "Dirigiendo"
        }),
        new GrammarQuestion("¿Qué hacer con tanta __ de conocimiento?", new string[]{
            "Escasez",
            "Escasés",
            "Escases"
        }),
        new GrammarQuestion("Tiene mucha __ de obtener la beca", new string[]{
            "Expectativa",
            "Espectativa",
            "Expectatiba",
            "Espectativas"
        }),
        new GrammarQuestion("La __ de ser uno mismo no cuesta nada", new string[]{
            "Esencia",
            "Escencia",
            "Esensia",
        }),
        new GrammarQuestion("Debemos __ con calma.", new string[]{
            "Inhalar",
            "Inalar",
            "Inhibir",
            "Halar"
        }),
        new GrammarQuestion("__ nos separen otra vez de nuestros padres", new string[]{
            "Tal vez",
            "Talvez",
            "Tal ves",
            "Talves"
        }),
        new GrammarQuestion("No tengas __ de participar en clases", new string[]{
            "Vergüenza",
            "Verguenza",
            "Verguenzas",
            "Vergüensa"
        }),
        new GrammarQuestion("Ella quiso casarse con él; __, lo amaba.", new string[]{
            "O sea",
            "Osea",
            "Ósea",
            "Sea"
        }),
        new GrammarQuestion("Es un __ distintivo del lenguaje", new string[]{
            "Rasgo",
            "Razgo",
            "Rasjo",
        }),
        new GrammarQuestion("No hizo caso, por ello, le robaron el auto del __", new string[]{
            "Garaje",
            "Garage",
            "Garag",
        }),
        new GrammarQuestion("__ su mirada hacia ti", new string[]{
            "Dirige",
            "Dirije",
            "Dirigir",
        }),
        new GrammarQuestion("Su amor es una __. Es una especie de aflicción", new string[]{
            "Obsesión",
            "Obseción",
            "Obsecion",
            "Obcesión"
        }),
        new GrammarQuestion("__ la ley al cruzar con la luz en rojo.", new string[]{
            "Infringió",
            "Infligió",
            "Infrigió",
            "Inflingió"
        }),
        new GrammarQuestion("__ la beca al estudiante más aplicado.", new string[]{
            "Otórguese",
            "Otórgese",
            "Otorgen",
        }),
        new GrammarQuestion("__ bien sus horarios y realise sus actividades de manera adecuada.", new string[]{
            "Organice",
            "Organise",
            "Orgánice",
        }),
        new GrammarQuestion("Vivi suele comprar cinco __", new string[]{
            "Manzanas",
            "Mansanas",
            "Mansanaz",
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
        new Song("Gourmet Race","Eb/G|D/F|C/Eb|Bb-/D|Bb-/F-|D-/G-|Ab-/C|Bb-/D|C/Eb|D/F|D/B-|C+|G|Eb|D|C|C|D|Eb|C|Bb-|C|G-|C+|G|Eb|D|C|C|D|Eb|F|D|Bb-|C|G-|C|Eb/G/C+|C/Eb/G|G-/C/Eb|F-/G-/D|Eb-/G-/C|F-/Ab-/C|F-/Ab-/D|F-/Ab-/Eb|F-/Ab-/C|Eb-/G-/Bb-|Eb-/G-/C|C-/Eb-/G-|Eb/G/C+|C/Eb/G|Ab-/C/Eb|Ab-/C/F|Ab-/C/G|F-/Ab-/C|G-/Bb-/D|G-/Bb-/F|G-/Bb-/D|D-/G-/Bb-|Eb-/G-/C",2),
        new Song("Build Our Machine","D/F/A|D/F/A|D/F/A|D/F/A|A|A|A|A|D|D|A|F|E|D|A-|D|F|D|A-|D|F|D|D|F|Bb|A|G|F|A|D|F|Bb|A|G|A|Bb|A|G|F|A|G|F|G|A|D|D|D|F|D|D|F|D|D|A|G|F|E|D|F|A-|D|F|D|D|F|A|G|F|E|D|A-|D|F|D|A-|D|F|D|D|F|A|G|F|E|D|F|D|Bb|A|G|A|Bb|A|G|A|A|G|F|G|A|D|F|F|D|D|F|D|A|A|G|F|G|Db+|A|D+|F+|E+|C+|D+|A+|G+|F+|D+|D+|D+|D+|F+|D+|D+|F+|D+|A+|A+|G+|D+|F+|D+|A+|G+|G+|F+|F+|D+|C+|D+|C+|D+|F+|A+|G+|G+|F+|A+|G+|G+|F+|F+|D+",1.8f),
        new Song("M.I.N.T","B-|B-|B-|D|E|Gb|B-|B-|B-|D|B-|Db|B-|B-|B-|B-|D|E|Gb|B-|B-|B-|D|B-|E|D|A-|B-|B-|B-|D|E|Gb|B-|B-|B-|D|B-|Db|B-|B-|B-|B-|D|E|Gb|B-|B-|B-|D|B-|E|D|A-|D|D|D|E|G|A|G|Gb|G|Gb|E|Gb|D|E|D|Db|D|E|G|Gb|E|D-|D-|D-|E-|G-|A-|G-|Gb-|G-|Gb-|E-|Gb-|D-|E-|D-|Db-|D-|E-|G-|Gb-|E-|A-|B-|Db|D|B-|Gb|Gb|E|D|Db|D|E|E|A-|A-|B-|Db|D|B-|Gb|Gb|A|G|Gb|E|D|Gb|E|D|Db|B-/B--|Db-|D-|B--|Gb-|Gb-|E-|D-|Db-|D-|E-|E-|A--|A--|B--|Db-|D-|B--|Gb-|Gb-|A-|G-|Gb-|E-|D-|Gb-|E-|D-|Db-",2.5f),
        new Song("I Can't Fix You", "F|F|F|C|G|E|C|Bb-|Ab-|C|Ab-|C|C|C|Bb-|Ab-|Bb-|C|Bb-|Ab-|F-|Ab-|Ab-|Ab-|Ab-|Ab-|Bb-|Ab-|G-|C|Eb|Bb-|Ab-|F|F|F|C|G|E|C|Bb-|Ab-|C|Ab-|C|C|C|Bb-|Ab-|Bb-|C|Bb-|Ab-|F-|Ab-|Ab-|Ab-|Ab-|Ab-|Bb-|Ab-|G-|C|Eb|Bb-|Ab-|F|F|F|F|Ab-|Ab-|C|Eb|F|F|F|F|Eb|Bb-|C|Eb|F|Ab|Bb|Ab|Ab-|C|Bb-|Ab-|Ab-|F-|Ab-|Bb-|C|Bb-|Ab-|Ab-|Eb|C", 2.5f),
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
        new SimonItem("Celeste",Methods.loadAudio($"{SSPath}Celeste"),null, new Color32(0, 255, 255, 255)),
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
            "loro","Trua trua"
        ),
        new Identify(
            new string[]
            {
                "elefante",
            },
            "Elefante","Bruuuuuu!"
        ),
        new Identify(
            new string[]{
                "caballo",
                "corcel",
                "potro",
            },
            "Caballo","Hiii!"
        ),
        new Identify(
            new string[]{
                "cerdo",
                "cochino",
                "puerco",
            },
            "Cerdo","Oink, oink"
        ),
        new Identify(
            new string[]{
                "mono",
                "primate",
                "simio",
                "macaco"
            },
            "Mono","Ua Ua"
        ),
        new Identify(
            new string[]{
                "serpiente",
                "culebra"
            },
            "Serpiente","Ssssssssss"
        ),
        new Identify(
            new string[]{
                "tigre",
            },
            "Tigre","Grrrrrr"
        )
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
        ),
        new Identify(
            new string[]
            {
                "aburrido",
                "aburrimiento",
            },
            "Aburrido"
        ),
        new Identify(
            new string[]
            {
                "amor",
                "cariño",
            },
            "Amor"
        ),
        new Identify(
            new string[]
            {
                "asco",
                "repugnancia",
                "repulsion",
                "grima",
                "desagrado"
            },
            "Asco"
        ),
        new Identify(
            new string[]
            {
                "asombro",
                "sorpresa",
                "fascinacion",
                "pasmo",
                "maravilla"
            },
            "Asombro"
        ),
        new Identify(
            new string[]
            {
                "calma",
                "relajo",
                "paz",
                "quietud",
                "tranquilidad",
                "calmado"
            },
            "Calma"
        ),
        new Identify(
            new string[]
            {
                "dolor",
                "mal",
                "daño",
                "adolorido"
            },
            "Dolor"
        ),
        new Identify(
            new string[]
            {
                "enojo",
                "rabia",
                "furia",
                "enojado",
                "furioso"
            },
            "Enojo"
        ),
        new Identify(
            new string[]
            {
                "envidia",
                "celos",
            },
            "Envidia"
        ),
        new Identify(
            new string[]
            {
                "flojera",
                "cansancio",
                "flojo",
            },
            "Flojera"
        ),
        new Identify(
            new string[]
            {
                "hambre",
                "hambriento",
                "apetito",
            },
            "Hambre"
        ),
        new Identify(
            new string[]
            {
                "miedo",
                "temor",
                "pavor",
                "espanto",
            },
            "Miedo"
        ),
    };

    static string personaPath = "Avatares/Persona ";

    public static List<Persona> personas = new List<Persona>()
    {
        new Persona(Methods.loadSprite($"{personaPath}(1)"),
                new string[]
                {
                    "Héroe / Heroína",
                    "Traje negro",
                    "Adulto/a",
                    "Máscara"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(2)"),
                new string[]
                {
                    "Piel blanca",
                    "Cabello rojo",
                    "Maquillaje",
                    "Cabello largo",
                    "Traje blanco",
                    "Adulto/a",
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(3)"),
                new string[]
                {
                    "Traje rojo",
                    "Espadachín / Espadachina",
                    "Adulto/a",
                    "Héroe / Heroína",
                    "Máscara"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(4)"),
                new string[]
                {
                    "Anciano/a",
                    "Piel blanca",
                    "Calvo/a",
                    "Arrugas",
                    "Cabello blanco",
                    "Traje a cuadros"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(5)"),
                new string[]
                {
                    "Anciano/a",
                    "Piel blanca",
                    "Cabello negro",
                    "Arrugas",
                    "Lentes",
                    "Pelo recogido",
                    "Traje azul"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(6)"),
                new string[]
                {
                    "Barba",
                    "Piel morena",
                    "Bigote",
                    "Cabello blanco",
                    "Adulto/a",
                    "Gorro",
                    "Traje azul"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(7)"),
                new string[]
                {
                    "Lentes",
                    "Piel blanca",
                    "Cabello castaño",
                    "Jóven",
                    "Traje negro"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(8)"),
                new string[]
                {
                    "Jóven",
                    "Piel morena",
                    "Cabello negro",
                    "Traje azul"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(9)"),
                new string[]
                {
                    "Cabello blanco",
                    "Adulto/a",
                    "Traje negro",
                    "Pelo corto",
                    "Maquillaje",
                    "Piel blanca"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(10)"),
                new string[]
                {
                    "Espadachín / Espadachina",
                    "Máscara",
                    "Traje negro",
                    "Piel blanca"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(11)"),
                new string[]
                {
                    "Piel morena",
                    "Traje azul",
                    "Gorro",
                    "Joyería",
                    "Cabello castaño",
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(12)"),
                new string[]
                {
                    "Lentes",
                    "Máscara",
                    "Traje negro",
                    "Piel blanca"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(13)"),
                new string[]
                {
                    "Barba",
                    "Bigote",
                    "Colas",
                    "Joyería",
                    "Traje negro",
                    "Piel morena",
                    "Pelo corto"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(14)"),
                new string[]
                {
                    "Héroe/Heroína",
                    "Traje rojo",
                    "Máscara",
                    "Jóven"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(15)"),
                new string[]
                {
                    "Anciano/a",
                    "Bigote",
                    "Pelo largo",
                    "Arrugas",
                    "Traje azul",
                    "Piel blanca",
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(16)"),
                new string[]
                {
                    "Adulto/a",
                    "Máscara",
                    "Piel blanca",
                    "Traje negro",
                    "Gorro"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(17)"),
                new string[]
                {
                    "Adulto/a",
                    "Traje marrón",
                    "Piel blanca",
                    "Cabello castaño",
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(19)"),
                new string[]
                {
                    "Adulto/a",
                    "Traje azul",
                    "Piel blanca",
                    "Calvo/a",
                    "Lentes"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(20)"),
                new string[]
                {
                    "Adulto/a",
                    "Traje verde",
                    "Piel blanca",
                    "Bigote",
                    "Cabello negro",
                    "Gorro"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(21)"),
                new string[]
                {
                    "Adulto/a",
                    "Barba",
                    "Bigote",
                    "Gorro",
                    "Piel morena",
                    "Joyería",
                    "Cabello corto",
                    "Traje azul",
                    "Cabello negro"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(22)"),
                new string[]
                {
                    "Adulto/a",
                    "Barba",
                    "Bigote",
                    "Piel morena",
                    "Traje azul",
                    "Traje a cuadros",
                    "Cabello negro"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(23)"),
                new string[]
                {
                    "Adulto/a",
                    "Barba",
                    "Bigote",
                    "Piel blanca",
                    "Traje azul",
                    "Traje a cuadros",
                    "Cabello negro"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(24)"),
                new string[]
                {
                    "Adulto/a",
                    "Piel blanca",
                    "Traje azul",
                    "Cabello verde",
                    "Cabello largo",
                    "Lentes",
                    "Traje rojo"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(25)"),
                new string[]
                {
                    "Jóven",
                    "Piel blanca",
                    "Cabello negro",
                    "Cabello largo",
                    "Joyería",
                    "Maquillaje",
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(26)"),
                new string[]
                {
                    "Piel blanca",
                    "Cabello negro",
                    "Cabello recogido",
                    "Traje marrón",
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(27)"),
                new string[]
                {
                    "Piel blanca",
                    "Cabello negro",
                    "Cabello corto",
                    "Lentes",
                    "Traje negro",
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(28)"),
                new string[]
                {
                    "Piel blanca",
                    "Cabello negro",
                    "Cabello corto",
                    "Lentes",
                    "Traje negro",
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(29)"),
                new string[]
                {
                    "Piel blanca",
                    "Cabello negro",
                    "Gorro",
                    "Traje blanco",
                    "Barba",
                    "Bigote",
                    "Adulto/a"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(30)"),
                new string[]
                {
                    "Piel blanca",
                    "Gorro",
                    "Traje verde",
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(31)"),
                new string[]
                {
                    "Piel blanca",
                    "Gorro",
                    "Traje blanco",
                    "Adulto/a"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(32)"),
                new string[]
                {
                    "Piel morena",
                    "Gorro",
                    "Máscara",
                    "Traje verde",
                    "Cabello negro",
                    "Adulto/a"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(33)"),
                new string[]
                {
                    "Piel morena",
                    "Traje azul",
                    "Cabello corto",
                    "Cabello negro",
                    "Presidente",
                    "Adulto/a"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(34)"),
                new string[]
                {
                    "Piel blanca",
                    "Traje gris",
                    "Máscara",
                    "Héroe / Heroína",
                    "Adulto/a"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(35)"),
                new string[]
                {
                    "Piel blanca",
                    "Futbolista",
                    "Traje rojo",
                    "Cabello corto",
                    "Cabello negro",
                    "Adulto/a"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(36)"),
                new string[]
                {
                    "Piel blanca",
                    "Futbolista",
                    "Traje azul",
                    "Cabello corto",
                    "Cabello negro",
                    "Adulto/a"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(37)"),
                new string[]
                {
                    "Piel morena",
                    "Futbolista",
                    "Bigote",
                    "Traje verde",
                    "Cabello corto",
                    "Cabello negro",
                    "Adulto/a"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(38)"),
                new string[]
                {
                    "Piel blanca",
                    "Bigote",
                    "Traje negro",
                    "Cabello corto",
                    "Cabello negro",
                    "Adulto/a"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(39)"),
                new string[]
                {
                    "Piel blanca",
                    "Bigote",
                    "Traje verde",
                    "Cabello corto",
                    "Adulto/a"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(40)"),
                new string[]
                {
                    "Piel blanca",
                    "Lentes",
                    "Bigote",
                    "Barba",
                    "Traje negro",
                    "Cabello corto",
                    "Adulto/a"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(41)"),
                new string[]
                {
                    "Piel blanca",
                    "Presidente",
                    "Cabello rubio",
                    "Traje azul",
                    "Adulto/a"
                }
        ),
        new Persona(Methods.loadSprite($"{personaPath}(42)"),
                new string[]
                {
                    "Piel blanca",
                    "Cabello largo",
                    "Cabello castaño",
                    "Traje rosado",
                    "Adulto/a"
                }
        ),

    };

    public static Dictionary<Intelligence,Sprite> IntelligenceSprites = new Dictionary<Intelligence, Sprite>(){
        {Intelligence.Math, Methods.loadSprite("1")},
        {Intelligence.Intrapersonal, Methods.loadSprite("2")},
        {Intelligence.Interpersonal, Methods.loadSprite("3")},
        {Intelligence.Naturalist, Methods.loadSprite("4")},
        {Intelligence.Spatial, Methods.loadSprite("5")},
        {Intelligence.Musical, Methods.loadSprite("6")},
        {Intelligence.CorporalKinesthetic, Methods.loadSprite("7")},
        {Intelligence.Language, Methods.loadSprite("8")},
    };

}
