using UnityEngine;

public class shakeDetection : MonoBehaviour
{
    public float ShakeDetectionThreshold;
    public float MinShakeInterval;

    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;

    private Shake shake;
    void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
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
