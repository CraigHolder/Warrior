[System.Serializable]
public sealed class ContainerZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Collections.Generic.List<Item> Items;
    public System.Int32 index;
    public Info info;
    public System.Boolean drop;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public ContainerZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         Items = (System.Collections.Generic.List<Item>)typeof(Container).GetField("Items").GetValue(instance);
         index = (System.Int32)typeof(Container).GetField("index").GetValue(instance);
         info = (Info)typeof(Container).GetField("info").GetValue(instance);
         drop = (System.Boolean)typeof(Container).GetField("drop").GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(Container).GetField("Items").SetValue(component, Items);
         typeof(Container).GetField("index").SetValue(component, index);
         typeof(Container).GetField("info").SetValue(component, info);
         typeof(Container).GetField("drop").SetValue(component, drop);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}