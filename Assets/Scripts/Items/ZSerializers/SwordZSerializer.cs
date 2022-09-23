[System.Serializable]
public sealed class SwordZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Single swingTime;
    public UnityEngine.Vector3 ROTs;
    public UnityEngine.Vector3 MOVs;
    public UnityEngine.Vector3 POS;
    public UnityEngine.Vector3 ROT;
    public System.Int32 ID;
    public System.Int32 value;
    public System.Boolean weapon;
    public System.Boolean gun;
    public System.Boolean twoHanded;
    public System.Boolean consumable;
    public System.Single charge;
    public System.Single useDelay;
    public System.Boolean rechargeable;
    public System.Single rechargeTime;
    public System.Single rechargeSpeed;
    public System.Int32 maxUses;
    public System.Int32 uses;
    public System.Single lifeTime;
    public System.Single life;
    public System.String itemName;
    public System.String description;
    public System.Boolean equiped;
    public System.Int32 slot;
    public UnityEngine.GameObject prefab;
    public System.Single noiseRange;
    public System.Single timer;
    public System.Int32 audioIndex;
    public System.Single volume;
    public UnityEngine.LayerMask targetMask;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public SwordZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         swingTime = (System.Single)typeof(Sword).GetField("swingTime").GetValue(instance);
         ROTs = (UnityEngine.Vector3)typeof(Sword).GetField("ROTs").GetValue(instance);
         MOVs = (UnityEngine.Vector3)typeof(Sword).GetField("MOVs").GetValue(instance);
         POS = (UnityEngine.Vector3)typeof(Sword).GetField("POS").GetValue(instance);
         ROT = (UnityEngine.Vector3)typeof(Sword).GetField("ROT").GetValue(instance);
         ID = (System.Int32)typeof(Item).GetField("ID").GetValue(instance);
         value = (System.Int32)typeof(Item).GetField("value").GetValue(instance);
         weapon = (System.Boolean)typeof(Item).GetField("weapon").GetValue(instance);
         gun = (System.Boolean)typeof(Item).GetField("gun").GetValue(instance);
         twoHanded = (System.Boolean)typeof(Item).GetField("twoHanded").GetValue(instance);
         consumable = (System.Boolean)typeof(Item).GetField("consumable").GetValue(instance);
         charge = (System.Single)typeof(Item).GetField("charge").GetValue(instance);
         useDelay = (System.Single)typeof(Item).GetField("useDelay").GetValue(instance);
         rechargeable = (System.Boolean)typeof(Item).GetField("rechargeable").GetValue(instance);
         rechargeTime = (System.Single)typeof(Item).GetField("rechargeTime").GetValue(instance);
         rechargeSpeed = (System.Single)typeof(Item).GetField("rechargeSpeed").GetValue(instance);
         maxUses = (System.Int32)typeof(Item).GetField("maxUses").GetValue(instance);
         uses = (System.Int32)typeof(Item).GetField("uses").GetValue(instance);
         lifeTime = (System.Single)typeof(Item).GetField("lifeTime").GetValue(instance);
         life = (System.Single)typeof(Item).GetField("life").GetValue(instance);
         itemName = (System.String)typeof(Item).GetField("itemName").GetValue(instance);
         description = (System.String)typeof(Item).GetField("description").GetValue(instance);
         equiped = (System.Boolean)typeof(Item).GetField("equiped").GetValue(instance);
         slot = (System.Int32)typeof(Item).GetField("slot").GetValue(instance);
         prefab = (UnityEngine.GameObject)typeof(Item).GetField("prefab").GetValue(instance);
         noiseRange = (System.Single)typeof(Item).GetField("noiseRange").GetValue(instance);
         timer = (System.Single)typeof(Item).GetField("timer").GetValue(instance);
         audioIndex = (System.Int32)typeof(Item).GetField("audioIndex").GetValue(instance);
         volume = (System.Single)typeof(Item).GetField("volume").GetValue(instance);
         targetMask = (UnityEngine.LayerMask)typeof(Item).GetField("targetMask").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(Sword).GetField("swingTime").SetValue(component, swingTime);
         typeof(Sword).GetField("ROTs").SetValue(component, ROTs);
         typeof(Sword).GetField("MOVs").SetValue(component, MOVs);
         typeof(Sword).GetField("POS").SetValue(component, POS);
         typeof(Sword).GetField("ROT").SetValue(component, ROT);
         typeof(Item).GetField("ID").SetValue(component, ID);
         typeof(Item).GetField("value").SetValue(component, value);
         typeof(Item).GetField("weapon").SetValue(component, weapon);
         typeof(Item).GetField("gun").SetValue(component, gun);
         typeof(Item).GetField("twoHanded").SetValue(component, twoHanded);
         typeof(Item).GetField("consumable").SetValue(component, consumable);
         typeof(Item).GetField("charge").SetValue(component, charge);
         typeof(Item).GetField("useDelay").SetValue(component, useDelay);
         typeof(Item).GetField("rechargeable").SetValue(component, rechargeable);
         typeof(Item).GetField("rechargeTime").SetValue(component, rechargeTime);
         typeof(Item).GetField("rechargeSpeed").SetValue(component, rechargeSpeed);
         typeof(Item).GetField("maxUses").SetValue(component, maxUses);
         typeof(Item).GetField("uses").SetValue(component, uses);
         typeof(Item).GetField("lifeTime").SetValue(component, lifeTime);
         typeof(Item).GetField("life").SetValue(component, life);
         typeof(Item).GetField("itemName").SetValue(component, itemName);
         typeof(Item).GetField("description").SetValue(component, description);
         typeof(Item).GetField("equiped").SetValue(component, equiped);
         typeof(Item).GetField("slot").SetValue(component, slot);
         typeof(Item).GetField("prefab").SetValue(component, prefab);
         typeof(Item).GetField("noiseRange").SetValue(component, noiseRange);
         typeof(Item).GetField("timer").SetValue(component, timer);
         typeof(Item).GetField("audioIndex").SetValue(component, audioIndex);
         typeof(Item).GetField("volume").SetValue(component, volume);
         typeof(Item).GetField("targetMask").SetValue(component, targetMask);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}