using UnityEngine;

public class Entity : MonoBehaviour
{
    public float hp;
    public int mastery;
    public float movementSpeed;
    public float critChance;

    public void DamageTaken() 
    {
        Debug.Log(hp);
        if (hp <= 0)
            Destroy(gameObject);
    }
}
