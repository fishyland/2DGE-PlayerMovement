using UnityEngine;
using DG.Tweening;

public class jumpExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DOJump(new Vector3(-21.4400005f,-2.3499999f,0.439999998f),.5f,3,3f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
