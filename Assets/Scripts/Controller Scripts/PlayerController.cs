using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    Camera _camera;
    public LayerMask _movementMask;
    PlayerMotor _playerMotor;

    public Interactable _focus;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _playerMotor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, _movementMask))
            {
                //Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                //Move our player to what we hit
                _playerMotor.MoveToPoint(hit.point);
                //Stop focusing any objects
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100 ))
            {
                Interactable _interactable = hit.collider.GetComponent<Interactable>();
                if (_interactable != null)
                {
                    SetFocus(_interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != _focus)
        {
            if(_focus != null)
            {
                _focus.OnDefocused();
            }
            _focus = newFocus;
            newFocus.OnFocused(transform);
            _playerMotor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if(_focus != null)
        {
            _focus.OnDefocused();
        }

        _focus = null;
        _playerMotor.StopFollowingTarget();
    }
}
