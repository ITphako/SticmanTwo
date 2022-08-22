using UnityEngine;

public class Reload : MonoBehaviour
{
    [SerializeField] private int _allAmo;
    [SerializeField] private int _amo;
    [SerializeField] private Recoil _recoil;
    [SerializeField] private int _currentAmo;

    public int CurrentAmo => _currentAmo;

    private void OnEnable()
    {
        _recoil.OnReload += UpdateReload;
    }

    private void OnDisable()
    {
        _recoil.OnReload -= UpdateReload;
    }

    private void UpdateReload()
    {
        _currentAmo--;
    }

    public void ReloadAmo()
    {
        if (_allAmo > 0)
        {
           int reason = _amo - _currentAmo;
            if (_allAmo >= reason)
            {
                _allAmo = _allAmo - reason;
                _currentAmo = _amo;
            }
            else
            {
                _currentAmo = _currentAmo + _allAmo;
                _allAmo = 0;
            }
        }
    }
}
