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
        new GameData(
        GameType.Lives,
        "Limpia el laberinto",
        "Tienes que limpiar toda la basura que se encuentra en el laberinto antes de que se acabe el tiempo, en el camino puede que te encuentres objetos que te ayuden en tu tarea",
        "TrashCleaner",
        new Dialogue[]
        {
                    new Dialogue(
                        new Paragraph[]
                        {
                            new Paragraph("Tienes que recoger todas las bolsas de basura antes de que acabe el tiempo",null),
                            new Paragraph("Si logras recoger algunas bolsas de basura, el tiempo aumtentar� permitiendote recoger m�s.",ViviSprites.GetSprite(ViviSprite.Happy)),
                        }
                    ),
                    new Dialogue(
                        new Paragraph[]
                        {
                           new Paragraph("La ventaja que hayas obtenido por alg�n objeto terminar� aproximadamente en 10 segundos", ViviSprites.GetSprite(ViviSprite.Explain1))
                        }
                    ),
                    new Dialogue(
                        new Paragraph[]
                        {
                           new Paragraph("Si ya tienes un objeto, procura no utilizar otro del mismo tipo hasta que se te acabe el actual, de esa manera no lo desperdiciar�s.", ViviSprites.GetSprite(ViviSprite.Explain1))
                        }
                    ),
        },
        "Limpia",
        "11. Limpia El Laberinto"
        );
        new GameData(
        GameType.Lives,
        "Identifica El Animal",
        "Debes de escuchar atentamente al sonido que se te presente y escribir el nombre del animal correspondiente",
        "AnimalIdentify",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Puedes presionar el bot�n verde para volver a escuchar el audio",null),
                    new Paragraph("Tambi�n puede que tenga otro sonido que no hayas escuchado",null)
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Nuestro idioma es muy grande, por lo que hay varias maneras de nombrar un animal.", ViviSprites.GetSprite(ViviSprite.Explain1)),
                    new Paragraph("Trata de nombrarlo de la manera m�s com�n, puede que no todas funcionen",null)
                }
            ),
        },
        "Identifica"
        );
        new GameData(
        GameType.Lives,
        "Identifica La Emoci�n",
        "Debes escribir el nombre de la emoci�n que se presenta en la imagen.",
        "EmotionIdentify",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Al momento de describir la imagen, no describas la acci�n que se observa.",null),
                    new Paragraph("Debes describir la emoci�n, o el sentimiento.",null),
                }
            ),
        },
        "Identifica"
        );
    }
}
