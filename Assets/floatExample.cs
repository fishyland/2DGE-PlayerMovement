using UnityEngine;
using DG.Tweening;

public class floatExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DOMoveY(transform.position.y + 0.5f, 1f)
        .SetLoops(-1,LoopType.Yoyo)
        .SetEase(Ease.InOutSine); //sine ways used for finding curves within a thing
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
