public class GameDataLog
{
    public static void CreateGameDatas()
    {
        new GameData(
        GameType.Lives,
        Intelligence.Math,
        "2",
        "Cuenta en Romanos",
        "Tienes que transformar los números de romanos a arábigos y viceversa.",
        "Roman",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Leer un número en romano no es complicado.", ViviSprites.Explain1()),
                    new Paragraph("Pero debes tener en cuenta que a veces deberás transformar de romanos a arábigos y viceversa.", ViviSprites.Explain2()),
                }
            ),

            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("El número 4 siempre se lee como IV,", ViviSprites.Explain1()),
                    new Paragraph("es decir, el número cinco con un número uno en la parte delantera como si lo estuviese restando.", ViviSprites.Explain2()),
                }
            ),

            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("El número 9 se lee como IX, que es igual a 10 menos 1, ya que 10 se representa como X.", ViviSprites.Explain3()),
                }
            ),

            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("En caso que la letra X se coloque a la derecha de las letras L o C,", ViviSprites.Explain2()),
                    new Paragraph("entonces se suman a las cifras que estas letras representan. Como 60 que es LX u 80 que es LXXX.", ViviSprites.Explain1())
                }
            )
        },
        "¡Transforma!",
        "3. Cuenta en romano"
     );
        new GameData(
            GameType.Lives,
            Intelligence.Math,
            "3",
            "Rey de las matemáticas",
            "¡Resuelve todas las operaciones en un límite de tiempo!",
            "Math King",
            new Dialogue[]
            {
                new Dialogue(
                    new Paragraph[]
                    {
                        new Paragraph("Ten muy en cuenta que las divisiones que se te presenten siempre darán como resultados números enteros.", ViviSprites.Default())
                    }
                ),

                new Dialogue(
                    new Paragraph[]
                    {
                        new Paragraph("Debes recordar que en las restas, sí el número más grande es el negativo, entonces el resultado también es negativo.", ViviSprites.Explain3())
                    }
                ),

                new Dialogue(
                    new Paragraph[]
                    {
                        new Paragraph("Para saber el resultado de un número multiplicado por 11,", ViviSprites.Explain2()),
                        new Paragraph("debes realizar la suma de las dos cifras del primer número y ponemos el resultado en medio de las dos cifras. El número resultante es el valor del producto.", ViviSprites.Happy())
                    }
                ),

                new Dialogue(
                    new Paragraph[]
                    {
                        new Paragraph("A veces para calcular multiplicaciones de más de dos cifras nos puede servir multiplicarlos por un número más grande y luego dividir.", ViviSprites.Explain1()),
                        new Paragraph("Por ejemplo, 87 x 5 te puede resultar más fácil primero multiplicarlo por 10 y luego dividirlo entre 2.", ViviSprites.Explain3())
                    }
                )
            },
            "¡Resuelve!",
            "4. El Rey de las Matemáticas"
         );
        new GameData(
        GameType.Lives,
        Intelligence.Math,
        "4",
        "Escoge el vaso",
        "Identifica cuál vaso se llenará de agua primero.",
        "Water Glass",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("El vaso que se llena primero, por lo general es el que se encuentra más abajo de los demás.", ViviSprites.Explain1())
                }
            ),

            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Debes tener cuidado a la hora de elegir, hay algunas tuberías que están tapadas.", ViviSprites.Explain2()),
                    new Paragraph("Así que tómate tu tiempo en elegir.", ViviSprites.Happy())
                }
            ),

            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Muy rara vez el vaso que se llena primero es el 1, pero puede suceder.", ViviSprites.Explain1()),
                }
            )
        },
        "¡Escoge!",
        "5. Escoge el vaso",
        true
        );
        new GameData(
        GameType.Lives,
        Intelligence.Language,
        "5",
        "El ahorcado",
        "Trata de adivinar la palabra antes de que el dibujo se complete. Se te dará un tópico por cada palabra.",
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
        Intelligence.Language,
         "15",
        "Corrección de Errores",
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
                    new Paragraph("Ten en cuenta la diferencia de hay, ay y ahí!",null),
                    new Paragraph("Muchas veces nos podemos equivocar con estas opciones",null)
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Procura abrir y cerrar los signos de exclamación y los signos de interrogación!", null),
                    new Paragraph("Lo notaste?",null),
                    new Paragraph("Que pena...",null)
                }
            )
        },
        "Corrige",
        "7. Corrección de errores",
        true
        );
        new GameData(
        GameType.Lives,
        Intelligence.Spatial,
        "6",
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
        Intelligence.Spatial,
        "7",
        "Tiro Al Blanco",
        "Logra obtener la cantidad de puntos deseada antes de que te quedes sin dardos",
        "Target Shoot",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Mientras más lejos esté el blanco, su puntaje podrá llegar a doblarse e incluso triplicarse",null)
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
        Intelligence.Musical,
        "8",
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
        Intelligence.Musical,
        "9",
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
        "Toca",
        null,
        true
        );
        new GameData(
        GameType.Lives,
        Intelligence.CorporalKinesthetic,
        "10",
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
        "10. Simon Dice Extremo",
         true
        );
        new GameData(
        GameType.Lives,
        Intelligence.CorporalKinesthetic,
        "11",
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
                    new Paragraph("Algunas veces el hombre pose puede realizar una pose sinque la música suene, ten cuidado",ViviSprites.GetSprite(ViviSprite.Dizzy)),
                }
            ),
        },
        "Reacciona",
        null,
        true
        );
        new GameData(
        GameType.Lives,
        Intelligence.Naturalist,
        "12",
        "Limpia el laberinto",
        "Tienes que limpiar toda la basura que se encuentra en el laberinto antes de que se acabe el tiempo, en el camino puede que te encuentres objetos que te ayuden en tu tarea",
        "TrashCleaner",
        new Dialogue[]
        {
                    new Dialogue(
                        new Paragraph[]
                        {
                            new Paragraph("Tienes que recoger todas las bolsas de basura antes de que acabe el tiempo",null),
                            new Paragraph("Si logras recoger algunas bolsas de basura, el tiempo aumtentará permitiendote recoger más.",ViviSprites.GetSprite(ViviSprite.Happy)),
                        }
                    ),
                    new Dialogue(
                        new Paragraph[]
                        {
                           new Paragraph("La ventaja que hayas obtenido por algún objeto terminará aproximadamente en 10 segundos", ViviSprites.GetSprite(ViviSprite.Explain1))
                        }
                    ),
                    new Dialogue(
                        new Paragraph[]
                        {
                           new Paragraph("Si ya tienes un objeto, procura no utilizar otro del mismo tipo hasta que se te acabe el actual, de esa manera no lo desperdiciarás.", ViviSprites.GetSprite(ViviSprite.Explain1))
                        }
                    ),
        },
        "Limpia",
        "11. Limpia El Laberinto"
        );
        new GameData(
        GameType.Lives,
        Intelligence.Naturalist,
        "13",
        "Identifica El Animal",
        "Debes de escuchar atentamente al sonido que se te presente y escribir el nombre del animal correspondiente",
        "AnimalIdentify",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Puedes presionar el botón verde para volver a escuchar el audio",null),
                    new Paragraph("También puede que tenga otro sonido que no hayas escuchado",null)
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Nuestro idioma es muy grande, por lo que hay varias maneras de nombrar un animal.", ViviSprites.GetSprite(ViviSprite.Explain1)),
                    new Paragraph("Trata de nombrarlo de la manera más común, puede que no todas funcionen",null)
                }
            ),
        },
        "Identifica",
        "12. Identifica El Animal"
        );
        new GameData(
        GameType.Lives,
        Intelligence.Interpersonal,
        "14",
        "Identifica La Emoción",
        "Debes escribir el nombre de la emoción que se presenta en la imagen.",
        "EmotionIdentify",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Al momento de describir la imagen, no describas la acción que se observa.",null),
                    new Paragraph("Debes describir la emoción, o el sentimiento.",null),
                }
            ),
        },
        "Identifica",
        "13. Identifica La Emoción"
        );
        new GameData(
        GameType.Lives,
        Intelligence.Interpersonal,
        "1",
        "Todos Somos Iguales",
        "En este juego debes de comparar dos personas e identificar en qué se parecen. Esto es para que el jugador entienda que a pesar de nuestras diferencias, todos somos iguales.",
        "EveryoneIsTheSame",
        new Dialogue[]
        {
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Para algunos personajes puede que necesites conocer un poco de transfondo para saber cosas que no se muestran",null),
                    new Paragraph("Esto es generalmente para los héroes",null)
                }
            ),
            new Dialogue(
                new Paragraph[]
                {
                    new Paragraph("Mantente atento con detalles mínusculos. Una persona puede tener el cabello oculto, pero no sus cejas",null),
                    new Paragraph("Entonces se sabría el color de pelo",null)
                }
            ),
        },
        "Compara",
        "15. Todos Somos Iguales",
        true
        );
    }
}
