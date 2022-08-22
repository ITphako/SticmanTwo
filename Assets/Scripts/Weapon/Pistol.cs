using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _minAngle;
    [SerializeField] private Pool _poolObject;

    public override void Shoot(Transform shootPoint)
    {
        Quaternion angle = Quaternion.Euler(0,0, Random.Range(_minAngle, _maxAngle));
        _poolObject.GetFreeElement(shootPoint, angle);
    }
}

