using UnityEngine;


public class Collectible : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f; //moves 90 degrees

    void Update()
    {
        transform.Rotate(0f,rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.AddCollectible();
            Destroy (gameObject);
        }
    }
}
