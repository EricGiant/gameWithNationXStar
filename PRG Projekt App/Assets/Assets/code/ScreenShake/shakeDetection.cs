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
        //check if phone is shaking enough for code to be activated
        if (Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold 
        && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval)
        {
            Debug.Log("Phone is shaking");
            shake.CamShake();
            timeSinceLastShake = Time.unscaledTime;
        }
    }
}
