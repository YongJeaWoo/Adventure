using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class AutoDestroyParticle : MonoBehaviour
{
    public bool onlyDeactivate;

    private void OnEnable()
    {
        StartCoroutine(CheckIsAlive());
    }

    private IEnumerator CheckIsAlive()
    {
        ParticleSystem ps = this.GetComponent<ParticleSystem>();

        while (true && ps != null)
        {
            yield return new WaitForSeconds(0.03f);
            if (!ps.IsAlive(true))
            {
                if (onlyDeactivate)
                {
                    this.gameObject.SetActive(false);
                }
                else
                {
                    Destroy(this.gameObject);
                }
                break;
            }
        }
    }
}
