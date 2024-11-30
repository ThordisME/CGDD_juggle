using UnityEngine;
using UnityEngine.UI;

// onclick wasn't working great, decided to do this manually

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    public int difficulty;
    public Button easyButton;
    public Button midButton;
    public Button hardButton;

    public BallController ballController; // NOTE: passed in 'ball' for the ball controller, not ball 1 or 2
    public BallController ballController_2;
    public BallController ballController_3;


    public BallsManager ballsManager;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Preventing duplicates
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        easyButton.onClick.AddListener(() => SetDifficultyAndStartGame(1)); // Easy: 1 ball
        midButton.onClick.AddListener(() => SetDifficultyAndStartGame(2));  // Mid: 2 balls
        hardButton.onClick.AddListener(() => SetDifficultyAndStartGame(3)); // Hard: 3 balls
    }

    private void SetDifficultyAndStartGame(int chosen_difficulty)
    {
        difficulty = chosen_difficulty;
        ballsManager.UpdateBalls(difficulty);
        ballController.StartGame(true);
        ballController_2.StartGame(false);
        ballController_3.StartGame(false);
    }
}
