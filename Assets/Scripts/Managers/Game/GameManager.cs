using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

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

    [Header ("�÷��̾� ��� �� �г� ��Ȱ��")]
    [SerializeField] private GameObject playerDeathCanvas;
    private Text canvasEndText;
    private Text canvasEndAnyKeyText;


    private BossFSM boss;

    public BossFSM SetBossFSM(BossFSM bossFSM) => boss = bossFSM;

    public void GameOver()
    {
        var parent = playerDeathCanvas.transform.GetChild(0);
        canvasEndText = parent.GetChild(0).GetComponentInChildren<Text>();
        canvasEndAnyKeyText = parent.GetChild(1).GetComponentInChildren<Text>();

        canvasEndText.text = $"���� ������ ������� �Դϴ�.";
        canvasEndAnyKeyText.text = $"�ƹ� Ű�� ���� ������ �����ϼ���.";
        playerDeathCanvas.SetActive(true);

        StartCoroutine(WaitForInput());
    }

    private IEnumerator WaitForInput()
    {
        yield return new WaitForSeconds(2f);

        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        LoadingController.LoadScene("Title");
    }
}
