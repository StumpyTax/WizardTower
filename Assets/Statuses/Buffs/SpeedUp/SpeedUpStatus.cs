using System.Threading.Tasks;
using UnityEngine;

public class SpeedUpStatus : Status
{
    public float speedBonus;
    public override void Init()
    {
        // status.OnGet += entity => { Speed(entity); };
        // status.OnEnd += entity =>
        // {
        //     entity.movementSpeed = entity.movementSpeed / (speedBonus + 1);
        // };
    }
    
    public void Speed(Entity entity)
    {
        entity.movementSpeed = 
            (speedBonus + 1) * entity.movementSpeed;
        // while (status.curDur < status.duration)
        // {
        //     status.curDur += Time.deltaTime;
        //     Debug.Log(status.curDur);
        //     await Task.Delay((int)(Time.deltaTime * 1000));
        // }
        void OnEnd()
        {
            // status.OnEnd.Invoke(entity);
        }
        TimeManager.instance.AddAction(OnEnd, status.duration);
    }
}
