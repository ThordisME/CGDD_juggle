using UnityEngine;

public class BallsManager : MonoBehaviour
{

    public GameObject easyBall;
    public GameObject midBall;
    public GameObject hardBall;

    void Start() 
    {
        
    }

    void Update() 
    {

    }

    public void UpdateBalls(int difficulty)
    {
        easyBall.SetActive(false);
        midBall.SetActive(false);
        hardBall.SetActive(false);

        // could probably refactor
        switch (difficulty)
        {
            case 1:
                easyBall.SetActive(true);
                break;
            case 2:
                easyBall.SetActive(true);
                midBall.SetActive(true);
                break;
            case 3:
                easyBall.SetActive(true);
                midBall.SetActive(true);
                hardBall.SetActive(true);
                break;
            default:
                Debug.LogWarning("Invalid difficulty level: " + difficulty); // this won't happen, silly
                break;
        }
    }
}

