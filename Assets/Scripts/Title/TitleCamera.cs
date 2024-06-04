using UnityEngine;

public class TitleCamera : MonoBehaviour
{
    float y;

    private void Update()
    {
        y += Time.deltaTime * 10;
        transform.rotation = Quaternion.Euler(40, y, 0);
    }
}
