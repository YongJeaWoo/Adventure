using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [Header("������ ȹ�� UI ������")]
    [SerializeField] private GameObject showUIPrefab;
    public GameObject ShowUIPrefab { get => showUIPrefab; set => showUIPrefab = value; }

    [Header("UI ǥ�� ��ġ")]
    [SerializeField] private Transform uiParentPosition;

    [Header("UI ���� Ȱ��ȭ �ð�")]
    [SerializeField] private float slotActiveTime;

    public void AddItemShowText()
    {
        var go = Instantiate(ShowUIPrefab, uiParentPosition.position, Quaternion.identity);
        go.transform.SetParent(uiParentPosition);
    }
}
