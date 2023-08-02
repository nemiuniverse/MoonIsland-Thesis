using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CustomQuestionScriptCharles : MonoBehaviour
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
            { "deena", 2 },
            { "dove", 2 },
            { "beatrice", 2 },
            { "danielson", 2 },
            { "rena", 3 },
            { "hikari", 3 },
            { "victim", 3 }
        };
        testimonies = new Testimony[10];
        testimonies[0] = new Testimony("Do you know Jane McCan?", "No. Never met her.\r\n", "Charles is calm.");
        testimonies[1] = new Testimony("Do you know Maximillian Foster?",
            "No. But... Isn't is a cleaner? I talked to him on the hotel lobby. I remembered his name, because it's similar to one of the investors\r\nWhy do you ask? He found the body or what?\r\n",
            "Charles is calm.");
        if (Flags.Murderer == "Deena")
            testimonies[2] = new Testimony("Do you know Deena Dove? Fitzgerald?",
                "This pop star? Of course. She was under one label with Rena. But I don't think they were friends.\r\nThey were rivals. Always fighting for everything. Popularity among fans, best music... Everything.",
                "Charles is calm.");
        else
            testimonies[2] = new Testimony("Do you know Deena Dove? Fitzgerald?",
                "This pop star? Of course. She was under one label with Rena. But I don't think they were friends.\r\nI don't know what were relations between them. I saw Deena only on music awards galas. That's all.\r\n",
                "Charles is calm.");
        testimonies[3] = new Testimony("Did you know Rena Hikari well?",
            "I knew her at some point. But it was long ago. When we were young and beautiful haha. She has always was a bit crazy.\r\nAnyway we dated for some time. Nothing serious. I was a rebellious guy. Liked to break the rules.\r\nMy father didn't liked it, so it was my motivation for doing that. I wanted to piss him off.\r\nI sometimes was meeting her at the galas or something similar, but it was just polite saying 'Hello'.",
            "Charles is calm.");
    }

    private void Update()
    {
        if (testimonies[3].Asked)
            testimonies[3] = new Testimony("Did Rena wanted you back?",
                "As a friend, not as a lover. She wanted to have positive relations despite our competiting business. Me too.\r\nBut boyfriend? Partner? She knew I'm not suitable for that. She's not that stupid.\r\nAnd she didn't need me. She was successful on her own. I respect that a lot.",
                "Charles is calm.");
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
                currentTestimony.text = "I have no idea, what you are talking about.";
                currentQuestion.text = "Question: " + questionInput.text;
                currentMood.text = "Charles is confused.";
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