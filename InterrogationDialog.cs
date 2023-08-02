using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterrogationDialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public GameObject moreButton;
    public List<string> sentences;
    public float typingSpeed = 0.05f;
    public List<string> allKeyWords;
    private List<string> currentKeyWords;


    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(ShowDialogText());
    }

    public void ConvertToStringArray()
    {
        //do dopisania jak b�dzie decyzja w jakim formacie dialogi
    }

    private IEnumerator ShowDialogText()
    {
        foreach (var s in sentences)
        {
            foreach (var letter in s)
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

            yield return new WaitForSecondsRealtime(5);
            textDisplay.text = "";
        }
    }


/*zrobi� kod do wybor�w - pomi�dzy dialogami
 * czy dopytywanie w trakcie dialog�w czy po? - raczej w trakcie
 * mo�e u�y� Ink?
 */


    public void enableMoreButton(string s)
    {
        foreach (var key in allKeyWords)
            if (s.Contains(key))
            {
                moreButton.SetActive(true); //tutaj b�dzie popup z nowymi opcjami - mo�na dopyta� o co�
                currentKeyWords.Add(key);
            }
    }

    // update is called once per frame
    private void update()
    {
    }
}