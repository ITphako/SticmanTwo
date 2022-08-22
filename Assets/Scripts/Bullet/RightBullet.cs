using UnityEngine;
using System.Collections;

public class RightBullet : Bullet
{
    [SerializeField] private PoolObject _pool;

    private void Update()
    {
        Shoot(Vector2.right);
    }

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(LifeTime);
        _pool.ReturnToPool();
    }

    public override void Shoot(Vector2 direction)
    {
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
