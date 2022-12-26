using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{

    [SerializeField] Vector3 speed;

    private IObjectPool<Bullet> bulletPool; 

    // Update is called once per frame
    void Update()
    {
        transform.position +=speed * Time.deltaTime;
    }

    public void SetPool(IObjectPool<Bullet> pool)
    {
        bulletPool = pool;
    }

    //Unity methods when the gameObject exiting the screen
    private void OnBecameInvisible()
    {
        bulletPool.Release(this);
    }
}
