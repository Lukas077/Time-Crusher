using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float _radius = 3f;
    public Transform _interactionTransform;

    bool _isFocus = false;
    Transform _player;

    bool _hasInteracted = false;

    public virtual void Interact()
    {
        //This method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        if (_isFocus && !_hasInteracted)
        {
            float _distance = Vector3.Distance(_player.position, _interactionTransform.position);
            if(_distance <= _radius)
            {
                Interact();
                _hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        _isFocus = true;
        _player = playerTransform;
        _hasInteracted = false;
    }

    public void OnDefocused()
    {
        _isFocus = false;
        _player = null;
        _hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if(_interactionTransform == null)
        {
            _interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_interactionTransform.position, _radius);
    }
}
