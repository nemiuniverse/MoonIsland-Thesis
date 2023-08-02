using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EvidenceCardScript : MonoBehaviour
{
    public TextMeshProUGUI tip;
    public TextMeshProUGUI desc;
    public Image image;
    public Button Yes;
    public string Who;
    private Evidence evidence;
    private int itemsLeft;
    private int LastEmpty;

    private Vector3[] SlotPosition;

    // Start is called before the first frame update
    private void Start()
    {
        itemsLeft = 8;
        tip.text = "Do you want to keep the evidence? \n\nYou have " + itemsLeft +
                   " places left in your case file. \n\nRemember, once you take it, you cannot undone it!";
        LastEmpty = 0;
        SlotPosition = new Vector3[8];
        SlotPosition[0] = new Vector3(1.64f, -4.47556f);
        SlotPosition[1] = new Vector3(2.56f, -4.47556f);
        SlotPosition[2] = new Vector3(3.49f, -4.47556f);
        SlotPosition[3] = new Vector3(4.44f, -4.47556f);
        SlotPosition[4] = new Vector3(5.4f, -4.47556f);
        SlotPosition[5] = new Vector3(6.37f, -4.47556f);
        SlotPosition[6] = new Vector3(7.32f, -4.47556f);
        SlotPosition[7] = new Vector3(8.27f, -4.47556f);
    }

    public void SetActive()
    {
        SetActive();
    }

    public void SetEvidence(Sprite img, string txt)
    {
        image.sprite = img;
        desc.text = txt;
    }

    private void UpdateTip()
    {
        tip.text = "Do you want to keep the evidence? You have " + itemsLeft +
                   " places left in your case file. \n\nRemember, once you take it, you cannot undone it!";
    }

    public void SetEvidence(Evidence gameObject)
    {
        evidence = gameObject;
        image.sprite = gameObject.img;
        desc.text = gameObject.EvidenceDesc;
    }

    public void SetImage(Sprite image)
    {
        this.image.sprite = image;
    }

    public void SetDesc(string desc)
    {
        this.desc.text = desc;
    }

    public void CollectEvidence()
    {
        if (itemsLeft <= 0)
        {
            tip.text = "All slots are taken.";
            Yes.enabled = false;
            Yes.interactable = false;
        }
        else
        {
            UpdateFlags();
            itemsLeft--;
            UpdateTip();
            if (SceneManager.GetActiveScene().name == "DeenaRoom")
                Evidence.DeenaEvidenceTaken[LastEmpty] = evidence;
            else if (SceneManager.GetActiveScene().name == "CharlesRoom")
                Evidence.CharlesEvidenceTaken[LastEmpty] = evidence;
            evidence.transform.position = SlotPosition[LastEmpty];
            evidence.PositionInEquipment = SlotPosition[LastEmpty];
            LastEmpty++;
            evidence.taken = true;
            Debug.Log(Flags.DeenaDemo);
        }
    }

    public void UpdateFlags()
    {
        if (evidence.EvidenceName == "lyrics")
            Flags.DeenaLyrics = true;
        if (evidence.EvidenceName == "photo")
            Flags.DeenaOldPhoto = true;
        if (evidence.EvidenceName == "demo")
            Flags.DeenaDemo = true;
        if (evidence.EvidenceName == "idcard")
            Flags.BeatriceDanielsonID = true;
        if (evidence.EvidenceName == "plant")
            Flags.DeenaPlant = true;
        if (evidence.EvidenceName == "CDalbum")
            Flags.DeenaLastAlbum = true;
        if (evidence.EvidenceName == "deenasocialmedia")
            Flags.DeenaSocialMedia = true;
        if (evidence.EvidenceName == "loveletter")
            Flags.DeenaLoveLetter = true;
        if (evidence.EvidenceName == "pendrive")
            Flags.DeenaPendrive = true;
        if (evidence.EvidenceName == "receipe")
            Flags.DinnerReceipe = true;
        if (evidence.EvidenceName == "plans")
            Flags.HotelPlans = true;
        if (evidence.EvidenceName == "wounds")
            Flags.Wounds = true;
        if (evidence.EvidenceName == "pictures")
            Flags.Pictures = true;
        if (evidence.EvidenceName == "photoRena")
            Flags.RenaPhoto = true;
        if (evidence.EvidenceName == "documents")
            Flags.Documents = true;
        if (evidence.EvidenceName == "blood")
            Flags.BloodDrops = true;
        if (evidence.EvidenceName == "note")
            Flags.ThreateningNote = true;
        if (evidence.EvidenceName == "wine")
            Flags.Wine = true;
        if (evidence.EvidenceName == "bankaccount")
            Flags.BankAccount = true;
    }
}