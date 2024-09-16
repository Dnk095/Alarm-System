using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;
    [SerializeField] private AlarmTrigger _trigger;

    private bool _isSignal = false;

    private void OnEnable()
    {
        _trigger.Intrusion += OnIntrusion;
    }

    private void OnDisable()
    {
        _trigger.Intrusion -= OnIntrusion;
    }

    private void OnIntrusion()
    {
        _isSignal = !_isSignal;
        _alarmSystem.Signal(_isSignal);
    }
}
