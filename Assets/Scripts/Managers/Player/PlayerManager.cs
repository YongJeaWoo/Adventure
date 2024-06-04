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

    [SerializeField] private Transform playerSpawnPos;

    public void SetPlayer()
    {
        player = Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
    }

    public void DeletePlayer()
    {
        Destroy(player);
        player = null;
    }

    public void IncreaseAttack(ConsumableItem _item)
    {
        var playerDamage = player.GetComponent<BaseAttack>();

        if (_item.ConsumerType == EnumData.E_ConsumerType.BuffAttack)
        {
            playerDamage.Damage += _item.Value;
        }
    }

    public void CurseEffectToDamage(ConsumableItem _item)
    {
        var health = player.GetComponent<BaseHealth>();

        StartCoroutine(CurseEffect(health, _item));
    }

    private IEnumerator CurseEffect(BaseHealth _playerHp, ConsumableItem _effectItem)
    {
        float duration = 5f;
        float interval = 1f;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            yield return new WaitForSeconds(interval);
            elapsedTime += interval;
            _playerHp.HpDown(_effectItem.Value);
        }

        yield return null;
    }

    public GameObject GetPlayer() => player;
}
