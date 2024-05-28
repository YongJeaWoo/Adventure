using System.Collections;
using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    protected Animator animator;
    protected Collider col;
    protected InventorySystem inventorySystem;

    private bool interacted = false;
    public bool Interacted { get => interacted; set => interacted = value; }

    [Header("ÆÄ±« ÀÌÆÑÆ®")]
    [SerializeField] private GameObject destroyPrefab;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider>();
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    public abstract void Open();

    public virtual void ChestDestroy()
    {
        col.enabled = false;
        StartCoroutine(DestroyObjectCoroutine());
    }

    protected IEnumerator DestroyObjectCoroutine()
    {
        Instantiate(destroyPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
