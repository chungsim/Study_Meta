using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EvObType { Chest, Portal, Etc }

public class BaseEventObjectController : MonoBehaviour
{
    private bool _isActive;
    public UnityEvent<bool> onStateChanged;
    public bool IsActive

    {
        get => _isActive;
        set
        {
            if (_isActive == value) return;

            _isActive = value;
            onStateChanged?.Invoke(_isActive);
        }
    }

    [SerializeField] public EvObType Type;

    public virtual void ActiveEvent()
    {
        if (_isActive)
        {
            Debug.Log("Event 실행!!!!!");
        }

        _isActive = !_isActive;
        
    }

}
