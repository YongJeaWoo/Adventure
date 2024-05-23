using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [Header("ü�� ǥ��")]
    [SerializeField] protected GameObject damageTextPrefab;
    [Header("�ǰ� ��ƼŬ")]
    [SerializeField] protected Transform hitEffectPos;
    [Header("ü�� ����")]
    [SerializeField] private int hp;
    public int Hp { get => hp;  }

    [Header("ü�� ������ ����")]
    [SerializeField] private Image hpProgressImage;
    public Image HpProgressImage { get => hpProgressImage; set => hpProgressImage = value; }

    protected int currentHp;
    public int CurrentHp
    {
        get
        {
            if (currentHp <= 0) return 0;
            return currentHp;
        }
        set
        {
            currentHp = value;
            if (currentHp <= 0) currentHp = 0;
        }
    }

    protected virtual void Start()
    {
        currentHp = Hp;
        if (HpProgressImage != null)
        {
            HpProgressImage.fillAmount = currentHp;
        }
    }

    public virtual void HpDown(int _value)
    {
        if (currentHp <= 0) return;

        currentHp -= _value;

        float resultHp = (float)currentHp / (float)Hp;

        if (HpProgressImage != null)
        {
            HpProgressImage.fillAmount = resultHp;
        }
    }

    public virtual void TakeDamage(GameObject hitEffectPrefab, Vector3 hitPos, int damage, bool isKnockBack = false)
    {
        HpDown(damage);
        var hit = Instantiate(hitEffectPrefab, hitPos, Quaternion.identity);
        hit.transform.SetParent(transform);
        var random = hitEffectPrefab.GetComponent<RandomPosition>();
        random.RandomPos();
        ShowDamagedText(damage);
    }

    private void ShowDamagedText(int _damage)
    {
        if (currentHp <= 0) return;

        var damagedText = Instantiate(damageTextPrefab, transform.position, Quaternion.identity, transform);
        damagedText.GetComponent<TextMesh>().text = _damage.ToString();
    }

    public void HpRefresh()
    {
        HpProgressImage.fillAmount = (float)currentHp / (float)Hp;
    }
}
