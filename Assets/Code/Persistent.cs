using Newtonsoft.Json;
using UnityEngine;

namespace Code {
    public static class Persistent {
        public static GameModeManager.GameMode gameMode {
            get => JsonConvert.DeserializeObject<GameModeManager.GameMode>(PlayerPrefs.GetString(nameof(gameMode)));
            set {
                PlayerPrefs.SetString(nameof(gameMode), JsonConvert.SerializeObject(value));
                PlayerPrefs.Save();
            }
        }

        public static LeftRight winner {
            get => JsonConvert.DeserializeObject<LeftRight>(PlayerPrefs.GetString(nameof(winner)));
            set {
                PlayerPrefs.SetString(nameof(winner), JsonConvert.SerializeObject(value));
                PlayerPrefs.Save();
            }
        }
    }
}
