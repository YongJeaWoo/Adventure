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

    [Header("¾ÆÀÌÅÛ È¹µæ UI ÇÁ¸®ÆÕ")]
    [SerializeField] private GameObject showUIPrefab;
    public GameObject ShowUIPrefab { get => showUIPrefab; set => showUIPrefab = value; }

    [Header("UI Ç¥½Ã À§Ä¡")]
    [SerializeField] private Transform uiParentPosition;

    [Header("UI ½½·Ô È°¼ºÈ­ ½Ã°£")]
    [SerializeField] private float slotActiveTime;

    public void AddItemShowText()
    {
        var go = Instantiate(ShowUIPrefab, uiParentPosition.position, Quaternion.identity);
        go.transform.SetParent(uiParentPosition);
    }
}
