using UnityEngine;
using System.Collections.Generic;

public class Pool : MonoBehaviour
{
    [SerializeField] private PoolObject _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private int _minCapacity;
    [SerializeField] private int _maxCapacity;
    [SerializeField] private bool _isExpand;

    private List<PoolObject> _pool;

    private void OnValidate()
    {
        if (_isExpand)
        {
            _maxCapacity = int.MaxValue;
        }
    }

    private void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        _pool = new List<PoolObject>(_minCapacity);

        for (int i = 0; i < _minCapacity; i++)
        {
            CreateElement();
        }
    }

    private PoolObject CreateElement(bool isActiveByDefault = false)
    {
        var createObject = Instantiate(_prefab, _container);
        createObject.gameObject.SetActive(isActiveByDefault);

        _pool.Add(createObject);

        return createObject;
    }

    public bool TryGetElement(out PoolObject element)
    {
        foreach (var item in _pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                element = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public PoolObject GetFreeElement( Transform position, Quaternion rotation)
    {
        var element = GetFreeElement(position);
        element.transform.rotation = rotation;
        return element;
    }

    public PoolObject GetFreeElement(Transform position)
    {
        var element = GetFreeElement();
        element.transform.position = position.position;
        return element;
    }

    public PoolObject GetFreeElement()
    {
        if (TryGetElement(out var element))
        {
            return element;
        }

        if (_isExpand)
        {
            return CreateElement(true);
        }

        if (_pool.Count < _maxCapacity)
        {
            return CreateElement(true);
        }

        throw new System.Exception("Pool is Over!");
    }
}
