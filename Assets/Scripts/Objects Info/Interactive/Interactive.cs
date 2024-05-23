using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    protected Animator animator;
    protected Collider col;
    protected InventorySystem inventorySystem;
    
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider>();
        inventorySystem = FindObjectOfType<InventorySystem>();
    }

    public abstract void Open();
    
    public void DisableCollider()
    {
        col.enabled = false;
    }

    public virtual void ChestDestroy()
    {
        Invoke(nameof(Destroyed), 1.5f);
    }

    protected void Destroyed()
    {
        Destroy(gameObject);
    }
}
