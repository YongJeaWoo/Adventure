using System.Collections;
using UnityEngine;

public class FireBall : MonoBehaviour
{     
    [Header("움직임 속도")]
    [SerializeField] private float moveSpeed;
    private int damage;
    [Header("공격 이팩트")]
    [SerializeField] private GameObject hitPrefab;
    [SerializeField] private BossData SOJ;

    private float delayTime = 2.5f;

    private Vector3 playerLastPos;

    private void Start()
    {
        playerLastPos = PlayerManager.instance.GetPlayer().transform.position;
        damage = SOJ.FireDamage;

        StartCoroutine(DestroyAfterDelay(delayTime));
    }

    private void Update()
    {
        PlayerToAttack();
    }

    private void PlayerToAttack()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerLastPos,
            moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var hitPos = other.ClosestPoint(other.transform.position);
            var health = other.GetComponent<CharacterHealth>();
            health.TakeDamage(hitPrefab, hitPos, damage);
        }

        Destroy(gameObject);
    }

    private IEnumerator DestroyAfterDelay(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        Destroy(gameObject);
    }
}
