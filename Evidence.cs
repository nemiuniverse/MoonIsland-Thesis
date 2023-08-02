using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Evidence : MonoBehaviour
{
    public static Evidence[] DeenaEvidenceTaken;
    public static Evidence[] CharlesEvidenceTaken;

    public static Dictionary<string, Testimony> DeenaEvidenceQuestions;
    public static Dictionary<string, Testimony> CharlesEvidenceQuestions;
    public GameObject EvidenceCardPanel;
    public EvidenceCardScript EvidenceCardScript;
    public string EvidenceName;
    public string EvidenceDesc;
    public Sprite img;
    public bool taken;

    public Vector3 PositionInEquipment;
    public TextMeshProUGUI question;
    public TextMeshProUGUI answer;
    public TextMeshProUGUI mood;
    private CanvasGroup canvasGroup;
    private bool isDragging;
    private RectTransform rectTransform;


    private void Start()
    {
        DeenaEvidenceTaken = new Evidence[8];
        CharlesEvidenceTaken = new Evidence[8];
        //Flags.Murderer = "Deena";
        if (name == "loveletter" && Flags.Murderer != "Deena")
            gameObject.SetActive(false);
        if (name == "note" && Flags.Murderer != "Charles")
            gameObject.SetActive(false);
        taken = false;
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        rectTransform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;
        DeenaEvidenceQuestions = new Dictionary<string, Testimony>
        {
            {
                "lyrics",
                new Testimony("\"Enemy\". What is this song about? About any particular?",
                    "I was just experimenting with some rock sound. It came to my mind, lyrics shoud be like that. It's just imaginated thing. I'm not usually write about my life. This would be too personal. People wouldn't stop gossip about it.\r\nI mean this way they gossip too, but I'm sure it's not real and still getting the attention.\r\nWin-win situation. No one is hurt.",
                    "Deena seems a bit frustrated.")
            },
            {
                "demo",
                new Testimony("Is this your newest demo?",
                    "Yeah, I'm still working on it though. I kinda like it, but still it needs improvement.\n\nMy songs are always very personal, so I really hope it will be good for my fans.",
                    "Deena is smiling.")
            },
            {
                "photo",
                new Testimony("Is it you on the photo? You look different. Almost unrecognizable.",
                    "Yes, it's veeeery old photo. My music label made me change my appearance.\r\nTo look more Idol-ish and cute.\r\nAnd I love how I look right now.\r\nBlonde is much better for me than those dark hair.\r\nI'm more me than I was natural haha!",
                    "Deena seems awkward.")
            },
            {
                "idcard",
                new Testimony("It is your ID card, isn't it?",
                    "Oh... So you found it? Uhm yes. It's really old. From the times I was brunette.\r\nMy name? Uhm, yeah... My birth name is Beatrice Danielson. But I don't feel like it anymore. Deena Dove is my stage name, but it is who I am now. I'm more Deena then I ever was Beatrice. I associate badly with Beatrice.",
                    "Deena seems a bit frustrated")
            },
            {
                "plant",
                new Testimony("What is this plant?",
                    "Actually I don't know. I got this from my friend last month. It's pretty.", "Deena is calm.")
            },
            {
                "CDalbum",
                new Testimony("It's your album, right?",
                    "Yeah. \"All Around\" was released two years ago.\n\nI'm proud of this, but it's time for new music. My fans probably can't wait! \n\nI'm excited to even think about this.",
                    "Deena is smiling.")
            },
            {
                "deenasocialmedia",
                new Testimony("I see you disappeared for two years in social medias.",
                    "I had to, but I'm ok now. Ready to go!\r\nI hope people didn't forget me. I had most amazing fans ever.\r\nMy recent post didn't get that much likes, but it's only a matter of time.\r\n",
                    "Deena is embarassed.")
            }
        };
        CharlesEvidenceQuestions = new Dictionary<string, Testimony>
        {
            {
                "receipe",
                new Testimony("What is this bill for?",
                    "Well. I asked her for a dinner two days before... We run into each other, so it seemed to be appropriate.\r\nWe didn't have much contact, so my hope was that we both grew up and we could be friends.\r\nIt was short dinner which remind me of old times. Nice to see her happy. \r\n",
                    "Charles is calm, but a bit sad.")
            },
            {
                "plans",
                new Testimony("Are those plans for the new hotel or somewhere else?",
                    ".... FINE! I'll tell you, but it's top secret. This wasn't fully vacation.\r\nMy father sent me on the work trip to make some business under the pretext. We see opportunity, we catch it. We concider this island as a place for the new hotel.\r\nBut those are concideration, my job here was to do more research and do the talking stuff.\r\nAnd Hikari Hotels - what they got in the hotels and we can improve? Like I've said.",
                    "Charles is a bit frustrated.")
            },
            {
                "wounds",
                new Testimony("Why do you have those wounds?",
                    "I met Rena at the hotel restaurant once again, to thank her for the dinner. I gave her rose, so it's because of thorns.\r\nWe have been talking for like 5 minutes? And she had her plans, I had mine. I walked her out.",
                    "Charles is calm.")
            },
            {
                "pictures",
                new Testimony("Did Rena know things you wouldn't like everything to know about?",
                    "You're asking if she knew my dirty little secrets? Haha no. We had known each other long time ago.\r\nWe became completly different people. Old informations about me? Don't make me laugh.\r\nI know many significant facts I'm obligated to keep secret. Rena would be the last person to know about those.\r\nActually I've never trusted her that much, even when we were together.\r\n",
                    "Charles is amused.")
            },
            {
                "photoRena",
                new Testimony("You still have Rena's photo on your phone...",
                    "Yeah, it's the old phone. I haven't clean my gallery for a long time.", "Charles is frustrated.")
            },
            {
                "documents",
                new Testimony("Lots of documents for a holiday...", "Yeah, it may be a holiday-businness trip...",
                    "Charles is frustrated.")
            },
            {
                "blood",
                new Testimony("Is this... Blood?", "Yeah. But it's mine, I swear. I cut myself accidently.",
                    "Charles is anxious.")
            },
            {
                "note",
                new Testimony("Where did you get this note?",
                    "I... Got it delivered. I don't know. Many people hates me.", "Charles is a bit frustrated.")
            },
            { "wine", new Testimony("Is this a wine.", "Yeah. Wanna drink?", "Charles is smiling charmingly.") },
            {
                "bankaccount",
                new Testimony("Wow, this is a high number.", "I have a lot of money, thank you for notice.",
                    "Charles is calm.")
            }
        };
        if (Flags.Murderer == "Deena")
        {
            DeenaEvidenceQuestions.Add("loveletter",
                new Testimony("Do you have any personal relationship with your producer?",
                    "I... Why do you ask? No!\r\nWe... Might went out once or twice.\r\nBut it's a work thing. We talked about music. Only.",
                    "Deena is giggeling anxiously."));
            DeenaEvidenceQuestions.Add("pendrive",
                new Testimony("Is music from the pendrive yours?", "No. It's not my style really.",
                    "Deena seems irritated."));
        }
        else
        {
            DeenaEvidenceQuestions.Add("pendrive",
                new Testimony("Is music from the pendrive yours?",
                    "Hey, how did you get it? Yeah, it's my demo.\n\nI met Rena recently to ask her about making collab with me. A duo, it would kick ass every other song in the radio. \n\nI value her music and it would be great to work with her for once. But it won't happen due to... You know.\n\nI don't even know if she liked this song.",
                    "Deena is sad."));
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            var newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0f;

            transform.position = newPosition;
        }
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!taken)
            {
                EvidenceCardScript.SetEvidence(this);
                EvidenceCardPanel.SetActive(true);
            }
            else
            {
                isDragging = true;
                PositionInEquipment = transform.position;
            }
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            transform.position = PositionInEquipment;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name == "DeenaRoom")
        {
            if (DeenaEvidenceQuestions.ContainsKey(name))
            {
                question.text = "Question: " + DeenaEvidenceQuestions[name].Question;
                answer.text = DeenaEvidenceQuestions[name].Answer;
                mood.text = DeenaEvidenceQuestions[name].Mood;
                DeenaEvidenceQuestions[name].Asked = true;
                if (DeenaEvidenceQuestions["idcard"].Asked)
                    DeenaEvidenceQuestions["idcard"] = new Testimony(
                        "Is your aversion for birth name connected with the past?",
                        "I really don't like to talk about it... But yeah... I was bullied in the childhood and my name was part of this.\r\nWhen I started my music journey I've become another person. Then I took Deena Dove name. Almost no one knows me as Beatrice Danielson. That's all. Could we leave this topic now?",
                        "Deena seems uncomfortable.");
            }
        }
        else if (SceneManager.GetActiveScene().name == "CharlesRoom")
        {
            if (CharlesEvidenceQuestions.ContainsKey(name))
            {
                question.text = "Question: " + CharlesEvidenceQuestions[name].Question;
                answer.text = CharlesEvidenceQuestions[name].Answer;
                mood.text = CharlesEvidenceQuestions[name].Mood;
                CharlesEvidenceQuestions[name].Asked = true;
                if (CharlesEvidenceQuestions["note"].Asked)
                    CharlesEvidenceQuestions["note"] = new Testimony("Who do you think is an author of this?",
                        "I have no idea. Geez. It's just a piece of paper.", "Charles is anxious.");
            }
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