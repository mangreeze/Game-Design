using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float _radius = 0f;
    public Transform _interactable;
    private Transform _player;
    private bool _isFocused = false;
    private bool _hasInteracted = false;

    public virtual void Interact() { }

    private void OnDrawGizmosSelected()
    {
        if (_interactable == null)
            _interactable = transform;
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_interactable.position, _radius);
    }

    public void Update()
    {
        if (_isFocused && !_hasInteracted)
        {
            float distance = Vector3.Distance(_player.position, _interactable.position);
            if (distance <= _radius)
            {
                Interact();
                _hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform player)
    {
        _isFocused = true;
        _player = player;
        _hasInteracted = false;
    }

    public void OnDefocused()
    {
        _isFocused = false;
        _player = null;
        _hasInteracted = false;
    }
}
