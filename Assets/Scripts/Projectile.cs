using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb = null;

    [SerializeField]
    private float _moveSpeed = 6;

    [SerializeField]
    private float _rotationSpeed = 200;

    [SerializeField]
    private bool _faceTargetOnStart = false;

    [SerializeField]
    private GameObject _onCollisionFx = null;

    private Transform _target = null;

    public void Init(Transform target)
    {
        _target = target;

        if (_faceTargetOnStart)
        {
            Vector3 dir = target.position - transform.position;
            dir.Normalize();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            Vector3 targetPos = _target.position;
            targetPos += Vector3.up * Random.Range(-20f, 20f);
            Vector3 dir = targetPos - transform.position;
            dir.Normalize();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void FixedUpdate()
    {
        Vector2 dir = _target.position - transform.position;
        dir.Normalize();
        float rotateAmount = Vector3.Cross(dir, transform.up).z;
        _rb.angularVelocity = -rotateAmount * _rotationSpeed;
        _rb.velocity = transform.up * _moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_onCollisionFx != null)
            Instantiate(_onCollisionFx, collision.transform);

        Destroy(gameObject);
    }
}
