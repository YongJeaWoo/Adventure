using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillTimerImage : MonoBehaviour
{
    [SerializeField] private SkillData skillSOJ;
    [SerializeField] private Image skillIcon;
    [SerializeField] private Image filledImage;
    [SerializeField] private float timerDuration;

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
            timer -= Time.deltaTime;
            filledImage.fillAmount = timer / timerDuration;

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
        isTimerRunning = false;
        filledImage.fillAmount = 0f;
        filledImage.raycastTarget = true;
    }

    public void OnPointerDown(BaseEventData eventData)
    {
        if (!isTimerRunning)
        {
            StartTimer();
        }
    }
}
