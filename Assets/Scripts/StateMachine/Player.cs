using UnityEngine;
using System.Collections.Generic;

public class Player : StateMachine
{
    [SerializeField] private List<Weapon> _weapons;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;

    private void Start()
    {
        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviusWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _weapons.Count - 1;
        else
            _currentWeaponNumber--;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

}
