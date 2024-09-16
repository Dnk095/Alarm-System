using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action Intrusion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out _))
            Intrusion?.Invoke();
    }
}
