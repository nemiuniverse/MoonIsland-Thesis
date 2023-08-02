using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour

{
    public Flowchart _flowchart;

    public void Start()
    {
        SaveData.Save();
    }

    public void NewGame()
    {
        Flags.FirstGame();
        SaveData.Save();
        _flowchart.SetStringVariable("Murderer", Flags.Murderer);
        _flowchart.ExecuteBlock("NewGame");
        SceneManager.LoadScene("Intro");
    }

    public void Load()
    {
        _flowchart.ExecuteBlock("Continue");
        var gd = SaveData.Load();
        Flags.OnLoad(gd);
        //SceneManager.LoadScene("MainSquare");
    }

    public void SaveInterrogations()
    {
        _flowchart.ExecuteBlock("Exit");
    }

    public void LoadMainSquare()
    {
        SceneManager.LoadScene("MainSquare");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void CharlesInterrogated()
    {
        Flags.CharlesInterrogated = true;
    }

    public void DeenaInterrogated()
    {
        Flags.DeenaInterrogated = true;
    }



}