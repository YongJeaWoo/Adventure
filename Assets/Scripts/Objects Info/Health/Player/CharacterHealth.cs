using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : BaseHealth
{
    public static bool isDie = false;
    public static bool notTakeDamaged = false;
    
    private Animator animator;
    private PlayerStateSystem playerState;

    [SerializeField] private Slider healthSlider;
    public Slider HealthSlider { get => healthSlider; set => healthSlider = value; }


    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerState = FindObjectOfType<PlayerStateSystem>();
    }

    public override void HpDown(int _value)
    {
        if (currentHp <= 0) return;

        currentHp -= _value;

        float resultHp = (float)currentHp / (float)Hp;

        if (HealthSlider != null)
        {
            HealthSlider.value = resultHp;
        }

        if (currentHp > 0)
        {
            animator.SetTrigger("Hit");
        }

        if (currentHp <= 0)
        {
            GetComponent<Collider>().enabled = false;
            isDie = true;
            playerState.PlayerState = E_PlayerState.Death;

            animator.SetTrigger("Death");
        }
    }

    public void HpUp(int _value)
    {
        if (currentHp >= Hp)
        {
            currentHp = Hp;
            return;
        }

        currentHp += _value;
        float resultHp = (float)currentHp / (float)Hp;
        HealthSlider.value = resultHp;
    }

    public override void TakeDamage(GameObject hitEffectPrefab, Vector3 hitPos, int damage, bool isKnockBack = false)
    {
        if (notTakeDamaged) return;

        base.TakeDamage(hitEffectPrefab, hitPos, damage, isKnockBack);
    }
}
