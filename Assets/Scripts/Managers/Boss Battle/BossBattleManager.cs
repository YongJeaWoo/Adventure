using UnityEngine;
using UnityEngine.UI;

public class BossBattleManager : MonoBehaviour
{
    #region Singleton
    public static BossBattleManager instance;

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

    [SerializeField] private GameObject bossHealthPanel;

    private Text explainText;

    public void SetBoss(BossEnemyArea _bossArea)
    {
        if (_bossArea == null)
        {
            UpdateBossUI(null, false);
            Debug.Log($"일반 상태");
            AudioManager.instance.PlayRandomBackgroundMusic();
        }
        else
        {
            UpdateBossUI(_bossArea, true);
            Debug.Log($"전투 상태");
            AudioManager.instance.PlayBattleMusic(_bossArea.BattleClip);
        }
    }

    private void UpdateBossUI(BossEnemyArea _bossArea, bool isOn)
    {
        ToggleCanvas(isOn);

        if (_bossArea == null) return;

        var fsm = _bossArea.CurrentBoss.GetComponent<BossFSM>();
        var health = _bossArea.CurrentBoss.GetComponent<BossHealth>();
        var parent = bossHealthPanel.transform.GetChild(0);
        health.HpProgressImage = parent.GetChild(1).gameObject.GetComponent<Image>();
        health.HpRefresh();
        explainText = bossHealthPanel.transform.GetChild(1).GetComponent<Text>();
        explainText.text = fsm.BossDataSOJ.ExplainText;
    }

    private void ToggleCanvas(bool isOn)
    {
        bossHealthPanel.SetActive(isOn);
    }
}