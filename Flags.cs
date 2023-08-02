using System;
using Random = UnityEngine.Random;

[Serializable]
public static class Flags
{
    private static string[] Suspects = { "Deena", "Charles", "Max", "Jane" };

    //Evidences: Deena FOUND
    public static bool DeenaLyrics;
    public static bool DeenaDemo;
    public static bool DeenaOldPhoto;
    public static bool DeenaLastAlbum;
    public static bool DeenaSocialMedia;
    public static bool BeatriceDanielsonID;
    public static bool DeenaLoveLetter;
    public static bool DeenaPendrive;

    public static bool DeenaPlant;

    //Evidences: Charles FOUND
    public static bool DinnerReceipe;
    public static bool HotelPlans;
    public static bool Wounds;
    public static bool Pictures;
    public static bool RenaPhoto;
    public static bool Documents;
    public static bool BloodDrops;
    public static bool ThreateningNote;
    public static bool Wine;
    public static bool BankAccount;

    public static bool DeenaRenaMagazineArticle;
    public static bool RenaSocialMedia;

    //Mood count:
    public static int DeenaSuspiciousReactionCount;
    public static int DeenaFalseAlarm;
    public static int CharlesSuspiciousReactionCount;
    public static int CharlesFalseAlarm;

    public static int Ending;
    public static float volume;
    public static bool DeenaInterrogated { get; set; }
    public static bool CharlesInterrogated { get; set; }
    public static bool MaxInterrogated { get; set; }
    public static bool JaneInterrogated { get; set; }
    public static string Murderer { get; set; }

    public static void OnLoad(GameData gd)
    {
        DeenaInterrogated = gd.DeenaInterrogated;
        CharlesInterrogated = gd.CharlesInterrogated;
        MaxInterrogated = gd.CharlesInterrogated;
        JaneInterrogated = gd.JaneInterrogated;
        Murderer = gd.Murderer;
        Ending = 4;

        DeenaLyrics = gd.DeenaLyrics;
        DeenaDemo = gd.DeenaDemo;
        DeenaOldPhoto = gd.DeenaOldPhoto;
        DeenaLastAlbum = gd.DeenaLastAlbum;
        DeenaSocialMedia = gd.DeenaSocialMedia;
        BeatriceDanielsonID = gd.BeatriceDanielsonID;
        DeenaLoveLetter = gd.DeenaLoveLetter;
        DeenaPendrive = gd.DeenaPendrive;
        DeenaPlant = gd.DeenaPlant;
        DinnerReceipe = gd.DinnerReceipe;
        HotelPlans = gd.HotelPlans;
        Wounds = gd.Wounds;
        Pictures = gd.Pictures;
        RenaPhoto = gd.RenaPhoto;
        Documents = gd.Documents;
        BloodDrops = gd.BloodDrops;
        ThreateningNote = gd.ThreateningNote;
        Wine = gd.Wine;
        BankAccount = gd.BankAccount;

        DeenaRenaMagazineArticle = gd.DeenaRenaMagazineArticle;
        RenaSocialMedia = gd.RenaSocialMedia;

        DeenaSuspiciousReactionCount = 0;
        DeenaFalseAlarm = 0;
        CharlesSuspiciousReactionCount = 0;
        CharlesFalseAlarm = 0;
    }

    public static void FirstGame()
    {
        DeenaInterrogated = false;
        CharlesInterrogated = false;
        MaxInterrogated = false;
        JaneInterrogated = false;
        Murderer = Suspects[Random.Range(0, Suspects.Length)];
        DeenaLyrics = false;
        DeenaDemo = false;
        DeenaOldPhoto = false;
        DeenaLastAlbum = false;
        DeenaSocialMedia = false;
        BeatriceDanielsonID = false;
        DeenaLoveLetter = false;
        DeenaPendrive = false;
        DeenaPlant = false;
        DinnerReceipe = false;
        HotelPlans = false;
        Wounds = false;
        Pictures = false;
        RenaPhoto = false;
        Documents = false;
        BloodDrops = false;
        ThreateningNote = false;
        Wine = false;
        BankAccount = false;

        DeenaRenaMagazineArticle = false;
        RenaSocialMedia = false;
        Ending = 4;

        DeenaSuspiciousReactionCount = 0;
        DeenaFalseAlarm = 0;
        CharlesSuspiciousReactionCount = 0;
        CharlesFalseAlarm = 0;
    }
}