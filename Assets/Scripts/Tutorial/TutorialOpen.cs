using System.Collections;
using UnityEngine;

public class TutorialOpen : MonoBehaviour
{
    [SerializeField] private GameObject tutorialCanvas;

    public void TutorialSet()
    {
        tutorialCanvas.SetActive(true);

        StartCoroutine(AutoDestroyTutorial());
    }

    private IEnumerator AutoDestroyTutorial()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(tutorialCanvas, 1.5f);

        yield return null;
    }
}
