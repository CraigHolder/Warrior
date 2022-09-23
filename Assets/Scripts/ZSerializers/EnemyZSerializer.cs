[System.Serializable]
public sealed class EnemyZSerializer : ZSerializer.Internal.ZSerializer
{
    public UnityEngine.Transform pathTarget;
    public System.Single speed;
    public System.Single attackRange;
    public System.Single Reaction;
    public System.Single Curious;
    public System.Single Suspicion;
    public Enemy.State currState;
    public Enemy.Attitude currAttitude;
    public UnityEngine.GameObject FOVOBJ;
    public System.Collections.Generic.List<UnityEngine.Rigidbody> physicsBody;
    public Info info;
    public System.Single shotDelay;
    public System.Single radius;
    public System.Single angle;
    public UnityEngine.LayerMask targetMask;
    public UnityEngine.LayerMask obstructionMask;
    public System.Boolean looking;
    public UnityEngine.Transform eyes;
    public System.Boolean blind;
    public System.Single distance;
    public System.Boolean heard;
    public System.Boolean deaf;
    public System.Single PainThreshhold;
    public System.Single Pain;
    public System.Int32 HeadArmor;
    public System.Int32 LegArmor;
    public System.Int32 ChestArmor;
    public System.Int32 ArmArmor;
    public System.Boolean disarmed;
    public System.Collections.Generic.List<UnityEngine.Transform> bodyPos;
    public UnityEngine.AudioSource walkAudio;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public EnemyZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         pathTarget = (UnityEngine.Transform)typeof(Enemy).GetField("pathTarget").GetValue(instance);
         speed = (System.Single)typeof(Enemy).GetField("speed").GetValue(instance);
         attackRange = (System.Single)typeof(Enemy).GetField("attackRange").GetValue(instance);
         Reaction = (System.Single)typeof(Enemy).GetField("Reaction").GetValue(instance);
         Curious = (System.Single)typeof(Enemy).GetField("Curious").GetValue(instance);
         Suspicion = (System.Single)typeof(Enemy).GetField("Suspicion").GetValue(instance);
         currState = (Enemy.State)typeof(Enemy).GetField("currState").GetValue(instance);
         currAttitude = (Enemy.Attitude)typeof(Enemy).GetField("currAttitude").GetValue(instance);
         FOVOBJ = (UnityEngine.GameObject)typeof(Enemy).GetField("FOVOBJ").GetValue(instance);
         physicsBody = (System.Collections.Generic.List<UnityEngine.Rigidbody>)typeof(Enemy).GetField("physicsBody").GetValue(instance);
         info = (Info)typeof(Enemy).GetField("info").GetValue(instance);
         shotDelay = (System.Single)typeof(Enemy).GetField("shotDelay").GetValue(instance);
         radius = (System.Single)typeof(Enemy).GetField("radius").GetValue(instance);
         angle = (System.Single)typeof(Enemy).GetField("angle").GetValue(instance);
         targetMask = (UnityEngine.LayerMask)typeof(Enemy).GetField("targetMask").GetValue(instance);
         obstructionMask = (UnityEngine.LayerMask)typeof(Enemy).GetField("obstructionMask").GetValue(instance);
         looking = (System.Boolean)typeof(Enemy).GetField("looking").GetValue(instance);
         eyes = (UnityEngine.Transform)typeof(Enemy).GetField("eyes").GetValue(instance);
         blind = (System.Boolean)typeof(Enemy).GetField("blind").GetValue(instance);
         distance = (System.Single)typeof(Enemy).GetField("distance").GetValue(instance);
         heard = (System.Boolean)typeof(Enemy).GetField("heard").GetValue(instance);
         deaf = (System.Boolean)typeof(Enemy).GetField("deaf").GetValue(instance);
         PainThreshhold = (System.Single)typeof(Enemy).GetField("PainThreshhold").GetValue(instance);
         Pain = (System.Single)typeof(Enemy).GetField("Pain").GetValue(instance);
         HeadArmor = (System.Int32)typeof(Enemy).GetField("HeadArmor").GetValue(instance);
         LegArmor = (System.Int32)typeof(Enemy).GetField("LegArmor").GetValue(instance);
         ChestArmor = (System.Int32)typeof(Enemy).GetField("ChestArmor").GetValue(instance);
         ArmArmor = (System.Int32)typeof(Enemy).GetField("ArmArmor").GetValue(instance);
         disarmed = (System.Boolean)typeof(Enemy).GetField("disarmed").GetValue(instance);
         bodyPos = (System.Collections.Generic.List<UnityEngine.Transform>)typeof(Enemy).GetField("bodyPos").GetValue(instance);
         walkAudio = (UnityEngine.AudioSource)typeof(Enemy).GetField("walkAudio", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(Enemy).GetField("pathTarget").SetValue(component, pathTarget);
         typeof(Enemy).GetField("speed").SetValue(component, speed);
         typeof(Enemy).GetField("attackRange").SetValue(component, attackRange);
         typeof(Enemy).GetField("Reaction").SetValue(component, Reaction);
         typeof(Enemy).GetField("Curious").SetValue(component, Curious);
         typeof(Enemy).GetField("Suspicion").SetValue(component, Suspicion);
         typeof(Enemy).GetField("currState").SetValue(component, currState);
         typeof(Enemy).GetField("currAttitude").SetValue(component, currAttitude);
         typeof(Enemy).GetField("FOVOBJ").SetValue(component, FOVOBJ);
         typeof(Enemy).GetField("physicsBody").SetValue(component, physicsBody);
         typeof(Enemy).GetField("info").SetValue(component, info);
         typeof(Enemy).GetField("shotDelay").SetValue(component, shotDelay);
         typeof(Enemy).GetField("radius").SetValue(component, radius);
         typeof(Enemy).GetField("angle").SetValue(component, angle);
         typeof(Enemy).GetField("targetMask").SetValue(component, targetMask);
         typeof(Enemy).GetField("obstructionMask").SetValue(component, obstructionMask);
         typeof(Enemy).GetField("looking").SetValue(component, looking);
         typeof(Enemy).GetField("eyes").SetValue(component, eyes);
         typeof(Enemy).GetField("blind").SetValue(component, blind);
         typeof(Enemy).GetField("distance").SetValue(component, distance);
         typeof(Enemy).GetField("heard").SetValue(component, heard);
         typeof(Enemy).GetField("deaf").SetValue(component, deaf);
         typeof(Enemy).GetField("PainThreshhold").SetValue(component, PainThreshhold);
         typeof(Enemy).GetField("Pain").SetValue(component, Pain);
         typeof(Enemy).GetField("HeadArmor").SetValue(component, HeadArmor);
         typeof(Enemy).GetField("LegArmor").SetValue(component, LegArmor);
         typeof(Enemy).GetField("ChestArmor").SetValue(component, ChestArmor);
         typeof(Enemy).GetField("ArmArmor").SetValue(component, ArmArmor);
         typeof(Enemy).GetField("disarmed").SetValue(component, disarmed);
         typeof(Enemy).GetField("bodyPos").SetValue(component, bodyPos);
         typeof(Enemy).GetField("walkAudio", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, walkAudio);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}