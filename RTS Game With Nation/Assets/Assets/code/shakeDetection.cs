using UnityEngine;

public class shakeDetection : MonoBehaviour
{
    public float ShakeDetectionThreshold;
    public float MinShakeInterval;

    float sqrShakeDetectionThreshold;
    float timeSinceLastShake;

    Shake shake;
    void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
        shake = GameObject.FindGameObjectWithTag("ShakeManager").GetComponent<Shake>();
    }

       void Update()
    {
        if (Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold 
        && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval)
        {
            shake.CamShake();
            timeSinceLastShake = Time.unscaledTime;
        }
    }
}
