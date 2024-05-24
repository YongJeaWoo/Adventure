using System.Collections;
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

    public void RefreshHpUI(ConsumableItem _item)
    {
        var playerHealth = player.GetComponent<CharacterHealth>();
        var cType = _item.ConsumerType;

        switch (cType)
        {
            case EnumData.E_ConsumerType.HpUp:
                {
                    playerHealth.HpUp(_item.Value);
                }
                break;
            case EnumData.E_ConsumerType.Curse:
                {
                    StartCoroutine(CurseEffect(playerHealth, _item));
                }
                break;
        }
    }

    private IEnumerator CurseEffect(CharacterHealth _playerHp, ConsumableItem _effectItem)
    {
        float duration = 5f;
        float interval = 1f;

        float elapsedTime = 0f;

        while (elapsedTime <= duration)
        {
            yield return new WaitForSeconds(interval);
            elapsedTime += interval;
            _playerHp.HpDown(_effectItem.Value);
        }

        yield return null;
    }

    public GameObject GetPlayer() => player;
}
