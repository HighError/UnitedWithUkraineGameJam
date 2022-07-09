using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy() {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
