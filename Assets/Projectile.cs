using UnityEngine;

public class Projectile : Entity
{
    public float speed;
    public float range;
    private float _damage;
    public float pushForce;
    
    public Vector3 start;
    public Vector3 direction;
    private Status[] _statuses;

    protected Rigidbody rb;
    private GameObject _gm;
    private Collider collider;

    // public Projectile()
    // {
    //     tags.Add(Tags.Projectile);
    // }
    

    public void Start()
    {
        collider= GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        return;
    }
}
