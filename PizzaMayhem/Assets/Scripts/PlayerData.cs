using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int lives;

    public PlayerData(PizzaBoyController player)
    {
        lives = player.lives;
    }
}
