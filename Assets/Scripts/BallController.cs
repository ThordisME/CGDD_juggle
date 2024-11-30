using UnityEngine;

public class BallController : MonoBehaviour
{
    /*
    Controls the behavior of a specified ball.
    */

    public Rigidbody2D body;
    public Vector2 direction;
    public float impulse;
    public Vector2 levelBounds;
    Vector2 startPosition;
    public int currentHighScore; // because I made it so that the high score displayed gets updated with the current score if the current score exceeds it
    private bool gameStarted = false;
    public GameObject startMenuWrapper;

    public bool isFirst; // so they don't make duplicate sounds. The way I factored the code is pretty bad.



    void Start()
    {
        startPosition = transform.position;
        currentHighScore = 0;
    }   

    void Update()
    {
        if (gameStarted) {
            float ballAngle = Vector2.Angle(transform.position, body.linearVelocity);
            if (ballAngle < 90 &&
            (transform.position.x < -levelBounds.x ||
            transform.position.x > levelBounds.x ||
            transform.position.y < -levelBounds.y ||
            transform.position.y > levelBounds.y))
            {
                if (GameManager.instance.score > currentHighScore)
                {
                    if (isFirst) { FindFirstObjectByType<AudioManager>().Play("Fetch"); }
                    currentHighScore = GameManager.instance.score;
                } 
                else 
                {
                    if (isFirst) { FindFirstObjectByType<AudioManager>().Play("Sucker"); }
                }

                GameOver();
            }
        }
    }

    public void StartGame(bool first)
    {
        isFirst = first;
        if (isFirst) { FindFirstObjectByType<AudioManager>().Play("Jon_GO"); }
        gameStarted = true;
        startMenuWrapper.SetActive(false);
        Reset();
    }

    public void GameOver()
    {
        startMenuWrapper.SetActive(true);
        gameStarted = false;
        body.linearVelocity = Vector2.zero; // 0 vector, stops ball from moving (just saving on computational power)
    }

    public void Reset()
    {
        transform.position = startPosition;
        body.linearVelocity = direction.normalized * impulse;

        GameManager.instance.score = 0;
    }
}
