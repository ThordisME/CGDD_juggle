using UnityEngine;

// "The script needs to derive from MonoBehaviour!"

public class PaddleController : MonoBehaviour
{
    public float rotationSpeed;
    bool wantsToRotate;

    void Update()
    {
        wantsToRotate = Input.GetMouseButton(0);
    }

    void FixedUpdate()
    {
        if (wantsToRotate) {
            transform.Rotate(0,0,rotationSpeed*Time.fixedDeltaTime);
        }
    }
    
}
