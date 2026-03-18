using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private bool isInvulnerable = false;
    [SerializeField] private float invulnerabilityDuration = 1f;

    public float currentHealth;
    private float invulnerabilityTimer = 0f;

    private SpriteRenderer spriteRenderer;
    private Material spriteMaterial;

    public Slider healthSlider;

    [Header("Hit Effect")]
    [SerializeField] private float hitEffectDuration = 0.2f; 
    [SerializeField] private string hitPropertyName = "_HitEffectAmount";

    [Header("Death Effect")]
    [SerializeField] private ParticleSystem deathEffectPrefab; // assign in inspector

    private void Awake()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteMaterial = spriteRenderer.material;
        }

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    private void Update()
    {
        if (invulnerabilityTimer > 0f)
        {
            invulnerabilityTimer -= Time.deltaTime;
        }
    }

    public bool ApplyDamage(float amount)
    {
        if (isInvulnerable || invulnerabilityTimer > 0f)
            return false;

        currentHealth -= amount;
        invulnerabilityTimer = invulnerabilityDuration;

        CameraShakeManager.Instance.Shake(2f, 2f);

        if (healthSlider != null)
            healthSlider.value = currentHealth;

        // Trigger the shader hit effect
        PlayHitEffect();

        if (currentHealth <= 0f)
        {
            Die();
        }

        return true;
    }

    private void PlayHitEffect()
    {
        if (spriteMaterial == null) return;

        spriteMaterial.SetFloat(hitPropertyName, 1f);
        spriteMaterial.DOFloat(0f, hitPropertyName, hitEffectDuration).SetEase(Ease.OutQuad);
    }

    private void Die()
    {
        // Spawn the death particle effect at the player's position
        if (deathEffectPrefab != null)
        {
            ParticleSystem effect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            effect.Play();

            // Optional: destroy the particle system after it finishes
            Destroy(effect.gameObject, effect.main.duration + effect.main.startLifetime.constantMax);
        }

        gameObject.SetActive(false);
    }
}