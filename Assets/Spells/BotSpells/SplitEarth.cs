using System.Collections;
using UnityEngine;

public class SplitEarth : Spell
{
    private void Start()
    {
        transform.position = casterEntity.transform.position;
        StartCoroutine(DestroyRoutine());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var victim = other.GetComponent<Entity>();
            victim.Hp -= CalculateDamage();
        }
    }

    public IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
