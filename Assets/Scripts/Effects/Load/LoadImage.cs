using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private Image loadImage;
    private int currentIndex = 0;
    private float waitTime = 0.05f;

    private void Awake()
    {
        loadImage = GetComponent<Image>();
    }

    private void Start()
    {
        if (sprites.Length > 0)
        {
            loadImage.sprite = sprites[currentIndex];
            StartCoroutine(Loading());
        }
    }

    private IEnumerator Loading()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            currentIndex = (currentIndex + 1) % sprites.Length;
            loadImage.sprite = sprites[currentIndex];
        }
    }
}
