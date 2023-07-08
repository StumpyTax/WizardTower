using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float pushForce;
    public float speed;
    public float range;
    public Vector3 start;
    public Vector3 direction;
    private float _damage;
    private Status[] _statuses;

    protected Rigidbody rb;
    private GameObject _gm;
    private Collider collider;


    public void Start()
    {
        collider= GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        return;
    }
}
