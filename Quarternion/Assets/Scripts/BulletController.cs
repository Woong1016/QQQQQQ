using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 direction;
    public float _damage;
    public float _moveSpeed;
    private void LateUpdate()
    {

        float moveSpeed = (_moveSpeed + 5) * Time.fixedDeltaTime;
        transform.Translate(direction * moveSpeed);
        if(this.transform.position.z >=10)
        {
            Managers.Pool.Destroy(this.gameObject);
            Managers.Data.bullets.Remove(this as BulletController);
        }
    }
}
