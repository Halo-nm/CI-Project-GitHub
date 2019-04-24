using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//The standards for the ability
[CreateAssetMenu(menuName = "Abilities/PracticeAbility")]
public class PracticeAbility : Ability //inherites everything from the abstract "Ability" scriptable object //this script now becomes a scriptable object
{
    public int pretendDamage = 1; //"pretend" because mimicking video
    public float pretendRange = 50f;
    public float pretendHitForce = 100f;

    private PracticeLog pretendShoot; //where the code to do the task actually comes from

    public override void Initialize(GameObject obj) //overrides the previous implementation called "Initialize" from the abstract "Ability" class/scriptable object
    { //the obj gameobject MUST have the "logic" script attached to it for the reference below to work (in this case, PracticeLog)
        pretendShoot = obj.GetComponent<PracticeLog>(); //passed in to get a reference to the script and store it in "pretendShoot"
        pretendShoot.Setup();

        pretendShoot.pretendDamage = pretendDamage; //can set the values of the "PracticeLog" script (hidden in inspector ones) to the ones in this scriptable object
        pretendShoot.pretendRange = pretendRange;
        pretendShoot.pretendHitForce = pretendHitForce;
    }

    public override void TriggerAbility() //the functions from the "Ability" class must be implemented/overrided here or an error in this script will be thrown
    {
        pretendShoot.DoSomething(); //calls the function from the "PracticeLog" script
    }
}
