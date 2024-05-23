using UnityEngine;

public class OptionSystem : MouseLock
{
    private bool isOn = false;

    [SerializeField] private GameObject optionCanvas;

    private void Update()
    {
        InputOptionKey();
    }

    private void InputOptionKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isOn && PanelManager.instance.IsAnyPanelActive()) return;

            isOn = !isOn;
            optionCanvas.SetActive(isOn);
            PanelManager.instance.SetPanelActive(isOn);

            if (isOn)
            {
                ShowMouseCursor();
            }
            else
            {
                HideMouseCursor();
            }
        }
    }

    public void ExitButtonClick()
    {
        isOn = false;
        optionCanvas.SetActive(false);
        PanelManager.instance.SetPanelActive(false);
        HideMouseCursor();
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        LoadingController.LoadScene("Title");
    }
}
