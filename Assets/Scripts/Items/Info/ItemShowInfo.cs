using UnityEngine;
using UnityEngine.UI;

public class ItemShowInfo : MonoBehaviour
{
    private Animator animator;

    [Header("아이템 이미지")]
    [SerializeField] private Image itemIconImage;
    public Image ItemIconImage { get => itemIconImage; set => itemIconImage = value; }

    [Header("아이템 이름")]
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
