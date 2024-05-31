using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillTimerImage : MonoBehaviour
{
    [SerializeField] private SkillData skillSOJ;
    [SerializeField] private Image skillIcon;
    [SerializeField] private Image filledImage;
    [SerializeField] private float timerDuration;
    [SerializeField] private Text skillCoolText;

    [Header("스킬 사용 가능 이팩트")]
    [SerializeField] private ParticleSystem useOnEffect;

    private float timer;
    private bool isTimerRunning = false;

    private void Awake()
    {
        SkillSet();
    }

    private void SkillSet()
    {
        if (skillSOJ != null)
        {
            skillIcon.sprite = skillSOJ.IconSprite;
            timerDuration = skillSOJ.SkillCoolTime;
            timer = 0;
        }
    }

    private void Update()
    {
        FillAmountImage();
    }

    public void FillAmountImage()
    {
        if (isTimerRunning)
        {
            skillCoolText.gameObject.SetActive(true);
            timer -= Time.deltaTime;
            filledImage.fillAmount = timer / timerDuration;
            skillCoolText.text = timer.ToString("F1");

            if (timer <= 0)
            {
                ResetCoolDown();
            }
        }
    }

    public void StartTimer()
    {
        if (!isTimerRunning)
        {
            isTimerRunning = true;
            timer = timerDuration;
            filledImage.raycastTarget = false;
        }
    }

    private void ResetCoolDown()
    {
        useOnEffect.Play();
        isTimerRunning = false;
        filledImage.fillAmount = 0f;
        filledImage.raycastTarget = true;
        skillCoolText.gameObject.SetActive(false);
    }

    public void OnPointerDown(BaseEventData eventData)
    {
        if (!isTimerRunning)
        {
            StartTimer();
        }
    }
}
