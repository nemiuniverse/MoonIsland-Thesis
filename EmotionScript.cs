using System.Collections;
using TMPro;
using UnityEngine;

public class EmotionScript : MonoBehaviour
{
    public TextMeshProUGUI mood;
    public TextMeshProUGUI testimony;
    private string previousClick;


    private void Start()
    {
        previousClick = "none";
    }

    public void ClickSuspiciousDeena()
    {
        if (mood.text.Contains("giggling") || mood.text.Contains("buddies") || mood.text.Contains("duper") ||
            mood.text.Contains("nervous") || mood.text.Contains("anxious") || mood.text.Contains("irritated"))
        {
            if (previousClick != testimony.text)
                Flags.DeenaSuspiciousReactionCount++;

            previousClick = testimony.text;
            StartCoroutine(ColorBlinkSuspicious());
        }
        else
        {
            if (previousClick != testimony.text)
                Flags.DeenaFalseAlarm++;

            previousClick = testimony.text;
        }
    }

    public void ClickSuspiciousCharles()
    {
        if (mood.text.Contains("raised his brow") || mood.text.Contains("frustrated") ||
            mood.text.Contains("disregardfully"))
        {
            if (previousClick != testimony.text)
                Flags.CharlesSuspiciousReactionCount++;

            previousClick = testimony.text;
            StartCoroutine(ColorBlinkSuspicious());
        }
        else
        {
            if (previousClick != testimony.text)
                Flags.CharlesFalseAlarm++;

            previousClick = testimony.text;
        }
    }

    private IEnumerator ColorBlinkSuspicious()
    {
        for (var x = 1; x <= 3; x++)
        {
            mood.color = Color.cyan;
            yield return new WaitForSeconds(0.2f);
        }

        mood.color = Color.white;
    }
}