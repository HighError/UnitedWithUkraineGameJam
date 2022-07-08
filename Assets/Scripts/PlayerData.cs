using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [HideInInspector] public List<Hacker> HackerInfoData;
    [HideInInspector] public int LevelNumber;
    [HideInInspector] public int SabotageProcent;
    [HideInInspector] public int LoseProcent;
    [HideInInspector] public int CompletedMissionsCount;
    [HideInInspector] public int CurrentScore;
    [HideInInspector] public int MaxScore;
    [HideInInspector] public int MaxHackers;

    [HideInInspector] public List<Hacker.HackerStats> recrutHackerList;
    [HideInInspector] public List<Mission> CurrentMissions;

    [HideInInspector] public bool NoMusic;
    [HideInInspector] public bool NoSound;

    [HideInInspector] public City CurrentCity;
    [HideInInspector] public List<int> CurrentMissionsIds;

    [HideInInspector] public bool NewGameStarted;

    public void CreateNewData()
    {
        HackerInfoData = new List<Hacker>();
        CurrentMissions = new List<Mission>();
        recrutHackerList = new List<Hacker.HackerStats>();

        LevelNumber = 0;
        SabotageProcent = 0;
        LoseProcent = 0;
        CompletedMissionsCount = 0;
        CurrentScore = 0;
        MaxHackers = 4;
        NoMusic = false;
        NoSound = false;
        SetRandomCity();
        CurrentMissionsIds = new List<int>();
    }

    private void SetRandomCity()
    {
        if (CurrentCity == null)
            CurrentCity = GameManager.Instance.Cache.GetCity("Nyonbans");
        else
        {
            City newCity;
            do
            {
                newCity = GameManager.Instance.Cache.GetRandomCity();
            } while (newCity.Name == CurrentCity.Name);
            CurrentCity = newCity;
        }
        EventSystem.CallOnOverlayUpdateNeeded();
    }

    public void NextLevel()
    {
        EventSystem.CallOnWindowsCloseNeeded();
        CurrentMissionsIds.Clear();
        CurrentMissions.Clear();

        SetRandomCity();
        GameManager.Instance.InstantiateWindow("NextLevelWindow");

        foreach (var hacker in HackerInfoData)
            hacker.IsBusy = false;

        LevelNumber++;
        SabotageProcent = 0;
        LoseProcent = 0;

        if (CurrentCity.Debaf == Enums.CityDebafs.StartLoseProc)
            LoseProcent = 10;

        if (CurrentCity.Debaf != Enums.CityDebafs.NoNewHacker)
            MaxHackers += UnityEngine.Random.Range(1, 2);

        EventSystem.CallOnUpdateScoreNeeded();
    }

    public void EndGame()
    {
        CurrentCity = null;
        EventSystem.CallOnWindowsCloseNeeded();
        GameManager.Instance.InstantiateWindow("LoseWindow");
    }