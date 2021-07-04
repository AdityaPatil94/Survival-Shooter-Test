using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nightmare
{
    public class DataCollector : MonoBehaviour
    {
        private Player PlayerDetails;
        public LevelManager levelManager;
        // Start is called before the first frame update
        void Start()
        {
            PlayerDetails = new Player();
            SaveProgress();
            //LoadProgress();
        }

      
        public void SaveProgress()
        {
            Debug.Log("SaveData");
            SetData();
            SaveSystem.SavePlayer(PlayerDetails);
        }

        public void LoadProgress()
        {
            PlayerData data = SaveSystem.LoadPlayer();
            GetData(data);
        }
        public void SetData()
        {
            PlayerDetails.Health = PlayerHealth.CurrentHealth;
            PlayerDetails.Score = ScoreManager.score;
            PlayerDetails.Grenades = GrenadeManager.grenades;
            PlayerDetails.Level = LevelManager.CurrentLevel;

            PlayerDetails.Position = new float[3];
            PlayerDetails.Position[0] = transform.position.x;
            PlayerDetails.Position[1] = transform.position.y;
            PlayerDetails.Position[2] = transform.position.z;
        }

        public void GetData(PlayerData data)
        {
            Debug.Log("Level -"+data.PlayerDetails.Level+ "Health -" + data.PlayerDetails.Health+ "Grenades -" + data.PlayerDetails.Grenades+ "Score -" + data.PlayerDetails.Score);
            //Debug.Log("Position -"+new Vector3(data.PlayerDetails.Position[0], data.PlayerDetails.Position[1], data.PlayerDetails.Position[2]));
            levelManager.LoadLevel(data.PlayerDetails.Level);
            PlayerHealth.CurrentHealth = data.PlayerDetails.Health;
            ScoreManager.score = data.PlayerDetails.Score;
            GrenadeManager.grenades = data.PlayerDetails.Grenades;
            LevelManager.PlayerRespawn = new Vector3(data.PlayerDetails.Position[0], data.PlayerDetails.Position[1], data.PlayerDetails.Position[2]);
            
        }
    }

}
