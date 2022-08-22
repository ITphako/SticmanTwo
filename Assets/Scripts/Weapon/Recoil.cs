using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using EZCameraShake;

public class Recoil : MonoBehaviour
{
    [SerializeField] private Reload _reload;
    private bool isFirring;
    private bool stopFirring;
    public LeftBullet _bullet;

    private bool isGround;

    public event UnityAction OnReload;

    public void PointerDown()
    {
        isGround = true;
        stopFirring = false;
        MakeTrue();
    }

    public void PointerUp()
    {
        isGround = false;
        stopFirring = true;
        isFirring = false;
    }

    private void MakeTrue()
    {
        isFirring = true;
    }

    private void MakeFalse()
    {
        isFirring = false;
        if (stopFirring == false)
        {
            Invoke("MakeTrue", 0.4f);
        }
    }

    private void Update()
    {
        if (isFirring && isGround)
        {
            MakeFalse(); 
            Shoot();
        }
    }

    private void Shoot()
    {
        if (_reload.CurrentAmo > 0)
        {
            OnReload.Invoke();
            Instantiate(_bullet, transform.forward, Quaternion.identity);
        }
    }
   
}
