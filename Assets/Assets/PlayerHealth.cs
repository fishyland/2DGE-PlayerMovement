using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerHealth: MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float invulnerabilityDuration = 1f;
    [SerializeField] float blinkInterval = 0.1f;
    // serialize field lets you access things from the inspector
    //public class is accessed by everything in unity,
    // so if this was a public class your enemies would have this too

    public float currentHealth;
    private float invulnerabilityTimer;
    private SpriteRenderer sprite;
    private float blinkTimer;
    private bool blinking;

    public Slider healthSlider;
    void Awake() //starts before start
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

    }
    void Update() //does it every frame
    {
        if(invulnerabilityTimer >0f)
        {
            invulnerabilityTimer-=Time.deltaTime; //continously takes away at 1 frame(delta)
            HandleBlink();
        }
    }
    public bool ApplyDamage(float amount) //can set amount in inspector
    {
        if(currentHealth <=0f || invulnerabilityTimer >0f)
        return false;

        currentHealth -= amount;
        CameraShakeManager.Instance.Shake(2f, 0.25f);

        if (healthSlider != null)
        healthSlider.value = currentHealth;

        if(currentHealth <= 0f)
        {
            Die();
            return true;
        }
        invulnerabilityTimer = invulnerabilityDuration;
        StartBlink(invulnerabilityDuration);
        return true;
    }
        void StartBlink(float duration)
    {
       blinking = true;
       blinkTimer = duration; 
    }
    void HandleBlink()
    {
        if(!blinking) return; //if it's one line, don't need curly brackets
        blinkTimer -= Time.deltaTime;
        if(blinkTimer <= 0f)
        {
            blinking = false;
            sprite.enabled = true;
            return;
        }
        sprite.enabled =
        Mathf.FloorToInt(blinkTimer/blinkInterval) % 2 == 0;
    }
    void Die()
    {
        gameObject.SetActive(false);
    }
}