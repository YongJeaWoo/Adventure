using UnityEngine;
using UnityEngine.UI;

public class ItemShowInfo : MonoBehaviour
{
    private Animator animator;

    [Header("������ �̹���")]
    [SerializeField] private Image itemIconImage;
    public Image ItemIconImage { get => itemIconImage; set => itemIconImage = value; }

    [Header("������ �̸�")]
    [SerializeField] private Text itemNameText;
    public Text ItemNameText { get => itemNameText; set => itemNameText = value; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.SetTrigger("Info");
    }

    public void DestroyUI()
    {
        Destroy(gameObject, 2f);
    }
}
