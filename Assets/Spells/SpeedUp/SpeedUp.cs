
public class SpeedUp : Spell
{
    public void Start()
    {
        casterEntity.AddNewStatus(statuses[0]);
        Destroy(gameObject);
    }
}
