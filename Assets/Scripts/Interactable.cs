using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float _radius = 3f;
    public Transform _interactionTransform;

    bool _isFocus = false;

    bool _hasInteracted = false;
    float updatedDistance;
    public virtual void Interact()
    {
        //This method is meant to be overwritten
        //Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        if (_isFocus)
        {
            float distance = Vector3.Distance(PlayerManager.instance.player.transform.position, _interactionTransform.position);
            if(!_hasInteracted && distance <= _radius)
            {
                //Debug.Log($"Has interacted! Distance: {distance} Radius: {_radius}");
                _hasInteracted = true;
                Interact();
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        _isFocus = true;
        _hasInteracted = false;  
    }

    public void OnDefocused()
    {
        _isFocus = false;
        _hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_interactionTransform.position, _radius);
    }
}
