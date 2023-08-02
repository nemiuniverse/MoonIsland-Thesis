using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CustomQuestionScriptDeena : MonoBehaviour
{
    public static Testimony[] testimonies;
    public TextMeshProUGUI currentTestimony;
    public TextMeshProUGUI currentMood;
    public TextMeshProUGUI currentQuestion;
    public TMP_InputField questionInput;
    private Dictionary<string, int> keywords;

    private void Start()
    {
        keywords = new Dictionary<string, int>
        {
            { "jane", 0 },
            { "mccan", 0 },
            { "dead-eyed", 0 },
            { "rogue", 0 },
            { "max", 1 },
            { "maximilian", 1 },
            { "maximillian", 1 },
            { "foster", 1 },
            { "sailor", 1 },
            { "cleaner", 1 },
            { "charles", 2 },
            { "charlie", 2 },
            { "fitzgerald", 2 },
            { "businessmann", 2 },
            { "rena", 3 },
            { "hikari", 3 },
            { "victim", 3 }
        };
        testimonies = new Testimony[10];
        testimonies[0] = new Testimony("Do you know Jane McCan?",
            "No, not really. I've never met her. \nWell, probably, because I meet so much people because of my fame...",
            "Deena is calm.");
        testimonies[1] = new Testimony("Do you know Maximillian Foster?",
            "No, not really. I've never met him. \nWell, probably, because I meet so much people because of my fame...",
            "Deena is calm.");
        testimonies[2] = new Testimony("Do you know Charles Fitzgerald?",
            "Yes, I met him on a few music awards galas, but we never spoke. Rena knew him pretty well though. Mildly speaking. She was obsessed and extremly in love with him, but he seemed to have more interest in other girls. Once I saw them arguing, but I left them. I've only heard the words 'I know your secrets. I bet you regret telling me, Charlie'. \nAnd I knew they were a couple in the past. Rena liked to talk about him. She definitely wanted him back.",
            "Deena is calm.");
        testimonies[3] = new Testimony("Did you know Rena Hikari well?",
            "We worked under the same label, so we met many times. Mostly breath encounters in the studio. \nI didn't know her like best friends or something. I still can't believe what has happened. But it was not so unexpected also.\nRena was either loved or hated, so she had fans and enemies.",
            "Deena doesn't show her emotions now. She's very calm.");


        //doda� property �e zadane pytanie true/false i jak b�dzie false to wtedy kolejne np albo �e nie mo�na ju� zada�
    }

    private void AskQuestion(int idx)
    {
        currentTestimony.text = testimonies[idx].Answer;
        currentQuestion.text = "Question: " + testimonies[idx].Question;
        currentMood.text = testimonies[idx].Mood;
        testimonies[idx].Asked = true;
    }

    public void SearchForQuestion()
    {
        var line = questionInput.GetComponent<TMP_InputField>().text;
        line.ToLower();
        char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
        var words = line.Split(delimiterChars);

        foreach (var word in words)
            if (keywords.Keys.Contains(word))
            {
                AskQuestion(keywords[word]);
            }
            else
            {
                currentTestimony.text =
                    "Err... I'm afraid I can't tell anything about that... I don't know what you mean.";
                currentQuestion.text = "Question: " + questionInput.text;
                currentMood.text = "Deena is confused.";
            }
    }

    public class Testimony
    {
        public Testimony(string question, string answer, string mood)
        {
            Question = question;
            Answer = answer;
            Mood = mood;
            Asked = false;
        }

        public string Question { get; set; }
        public string Answer { get; set; }
        public string Mood { get; set; }
        public bool Asked { get; set; }
    }
}