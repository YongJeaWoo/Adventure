using UnityEngine;
using UnityEngine.UI;

public class ItemDetect : MonoBehaviour
{
    private Interactive currentInteractive;
    private Image infoImage;

    private float detectionRadius = 2f;

    private void Awake()
    {
        var canvas = GameObject.Find("UI Canvas");
        infoImage = canvas.transform.GetChild(0).GetComponent<Image>();
    }

    private void Update()
    {
        DetectInteractive();
    }

    private void DetectInteractive()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Interactive"))
            {
                CheckCollider(collider, true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (currentInteractive.TryGetComponent<Interactive>(out var interactive))
                    {
                        if (interactive.Interacted) return;

                        interactive.Open();
                    }
                }
                return;
            }
        }

        CheckCollider(null, false);
    }

    private void CheckCollider(Collider col, bool isOn)
    {
        if (col != null)
        {
            currentInteractive = col.GetComponent<Interactive>();
        }
        else
        {
            currentInteractive = null;
        }

        infoImage.gameObject.SetActive(isOn);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
