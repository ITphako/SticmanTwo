using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
using UnityEngine.Events;
using EZCameraShake;

public class AttackState : State
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private LeftBullet _leftBullet;
    [SerializeField] private Transform _pistolMove;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;

    public event UnityAction PlayerShoot;
    public UnityEvent ShootSound;

    private void Start()
    {
        ChangeWeapon(_weapons[_currentWeaponNumber]);
        _currentWeapon = _weapons[0];
    }

    public void LeftAttack(Transform shootPoint)
    {
        if (transform.localScale.x > 0)
        {
            ChangeDirection();
            BulletFluLeft(shootPoint);
        }
        else
        {
            BulletFluLeft(shootPoint);
        }
    }

    public void RightAttack(Transform shootPoint)
    {
        if (transform.localScale.x < 0)
        {
            ChangeDirection();
            BulletFlyRight(shootPoint);
        }
        else
        {
            BulletFlyRight(shootPoint);
        }
    }

    private void ChangeDirection()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    private void BulletFluLeft(Transform shootPoint)
    {
        ShootSound.Invoke();
        CameraShaker.Instance.ShakeOnce(4f, 4f, 1f, 1f);
        _currentWeapon.Shoot(shootPoint);
        MovePistol();
    }

    private void BulletFlyRight(Transform shootPoint)
    {
        ShootSound.Invoke();
        CameraShaker.Instance.ShakeOnce(4f, 4f, 1f, 1f);
        _currentWeapon.Shoot(shootPoint);
        MovePistol();
    }

    private void MovePistol()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_pistolMove.DOLocalMoveX(0.6f, 0.1f));
        sequence.Append(_pistolMove.DOLocalMoveX(0.4f, 0.1f));
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}
