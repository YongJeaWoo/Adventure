using UnityEngine;

public class TitleController : MonoBehaviour
{
    [Header("¿É¼Ç Äµ¹ö½º")]
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
