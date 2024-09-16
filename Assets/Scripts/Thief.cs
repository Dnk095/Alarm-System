using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform[] _targets;
    [SerializeField] private float _speed = 1f;

    private int _currentPosition = 0;

    private void Update()
    {
        if (transform.position == _targets[_currentPosition].position)
            _currentPosition = ++_currentPosition % _targets.Length;

        transform.position = Vector3.MoveTowards(transform.position, _targets[_currentPosition].position, _speed * Time.deltaTime);
    }
}
