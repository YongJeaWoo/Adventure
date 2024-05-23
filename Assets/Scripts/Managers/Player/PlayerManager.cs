using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

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

    private GameObject player;

    [SerializeField] private GameObject playerPrefab;

    public void SetPlayer()
    {
        player = Instantiate(playerPrefab);
    }

    public void DeletePlayer()
    {
        Destroy(player);
        player = null;
    }

    public GameObject GetPlayer() => player;
}
