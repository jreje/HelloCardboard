using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class BallPrefab : MonoBehaviour
{
    public float settleDelay = 0.75f;
    private bool hasScored = false;
    private Coroutine pending;

    void OnTriggerEnter(Collider other)
    {
        if (hasScored) return;
        pending = StartCoroutine(CheckSettled());
    }
    private void OnTriggerExit(Collider other)
    {
        // If still waiting
        if (pending != null)
        {
            StopCoroutine(pending); 
            pending = null;
        }
    }
    private IEnumerator CheckSettled()
    {
        yield return new WaitForSeconds(settleDelay);
        hasScored = true;
        Scorer.Instance.AddPoint();
    }

}
