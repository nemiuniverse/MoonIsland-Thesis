using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonQuestionsDeena : MonoBehaviour
{
    public TextMeshProUGUI currentTestimony;
    public TextMeshProUGUI currentMood;
    public TextMeshProUGUI currentQuestion;
    public Button currentButton1;
    public Button currentButton2;
    public Button currentButton3;
    public Button currentButton4;
    public TextMeshProUGUI buttonTxt1;
    public TextMeshProUGUI buttonTxt2;
    public TextMeshProUGUI buttonTxt3;
    public TextMeshProUGUI buttonTxt4;
    private int count1;
    private int count2;
    private int count3;
    private int count4;
    private Testimony[] testimoniesDeenaB1;
    private Testimony[] testimoniesDeenaB2;
    private Testimony[] testimoniesDeenaB3;
    private Testimony[] testimoniesDeenaB4;

    private void Start()
    {
        testimoniesDeenaB1 = new Testimony[4];
        testimoniesDeenaB2 = new Testimony[4];
        testimoniesDeenaB3 = new Testimony[4];
        testimoniesDeenaB1[0] = new Testimony("Who are you?",
            "I'm Deena Dove and I'm 26.\nI'm a pop-singer under FabulousBrand Label. I've released two albums so far.\n\nWhat else can I say? I'm kinda busy recently. Working on some stuff.\n\nBut feel free to ask me anything.",
            "Deena is kindly smiling.");
        testimoniesDeenaB1[1] = new Testimony("What are you doing here on the Moon Island?",
            "I came to the Island to work on my new album and to rest form the fame.\nPopularity has started to tire me. Whenever I appear on public, everyone screams. People are taking photos, touching me.\nI just wanted to make music, you know? Being Idol is just an addition. Don't get me wrong, I really love it.\nSometimes I just want be in a peaceful, calm place and reset my mind.",
            "Deena is calm.");
        testimoniesDeenaB1[2] = new Testimony("Can I see your ID card?",
            "Uhm I'm not sure where it is. You see, I'm a bit messy and forgetful.\n\nSorry. My friends always complain about it.\n\nBut I'm definitely me. Just look at any billboard or poster haha!",
            "Deena seems a bit nervous.");
        testimoniesDeenaB2[0] = new Testimony("When did your music career started?",
            "I had started when I was 13 with my YouTube covers. When I was 18 I released my first album.\n\"Teddy Bear\". Good times. I've became really popular then.\n\nI was a bit overwhelming, but I was still trying to do my best. I've been releasing album almost every year.\nThe recent one, \"All around\" was double platin! I'm proud!",
            "Deena is smiling.");
        testimoniesDeenaB2[1] = new Testimony("Your last album came up two years ago?",
            "Yes. I needed some vacations to come up with new ideas.\n\nAnd look! Here they are.",
            "Deena is smiling and giggeling.");
        testimoniesDeenaB2[2] = new Testimony("Do you like being adored by your fans?",
            "Yes, who wouldn't like that?\nThey tell me I'm the prettiest, funniest and so.\n\nMy fans are amazing. I missed them for those two years.",
            "Deena is delighted.");
        testimoniesDeenaB3[0] = new Testimony("What happened that night?",
            "I was working on the album and later I went for a walk.\nThat I returned to work on the album more.\n\nThat was easy question.",
            "Deena smiles.");
        testimoniesDeenaB3[1] = new Testimony(
            "When was the last time you saw Rena? Was it walk to her apartment that day?",
            "Yes... It was before her death and she was perfectly fine.\nI haven't seen anything suspicious.\n\nI gave her demo, told her about my idea and went to the studio.\nI swear I don't know what happened later.",
            "Deena is nervous and tries to be convincing.");
        testimoniesDeenaB3[2] = new Testimony("Do you have anything to add about recent unfortunate event?",
            "Actually... I'm a bit worried about staying here at this moment.\nI would never have guessed that it would to the person I know. Horrific.",
            "Deena seems uncomfortable.");
        testimoniesDeenaB4 = new Testimony[5];
        if (Flags.Murderer != "Deena")
        {
            testimoniesDeenaB4[0] = new Testimony("Was Rena your rival?",
                "Not in the serious way. Counting awards every Grammy? Yes. Nothing more.\r\nIt was just a motivation to be better and match Rena.\r\nI value her as a singer.\r\n",
                "Deena is determined");
            testimoniesDeenaB4[2] = new Testimony("Was Rena more popular than you?",
                "We were on the same level I think. Maybe except last two years.\r\nShe was constantly in the spotlights, when I'm preparing for the comeback.\r\nBut that's life. You can't have everything.\r\n",
                "Deena shruges.");
            testimoniesDeenaB4[1] = new Testimony("Was Rena treated better than you in the FabulousLabel?",
                "Not at all. They cared about me and Rena equally I think.\r\nFabulousLabel is one of the best. Surely they spoil their artists.\r\n",
                "Deena seems happy.");
        }
        else
        {
            testimoniesDeenaB4[0] = new Testimony("Was Rena your rival?",
                "Nooo, we're buddies. Like work-buddies.\n, I really liked Rena, she was amazing singer.\n, And my fans think that too!\n",
                "Deena is determined");
            testimoniesDeenaB4[2] = new Testimony("Was Rena more popular than you?",
                "(laugh) No! We are both super-duper popular!\n\nI have sooo much fans I must do double gigs on the tours!\n",
                "Deena is giggling.");
            testimoniesDeenaB4[1] = new Testimony("Was Rena treated better than you in the FabulousLabel?",
                "Not at all. They cared about me and Rena equally I think.\n\nFabulousLabel is one of the best. Surely they spoil their artists.\n\nAnd the producer really cares about me. \n\n...O-of course about Rena too! W-was...",
                "Deena is frustrately giggling.");
        }

        var empty = new Testimony("", "", "");
        testimoniesDeenaB1[3] = empty;
        testimoniesDeenaB2[3] = empty;
        testimoniesDeenaB3[3] = empty;

        count1 = 0;
        count2 = 0;
        count3 = 0;
        count4 = -1;
        buttonTxt1.text = testimoniesDeenaB1[count1].Question;
        buttonTxt2.text = testimoniesDeenaB2[count2].Question;
        buttonTxt3.text = testimoniesDeenaB3[count3].Question;
        buttonTxt4.text = "";
        currentButton4.enabled = false;
    }

    public void Update()
    {
        if (CustomQuestionScriptDeena.testimonies[3].Asked &&
            Flags.DeenaRenaMagazineArticle&&testimoniesDeenaB4[0].Asked==false) //question 3 was about Rena 
        {
            currentButton4.enabled = true;
            count4 = 0;
            buttonTxt4.text = testimoniesDeenaB4[count4].Question;
        }

        if (buttonTxt4.text == "" && Flags.DeenaSocialMedia && Flags.RenaSocialMedia &&
            CustomQuestionScriptDeena.testimonies[3].Asked)
        {
            count4 = 2;
            buttonTxt4.text = testimoniesDeenaB4[count4].Question;
        }
    }

    public void ClickButton1()
    {
        AskQuestion(testimoniesDeenaB1[count1]);
        if (count1 < 3)
        {
            count1++;
            if (count1 <= 2)
                buttonTxt1.text = testimoniesDeenaB1[count1].Question;
            else
                buttonTxt1.text = "";
        }
        else if (count1 >= 3)
        {
            currentButton1.enabled = false;
        }
    }

    public void ClickButton2()
    {
        AskQuestion(testimoniesDeenaB2[count2]);
        if (count2 < 3)
        {
            count2++;
            if (count2 <= 2)
                buttonTxt2.text = testimoniesDeenaB2[count2].Question;
            else
                buttonTxt2.text = "";
        }
        else if (count2 >= 3)
        {
            currentButton2.enabled = false;
        }
    }

    public void ClickButton3()
    {
        AskQuestion(testimoniesDeenaB3[count3]);
        if (count3 < 3)
        {
            count3++;
            if (count3 <= 2)
                buttonTxt3.text = testimoniesDeenaB3[count3].Question;
            else
                buttonTxt3.text = "";
        }
        else if (count3 >= 3)
        {
            currentButton3.enabled = false;
        }
    }

    public void ClickButton4()
    {
        if (count4 == 0)
        {
            AskQuestion(testimoniesDeenaB4[count4]);
            count4++;
            buttonTxt4.text = testimoniesDeenaB4[count4].Question;
        }

        if (count4 == 1)
        {
            AskQuestion(testimoniesDeenaB4[count4]);
            buttonTxt4.text = "";
            currentButton4.enabled = false;
        }

        if (count4 == 2)
        {
            AskQuestion(testimoniesDeenaB4[count4]);
            buttonTxt4.text = "";
            currentButton4.enabled = false;
        }
    }

    private void AskQuestion(Testimony t)
    {
        currentTestimony.text = t.Answer;
        currentQuestion.text = "Question: " + t.Question;
        currentMood.text = t.Mood;
        t.Asked = true;
    }

    private class Testimony
    {
        public Testimony(string question, string answer, string mood)
        {
            Question = question;
            Answer = answer;
            Mood = mood;
            Asked = false;
        }

        public string Question { get; }
        public string Answer { get; }
        public string Mood { get; }
        public bool Asked { get; set; }
    }
}