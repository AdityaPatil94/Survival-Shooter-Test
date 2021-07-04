using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nightmare
{
    [System.Serializable]
    public class PlayerData
    {
        public Player PlayerDetails = new Player();

        public PlayerData(Player playerDetails)
        {
            PlayerDetails = playerDetails;
        }
    }

}
