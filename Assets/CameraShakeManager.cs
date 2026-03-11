using UnityEngine;
using Unity.Cinemachine;


public class CameraShakeManager : MonoBehaviour
{
    public static CameraShakeManager Instance; //we dont have to ref script anywhere else, can use it immediately
    [SerializeField] private CinemachineCamera cinemachineCamera;
    private CinemachineBasicMultiChannelPerlin noise;
   
   private void Awake()
    {
        Instance = this;
        noise = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float intensity, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine(intensity,duration));
    }
    private System.Collections.IEnumerator ShakeRoutine(float intensity, float duration)
    {
        noise.AmplitudeGain = intensity;
        yield return new WaitForSeconds(duration);
        noise.AmplitudeGain = 0f;
    }
}
