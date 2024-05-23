using UnityEngine;

public class PanelManager : MonoBehaviour
{
    #region Singleton
    public static PanelManager instance;

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
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

    private bool isAnyPanelActive = false;

    public bool IsAnyPanelActive() => isAnyPanelActive;

    public void SetPanelActive(bool _isActive)
    {
        isAnyPanelActive = _isActive;
    }
}
