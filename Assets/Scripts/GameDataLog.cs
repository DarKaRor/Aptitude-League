public class GameDataLog
{
    public static void CreateGameDatas()
    {
        new GameData(
        GameType.Lives,
        "Cuenta en Romanos",
        "Tienes que transformar n�meros de romans a ar�bigos y viceversa",
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
            "Rey de las matem�ticas",
            "Resuelve todas las operaciones en un l�mite de tiempo!",
            "Math King",
            new Dialogue[]
            {
                new Dialogue(
                    new Paragraph[]
                    {
                        new Paragraph("Recuerda que todas las divisiones resultan en n�meros enteros!",null)
                    }
                )
            },
            "Resuelve",
            "4. El Rey de las Matem�ticas"
         );
        new GameData(
        GameType.Lives,
        "Escoge el vaso",
        "Identifica cual vaso se llenar� de agua primero!",
        "Water Glass",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Mantente atento con las tuber�as que est�n bloqueadas!",null)
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
                    new Paragraph("Descubrir la palabra se te har� m�s f�cil si identificas las vocales",null)
                }
            )
        },
        "Adivina",
        "6. El Ahoracado"
        );
        new GameData(
        GameType.Lives,
        "Correcci�n de Errores",
        "Identifica todos los errores que est�n en la frase y corrigelos",
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
                    new Paragraph("�Ten en cuenta la diferencia de hay, ay y ah�!",null),
                    new Paragraph("Muchas veces nos podemos equivocar con estas opciones",null)
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Procura abrir y cerrar los signos de exclamaci�n y los signos de interrogaci�n!", null),
                    new Paragraph("�Lo notaste?",null),
                    new Paragraph("Que pena...",null)
                }
            )
        },
        "Corrige",
        "7. Correcci�n de errores"
        );
        new GameData(
        GameType.Lives,
        "Encestalo",
        "Logra obtener la puntuaci�n deseada antes de que te quedes sin balones!",
        "Dunk It",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Si deslizas hacia abajo la pelota rebotar�",null),
                    new Paragraph("Si lo repites, rebotar� cada vez m�s alto y puede que logres encestar con un peque�o empuj�n",null)
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Recuerda que mientras m�s lejos est� el aro, m�s puntos te puede dar",null),
                    new Paragraph("Aunque claro, eso puede llegar a ser m�s arriesgado",null),
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
                    new Paragraph("Puedes mover el bal�n hacia los lados si lo rebotas en esa direcci�n.",null),
                }
            ),
        },
        "Encesta",
        "8. Enc�stalo"
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
                    new Paragraph("Mientras m�s lejos est� el blanco, su puntaje podr� llegar a doblarse en incluso triplicarse",null)
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Si no te quieres arriesgar mucho, lanza el dardo a los blancos m�s cercanos",null),
                }
            ),
        },
        "Lanza",
        "9. Tiro Al Blanco"
        );
        new GameData(
        GameType.Lives,
        "Memoria Musical",
        "Trata de repetir el patr�n musical sin equivocarte",
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
                    new Paragraph("Presta m�s atenci�n a la �ltima nota del patr�n, ya que las dem�s no cambian a menos que sea un nuevo patr�n.",null),
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
                    new Paragraph("Trata de no mantenerte en la parte m�s baja del tablero",null),
                    new Paragraph("Si lo haces, tendr�s menos tiempo para reaccionar",null)
                }
            ),
        },
        "Toca"
        );
        new GameData(
        GameType.Lives,
        "Simon Dice Extremo",
        "Consigue seguir el patr�n antes de que el tiempo acabe!",
        "ExtremeSS",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Recuerda que no tienes que seguir ning�n ritmo",null),
                    new Paragraph("Puedes presionar los botones lo m�s r�pido que puedas",ViviSprites.GetSprite(ViviSprite.Happy))
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
                    new Paragraph("No debes de confiarte de los patrones de la m�sica",null),
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Algunas veces el hombre pose puede realizar una pose sinque la m�sica suene, ten cuidado",ViviSprites.GetSprite(ViviSprite.Dizzy)),
                }
            ),
        },
        "Reacciona"
        );

    }
}
