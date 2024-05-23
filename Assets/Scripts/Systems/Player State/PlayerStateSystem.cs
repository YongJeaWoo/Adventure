using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum E_PlayerState 
{
    Alive,
    Death
}

public class PlayerStateSystem : MouseLock
{
    protected E_PlayerState playerState = E_PlayerState.Alive;

    public delegate void PlayerStateChanged(E_PlayerState state);
    protected event PlayerStateChanged OnPlayerStateChanged;

    [SerializeField] protected Image fadePanel;
    [SerializeField] protected float fadeSpeed = 0.5f;

    protected bool isFading = false;

    public E_PlayerState PlayerState
    {
        get => playerState;
        set
        {
            ChangePlayerState(value);
        }
    }

    [SerializeField] private Slider playerProgressBar;
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] protected CinemachineFreeLook freeLookCam;

    private GameObject player;

    private void Start()
    {
        PlayerState = E_PlayerState.Alive;
        player = PlayerManager.instance.GetPlayer();
    }

    private void ChangePlayerState(E_PlayerState state)
    {
        playerState = state;
        OnPlayerStateChanged?.Invoke(state);

        switch (state)
        {
            case E_PlayerState.Alive:
                {
                    HideMouseCursor();
                    PlayerSet();
                    UpdateEnemyFSMPlayer();
                }
                break;
            case E_PlayerState.Death:
                {

                }
                break;
        }

        switch (state)
        {
            case E_PlayerState.Alive:
                {
                    var hpProgress = player.GetComponent<CharacterHealth>();
                    hpProgress.HealthSlider = playerProgressBar;
                    playerProgressBar.value = 1f;
                    deathCanvas.SetActive(false);
                }
                break;
            case E_PlayerState.Death:
                {
                    deathCanvas.SetActive(true);
                    StartCoroutine(WaitForInput());
                }
                break;
        }
    }

    private IEnumerator WaitForInput()
    {
        yield return new WaitForSeconds(2f);

        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        if (!isFading)
        {
            StartCoroutine(FadeOut());
        }
    }

    protected IEnumerator FadeOut()
    {
        isFading = true;
        fadePanel.gameObject.SetActive(true);

        float alpha = 0f;
        Color currentColor = fadePanel.color;

        while (alpha < 1f)
        {
            alpha += fadeSpeed * Time.deltaTime;
            fadePanel.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }

        PlayerManager.instance.DeletePlayer();
        fadePanel.gameObject.SetActive(false);
        CharacterHealth.isDie = false;
        PlayerState = E_PlayerState.Alive;
        isFading = false;
    }

    private void PlayerSet()
    {
        PlayerManager.instance.SetPlayer();
        player = PlayerManager.instance.GetPlayer();
        freeLookCam.Follow = player.transform;
        freeLookCam.LookAt = player.transform.GetChild(0);
    }

    private void UpdateEnemyFSMPlayer()
    {
        GameObject player = PlayerManager.instance.GetPlayer();
        EnemyFSM[] enemiesFSM = FindObjectsOfType<EnemyFSM>();
        BossFSM[] bossFSM = FindObjectsOfType<BossFSM>();

        foreach (var enemyFSM in enemiesFSM)
        {
            enemyFSM.SetPlayer(player);
        }

        foreach (var bossesFSM in bossFSM)
        {
            bossesFSM.SetPlayer(player);
        }
    }
}
