using UnityEngine;
using DG.Tweening;

public class scaleExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DOScale(1.5f,.3f).SetLoops(8,LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
