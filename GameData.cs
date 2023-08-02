using System;

[Serializable]
public class GameData
{
    public bool JaneInterrogated;
    public bool MaxInterrogated;
    public bool DeenaInterrogated;
    public bool CharlesInterrogated;

    public string Murderer;

    //Evidences: Deena FOUND
    public bool DeenaLyrics;
    public bool DeenaDemo;
    public bool DeenaOldPhoto;
    public bool DeenaLastAlbum;
    public bool DeenaSocialMedia;
    public bool BeatriceDanielsonID;
    public bool DeenaLoveLetter;
    public bool DeenaPendrive;

    public bool DeenaPlant;

    //Evidences: Charles FOUND
    public bool DinnerReceipe;
    public bool HotelPlans;
    public bool Wounds;
    public bool Pictures;
    public bool RenaPhoto;
    public bool Documents;
    public bool BloodDrops;
    public bool ThreateningNote;
    public bool Wine;
    public bool BankAccount;

    public bool DeenaRenaMagazineArticle;
    public bool RenaSocialMedia;

    //Mood count:
    public int DeenaSuspiciousReactionCount;
    public int DeenaFalseAlarm;
    public int CharlesSuspiciousReactionCount;
    public int CharlesFalseAlarm;

    public GameData()
    {
        JaneInterrogated = Flags.JaneInterrogated;
        MaxInterrogated = Flags.MaxInterrogated;
        DeenaInterrogated = Flags.DeenaInterrogated;
        CharlesInterrogated = Flags.CharlesInterrogated;
        Murderer = Flags.Murderer;

        DeenaLyrics = Flags.DeenaLyrics;
        DeenaDemo = Flags.DeenaDemo;
        DeenaOldPhoto = Flags.DeenaOldPhoto;
        DeenaLastAlbum = Flags.DeenaLastAlbum;
        DeenaSocialMedia = Flags.DeenaSocialMedia;
        BeatriceDanielsonID = Flags.BeatriceDanielsonID;
        DeenaLoveLetter = Flags.DeenaLoveLetter;
        DeenaPendrive = Flags.DeenaPendrive;
        DeenaPlant = Flags.DeenaPlant;

        DinnerReceipe = Flags.DinnerReceipe;
        HotelPlans = Flags.HotelPlans;
        Wounds = Flags.Wounds;
        Pictures = Flags.Pictures;
        RenaPhoto = Flags.RenaPhoto;
        Documents = Flags.Documents;
        BloodDrops = Flags.BloodDrops;
        ThreateningNote = Flags.ThreateningNote;
        Wine = Flags.Wine;
        BankAccount = Flags.BankAccount;

        DeenaRenaMagazineArticle = Flags.DeenaRenaMagazineArticle;
        RenaSocialMedia = Flags.RenaSocialMedia;
        DeenaSuspiciousReactionCount = Flags.DeenaSuspiciousReactionCount;
        DeenaFalseAlarm = Flags.DeenaFalseAlarm;
        CharlesFalseAlarm = Flags.CharlesFalseAlarm;
        CharlesSuspiciousReactionCount = Flags.CharlesSuspiciousReactionCount;
    }
}