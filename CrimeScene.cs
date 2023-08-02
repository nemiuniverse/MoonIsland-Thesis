using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrimeScene : MonoBehaviour
{
    public TextMeshProUGUI desc;
    public Image image;
    public string eDesc;
    public Sprite eImg;
    public GameObject CardPanel;
    public string eName;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowReport();
            if (eName == "renasocialmedia")
                Flags.RenaSocialMedia = true;
            if (eName == "magazine")
                Flags.DeenaRenaMagazineArticle = true;
        }
    }

    public void ShowReport()
    {
        desc.text = eDesc;
        image.sprite = eImg;
        CardPanel.SetActive(true);
    }

    public void SetActive()
    {
        SetActive();
    }
}