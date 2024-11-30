using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreLabel;
    public TMPro.TextMeshProUGUI highScoreLabel;

    void Update() 
    {
        scoreLabel.text = GameManager.instance.score.ToString();
        highScoreLabel.text = "High Score: " + GameManager.instance.highScore.ToString();
    }
}
