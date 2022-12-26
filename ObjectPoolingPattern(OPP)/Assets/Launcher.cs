using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Launcher : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    private IObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(CreateBullet,
            OnGet,
            OnRelease);
    }

    private Bullet CreateBullet()
    {
        Bullet _bullet = Instantiate(bulletPrefab);
        _bullet.SetPool(bulletPool);
        return _bullet;
    }
    private void OnRelease(Bullet pBullet)
    {
        pBullet.gameObject.SetActive(false);
    }

    private void OnGet(Bullet pBullet)
    {
        pBullet.gameObject.SetActive(true);
        pBullet.transform.position = this.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletPool.Get();
        }
    }

}
