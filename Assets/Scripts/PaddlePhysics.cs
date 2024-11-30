using UnityEngine;

public class PaddlePhysics : MonoBehaviour
{
    public float maxReflectAngle;

    void OnTriggerEnter2D(Collider2D other)
    {
        FindFirstObjectByType<AudioManager>().Play("Clack"); // <-- audio
        Rigidbody2D ball = other.attachedRigidbody;
        if (ball != null)
        {
            Vector2 paddleNormal = transform.up;
            float ballAngle = Vector2.Angle(paddleNormal, ball.linearVelocity);

            if (ballAngle > 90)
            {
                Vector2 reflectedVelocity = Vector2.Reflect(ball.linearVelocity, paddleNormal);
                float reflectAngle = Vector2.SignedAngle(paddleNormal, reflectedVelocity);

                if (Mathf.Abs(reflectAngle) > maxReflectAngle)
                {
                    float deltaAngle = (Mathf.Sign(reflectAngle) * maxReflectAngle) - reflectAngle;
                    Quaternion clampRotation = Quaternion.Euler(0,0,deltaAngle);
                    reflectedVelocity = clampRotation * reflectedVelocity;
                }

                ball.linearVelocity = reflectedVelocity;

                GameManager.instance.score++;
            }
        }
    }
}
