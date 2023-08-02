using UnityEngine;

public class Testimony : MonoBehaviour
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