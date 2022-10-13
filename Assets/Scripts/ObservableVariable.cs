using System;
using UnityEngine;

[Serializable]
public class ObservableVariable<T>
{
    [SerializeField] T _value;

    event Action<T, T> _onValueChanged;
    public event Action<T, T> OnValueChanged
    {
        add
        {
            if (_onValueChanged == null || !Array.Exists(_onValueChanged.GetInvocationList(), e => (Action<T, T>)e == value))
            {
                _onValueChanged += value;
            }
        }
        remove
        {
            _onValueChanged -= value;
        }
    }

    public T Value
    {
        get => _value;
        set
        {
            T previous = _value;
            _value = value;
            _onValueChanged?.Invoke(previous, _value);
        }
    }
}
