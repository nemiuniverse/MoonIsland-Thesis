using UnityEngine;
using UnityEngine.UI;

public class ReguralQuestionsScript : MonoBehaviour
{
    public Button Q1;
    public Button Q2;
    public Button Q3;

    public Button Q4;

    // Start is called before the first frame update
    private void Start()
    {
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

        public string Question { get; set; }
        public string Answer { get; set; }
        public string Mood { get; set; }
        public bool Asked { get; set; }
    }
}