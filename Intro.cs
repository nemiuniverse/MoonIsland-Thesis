using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public float textSpeed;
    public string NextScene;
    public AudioSource phonecall;
    public AudioSource hangup;
    public GameObject toActivate;
    private int idx;

    private readonly string[] Telephone = new string[10];

    // Start is called before the first frame update
    private void Start()
    {
        Telephone[0] =
            "(You are detective Nova Morgan, a lone wolf in the detective world. When you pick up the phone, you hear male, hoarse voice)";
        Telephone[1] =
            "- Hello? Mrs Morgan, It's government's Safety Department. There was an incident on the Moon Island.";
        Telephone[2] =
            "- Miss Rena Hikari was found dead in her apartment on the island. She was an heir of Hikari Hotels.";
        Telephone[3] =
            "- We're certain that it was a murder. But it's a fresh case, so we have to find evidences for that.";
        Telephone[4] =
            "- We would like to use your help with the investigation. Please visit the crime scene and interrogate the suspects.";
        Telephone[5] =
            "- Surely, If we use your services, we would find the murderer sooner. We highly appretiate you deduction skills.";
        Telephone[6] = "- I know, that the police's homicides department was also sent to the Moon Island.";
        Telephone[7] =
            "- I would be careful with all the informations collected, because it might lead to the misunderstandings.";
        Telephone[8] = "- Inform me about every detail, please. We have to know everything FIRST.";
        Telephone[9] = "- Let's keep in touch, Mrs Morgan.";
        txt.text = string.Empty;
        idx = -1;
        phonecall.Play(0);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !toActivate.activeSelf)
        {
            if (idx == 11) SceneManager.LoadScene(NextScene);
            if (idx == -1)
            {
                phonecall.Stop();
                idx++;
                StartCoroutine(Line());
            }

            if (txt.text == Telephone[idx])
            {
                Next();
            }
            else
            {
                StopAllCoroutines();
                txt.text = Telephone[idx];
            }
        }
    }


    private IEnumerator Line()
    {
        foreach (var c in Telephone[idx])
        {
            txt.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private IEnumerator LastLine()
    {
        double parameter = 0.005f;
        double count = 0f;
        float number = 0;
        var next = textSpeed / 2;
        var line = "You are now heading to the Moon Island to start this investigation...";
        foreach (var c in line)
        {
            number++;
            if (number > line.Length * 0.7)
            {
                count++;
                next = (float)(textSpeed + parameter * count);
            }

            txt.text += c;
            yield return new WaitForSeconds(next);
        }
    }


    private void Next()
    {
        idx++;
        if (idx < Telephone.Length)
        {
            txt.text = string.Empty;
            StartCoroutine(Line());
        }
        else
        {
            txt.text = string.Empty;
            hangup.Play(0);
            idx++;

            //float delay = hangup.clip.length + 5f;
            StartCoroutine(LastLine());
            toActivate.SetActive(true);
            Invoke(nameof(LoadNextScene), 7);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(NextScene);
    }
}