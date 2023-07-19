using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int highScore;

    public GameData(int newScore)
    {
        highScore = newScore;
    }
}
