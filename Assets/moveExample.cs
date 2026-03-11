using DG.Tweening;
using UnityEngine;

public class moveExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DOMove(new Vector3(-10,-3,0), 1.5f).SetEase(Ease.OutBounce);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
