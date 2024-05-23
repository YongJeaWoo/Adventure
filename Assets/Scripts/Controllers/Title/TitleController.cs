using UnityEngine;

public class TitleController : MonoBehaviour
{
    public void StartButton()
    {
        LoadingController.LoadScene("Game");
    }

    public void OptionButton()
    {

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
