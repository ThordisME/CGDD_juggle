using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public int highScore;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }
}
