public class GameDataLog
{
    public static void CreateGameDatas()
    {
        new GameData(
        GameType.Lives,
        "Cuenta en Romanos",
        "Tienes que transformar números de romans a arábigos y viceversa",
        "Roman",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Recuerda que 4 se escribe como IV",null)
                }
            )
        },
        "Transforma!",
        "3. Cuenta en romano"
     );
        new GameData(
            GameType.Lives,
            "Rey de las matemáticas",
            "Resuelve todas las operaciones en un límite de tiempo!",
            "Math King",
            new Dialogue[]
            {
                new Dialogue(
                    new Paragraph[]
                    {
                        new Paragraph("Recuerda que todas las divisiones resultan en números enteros!",null)
                    }
                )
            },
            "Resuelve",
            "4. El Rey de las Matemáticas"
         );
        new GameData(
        GameType.Lives,
        "Escoge el vaso",
        "Identifica cual vaso se llenará de agua primero!",
        "Water Glass",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Mantente atento con las tuberías que estén bloqueadas!",null)
                }
            )
        },
        "Escoge",
        "5. Escoge el vaso"
        );
        new GameData(
        GameType.Lives,
        "El ahorcado",
        "Trata de adivinar la palabra antes de que el dibujo se complete!",
        "HangingMan",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Descubrir la palabra se te hará más fácil si identificas las vocales",null)
                }
            )
        },
        "Adivina",
        "6. El Ahoracado"
        );
        new GameData(
        GameType.Lives,
        "Corrección de Errores",
        "Identifica todos los errores que estén en la frase y corrigelos",
        "Grammar Game",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Recuerda que los acentos son muy importantes al momento de diferenciar ciertas palabras",null),
                    new Paragraph("Por ende, recuerda siempre colocarlos adecuadamente",ViviSprites.GetSprite(ViviSprite.Happy)),
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("¡Ten en cuenta la diferencia de hay, ay y ahí!",null),
                    new Paragraph("Muchas veces nos podemos equivocar con estas opciones",null)
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Procura abrir y cerrar los signos de exclamación y los signos de interrogación!", null),
                    new Paragraph("¿Lo notaste?",null),
                    new Paragraph("Que pena...",null)
                }
            )
        },
        "Corrige",
        "7. Corrección de errores"
        );
        new GameData(
        GameType.Lives,
        "Encestalo",
        "Logra obtener la puntuación deseada antes de que te quedes sin balones!",
        "Dunk It",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Si deslizas hacia abajo la pelota rebotará",null),
                    new Paragraph("Si lo repites, rebotará cada vez más alto y puede que logres encestar con un pequeño empujón",null)
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Recuerda que mientras más lejos esté el aro, más puntos te puede dar",null),
                    new Paragraph("Aunque claro, eso puede llegar a ser más arriesgado",null),
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Evita golpear por los costados los aros que tengas muy cerca",null),
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Puedes mover el balón hacia los lados si lo rebotas en esa dirección.",null),
                }
            ),
        },
        "Encesta",
        "8. Encéstalo"
        );
        new GameData(
        GameType.Lives,
        "Tiro Al Blanco",
        "Logra obtener la cantidad de puntos deseada antes de que te quedes sin dardos",
        "Target Shoot",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Mientras más lejos esté el blanco, su puntaje podrá llegar a doblarse en incluso triplicarse",null)
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Si no te quieres arriesgar mucho, lanza el dardo a los blancos más cercanos",null),
                }
            ),
        },
        "Lanza",
        "9. Tiro Al Blanco"
        );
        new GameData(
        GameType.Lives,
        "Memoria Musical",
        "Trata de repetir el patrón musical sin equivocarte",
        "MusicalMemory",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Puedes darte el tiempo que necesites para elegir la nota",null)
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Presta más atención a la última nota del patrón, ya que las demás no cambian a menos que sea un nuevo patrón.",null),
                }
            ),
        },
        "Repite"
        );
        new GameData(
        GameType.Lives,
        "Pianista Profesional",
        "Toca cada una de las teclas negras hasta completar la ronda",
        "Pianist",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Trata de no mantenerte en la parte más baja del tablero",null),
                    new Paragraph("Si lo haces, tendrás menos tiempo para reaccionar",null)
                }
            ),
        },
        "Toca"
        );
        new GameData(
        GameType.Lives,
        "Simon Dice Extremo",
        "Consigue seguir el patrón antes de que el tiempo acabe!",
        "ExtremeSS",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Recuerda que no tienes que seguir ningún ritmo",null),
                    new Paragraph("Puedes presionar los botones lo más rápido que puedas",ViviSprites.GetSprite(ViviSprite.Happy))
                }
            ),
        },
        "Repite",
        "10. Simon Dice Extremo"
        );
        new GameData(
        GameType.Lives,
        "Sigue las Ordenes",
        "Debes de hacer la reaccionar a tiempo y copiar la pose del Hombre Pose",
        "DoThePose",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("No debes de confiarte de los patrones de la música",null),
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Algunas veces el hombre pose puede realizar una pose sinque la música suene, ten cuidado",ViviSprites.GetSprite(ViviSprite.Dizzy)),
                }
            ),
        },
        "Reacciona"
        );

    }
}
