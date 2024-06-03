using UnityEngine;

public class TitleController : MonoBehaviour
{
    [Header("�ɼ� ĵ����")]
    [SerializeField] private GameObject optionCanvas;

    public void StartButton()
    {
        LoadingController.LoadScene("Game");
    }

    public void OptionButton(bool isOn)
    {
        isOn = !isOn;
        optionCanvas.SetActive(isOn);
    }

    public void ExitButton()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
