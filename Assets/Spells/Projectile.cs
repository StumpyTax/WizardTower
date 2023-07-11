using UnityEngine;

public class Projectile : Entity
{
    public float speed;
    public float range;
    public float pushForce;
    
    public Vector3 start;
    public Vector3 direction;

    protected Rigidbody rb;
    private GameObject _gm;
    private Collider collider;
    public Spell spell;

   
    public void SetStatuses(Entity victim)
    {
        foreach (var status in spell.statuses)
        {
            status.target = victim;
            /*            victim._statuses.Add(statusGameObj);
             *          
            */
            if (victim._statuses.ContainsKey(status.id))
                victim._statuses[status.id].curDur = 0;
            else
                victim._statuses[status.id]= Instantiate(status);

        }
    }

    public void Start()
    {
        collider= GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        return;
    }
}
