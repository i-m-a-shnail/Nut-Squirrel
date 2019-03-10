using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProgress {

    public int coinsAmount;
    public int unlockedLevels;

    public PlayerProgress(Player player)
    {
        coinsAmount = player.coinsAmount;
    }
}
