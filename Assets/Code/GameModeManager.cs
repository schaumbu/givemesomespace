using UnityEngine;

public class GameModeManager : MonoBehaviour {
    public enum GameMode {
        countdown,
        first1000,
        first5000,
        first10000
    }

    public GameMode mode;
// Start is called before the first frame update
    void Start() {
        mode = ChooseGameMode.crossSceneInformation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
