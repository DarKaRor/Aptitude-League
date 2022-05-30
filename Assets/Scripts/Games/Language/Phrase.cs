public enum Topic
{
    Nature,
    Countries,
    People,
    Videogames,
    TV,
    Activities
}

public class Phrase
{
    public string phrase;
    public Topic topic;

    public Phrase(string phrase, Topic topic)
    {
        this.phrase = phrase;
        this.topic = topic;
    }

    public string GetTopic() => Variables.definitions[topic];
}
