using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegularQuestionsCharles : MonoBehaviour
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
    private Testimony[] testimoniesCharlesB1;
    private Testimony[] testimoniesCharlesB2;
    private Testimony[] testimoniesCharlesB3;
    private Testimony[] testimoniesCharlesB4;
    public GameObject endPanel;
    private void Start()
    {
        testimoniesCharlesB1 = new Testimony[5];
        testimoniesCharlesB2 = new Testimony[3];
        testimoniesCharlesB3 = new Testimony[3];
        testimoniesCharlesB4 = new Testimony[5];
        testimoniesCharlesB1[0] = new Testimony("Who are you?",
            "My name is Charles Fitzgerald. My friends usually calls me Charlie.\r\nI'm 31. I'm a businessman in my family business, which are mainly hotels.",
            "Charles is calm.");
        testimoniesCharlesB1[0] = new Testimony("Can I see your ID card?",
            "Sure, here it is.\r\n(Everything is correct.)\r\n", "Charles is calm.");
        testimoniesCharlesB1[1] = new Testimony("What are you doing here on the Moon Island?",
            "Just some vacations. I needed some rest. \r\nAs you can see, Hikari Hotel is the best for now here.\r\n",
            "Charles raised his brow.");
        testimoniesCharlesB1[2] = new Testimony("Is this journey anyhow connected to your hotels?",
            "Not really. Sure, I've done some research including checking out this hotel, but it's something I do everywhere.\r\nI'm a worcaholic, can't help it.",
            "Charles is nervously smiling.");
        testimoniesCharlesB1[3] = new Testimony("Best hotel 'for now', so you think there can be better?",
            "You never know. There is a lot of places and still can be many new ones.\r\nWe don't know what will happen in a few years.\r\nIf anyone has a good business plan, it can work.",
            "Charles is calm and relaxed.");
        testimoniesCharlesB1[4] = new Testimony("Are you here alone?",
            "Yes, my father didn't have time to come here.\r\nI'm his representative here.\r\n", "Charles is calm.");
        testimoniesCharlesB2[0] = new Testimony(
            "Do you think Hikari Hotel here can gain bad reputation after the murderer?",
            "Haha I wish. This is luxurious empire and one incident doesn't change that.\r\nThey still are a significant opponent on the hotel market.",
            "Charles is calm.");
        testimoniesCharlesB2[1] = new Testimony("Do you think Hikari Hotels are a threat for Fitzgerald Hotel Empire?",
            "Someway yes - we're rivals. We compete for customers attention. We compete to be the best.\r\nBut at the same time no. We are a brand, they are a brand. We're still one of the biggest hotel chain.\r\nThe rest are just details.",
            "Charles smiles dismissively.");
        testimoniesCharlesB2[2] = new Testimony("Have you ever thought about cooperation with Hikari Hotels?",
            "Absolutely not. It isn't something that might happen.", "Charles is determined.");
        testimoniesCharlesB3[0] = new Testimony("What happened that night?",
            "I was here - in the Hikari Hotel. When I've heared that Rena is in the hotel restaurant, I decided to came to see her and say hi.\r\nDue to old times. She was perfectly fine then. And that's all. Later I was in the hotel bar, drinking wine. I wasn't in her mansion if you ask.",
            "Charles is calm.");
        testimoniesCharlesB3[2] = new Testimony("What happened later?",
            "After all I'm glad that he did that. We came to some king of agreement.\r\nNot perfect, but better. Much better. And then I started to work for him. I've became the heir he has always wanted. What a redemption, huh?\r\nNow I care about family business no less than my father.",
            "It seems to be bitterly for Charles, but he's still calm.");
        testimoniesCharlesB3[1] = new Testimony("What are your relations with your father?",
            "Well, it's wasn't good. I was a tough kid and it was getting worse and worse. \r\nFather always got me out of troubles, but complain about it. He's rather strict\r\nOnly about good name of the family and press counts for him.\r\nAfter some clashes with the police, father sent me to a bording school.\r\nI was furious, but in the end I've made some friends. We still keep in touch. They get me, you know?",
            "Charles is a bit dreamy.");
        testimoniesCharlesB4[0] = new Testimony("Do you have a partner right now?",
            "Is this a criminal invastigation or P R I V A T E investigation? Haha\r\nNo, I'm single. Fully single. I'm dating some women from time to time. Quite frequently actually.\r\nBut I don't have any serious relationships. As you can see, something remains from my rebellious years.",
            "Charles is amused.");
        testimoniesCharlesB4[1] = new Testimony("Wanna drink wine with me?", "Oh... Surely. If you insist.",
            "Charles smiles flirtously.");


        count1 = 0;
        count2 = 0;
        count3 = 0;
        count4 = -1;
        buttonTxt1.text = testimoniesCharlesB1[count1].Question;
        buttonTxt2.text = testimoniesCharlesB2[count2].Question;
        buttonTxt3.text = testimoniesCharlesB3[count3].Question;
        buttonTxt4.text = "";
        currentButton4.enabled = false;
        
    }
    void Update()
    {


        if (Flags.Wine && testimoniesCharlesB3[2].Asked&&testimoniesCharlesB4[0].Asked==false)
        {
            count4 = 0;
            buttonTxt4.text = testimoniesCharlesB4[count4].Question;
            currentButton4.enabled = true;
        }

        
    }

    public void ClickButton1()
    {
        AskQuestion(testimoniesCharlesB1[count1]);
        if (count1 < 4)
        {
            count1++;
            if (count1 <= 4)
                buttonTxt1.text = testimoniesCharlesB1[count1].Question;
            else
                buttonTxt1.text = "";
        }
        else if (count1 >= 4)
        {
            buttonTxt1.text = "";
            currentButton1.enabled = false;
        }
    }

    public void ClickButton2()
    {
        AskQuestion(testimoniesCharlesB2[count2]);
        if (count2 < 3)
        {
            count2++;
            if (count2 <= 2)
                buttonTxt2.text = testimoniesCharlesB2[count2].Question;
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
        AskQuestion(testimoniesCharlesB3[count3]);
        if (count3 < 3)
        {
            count3++;
            if (count3 <= 2)
                buttonTxt3.text = testimoniesCharlesB3[count3].Question;
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
            AskQuestion(testimoniesCharlesB4[count4]);
            count4 = 1;
            buttonTxt4.text = testimoniesCharlesB4[count4].Question;
        }
        else if (count4 == 1)
        {

            AskQuestion(testimoniesCharlesB4[count4]);
            buttonTxt4.text = "";
            currentButton4.enabled = false;
            count4++;
            if (Flags.Murderer == "Charles")
            {
                endPanel.SetActive(true);
            }
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