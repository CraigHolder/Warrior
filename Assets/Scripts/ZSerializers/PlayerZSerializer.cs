[System.Serializable]
public sealed class PlayerZSerializer : ZSerializer.Internal.ZSerializer
{
    public System.Int32 Dex;
    public System.Single speed;
    public System.Single currSpeed;
    public UnityEngine.UI.Slider painSlider;
    public UnityEngine.UI.Slider WaterSlider;
    public System.Boolean thirdPerson;
    public UnityEngine.Camera cam;
    public UnityEngine.LayerMask layerMask;
    public System.Single lookSpeed;
    public UnityEngine.Vector2 rotation;
    public System.Int32 selectedHotbar;
    public TMPro.TMP_Text infoText;
    public Item selected;
    public System.Boolean movingItem;
    public System.Boolean sellingItem;
    public Item[] Hotbar;
    public System.Collections.Generic.List<UnityEngine.GameObject> hotBarOBJs;
    public System.Collections.Generic.List<UnityEngine.GameObject> hotBarBackOBJs;
    public TMPro.TMP_Text ammoText;
    public TMPro.TMP_Text movingText;
    public Player.State currState;
    public System.Single PainThreshhold;
    public System.Single Pain;
    public System.Int32 HeadArmor;
    public System.Int32 LegArmor;
    public System.Int32 ChestArmor;
    public System.Int32 ArmArmor;
    public System.Boolean disarmed;
    public System.Single jumpHeight;
    public System.Single gravity;
    public UnityEngine.AudioSource walkAudio;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public PlayerZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         Dex = (System.Int32)typeof(Player).GetField("Dex").GetValue(instance);
         speed = (System.Single)typeof(Player).GetField("speed").GetValue(instance);
         currSpeed = (System.Single)typeof(Player).GetField("currSpeed").GetValue(instance);
         painSlider = (UnityEngine.UI.Slider)typeof(Player).GetField("painSlider").GetValue(instance);
         WaterSlider = (UnityEngine.UI.Slider)typeof(Player).GetField("WaterSlider").GetValue(instance);
         thirdPerson = (System.Boolean)typeof(Player).GetField("thirdPerson").GetValue(instance);
         cam = (UnityEngine.Camera)typeof(Player).GetField("cam").GetValue(instance);
         layerMask = (UnityEngine.LayerMask)typeof(Player).GetField("layerMask").GetValue(instance);
         lookSpeed = (System.Single)typeof(Player).GetField("lookSpeed").GetValue(instance);
         rotation = (UnityEngine.Vector2)typeof(Player).GetField("rotation").GetValue(instance);
         selectedHotbar = (System.Int32)typeof(Player).GetField("selectedHotbar").GetValue(instance);
         infoText = (TMPro.TMP_Text)typeof(Player).GetField("infoText").GetValue(instance);
         selected = (Item)typeof(Player).GetField("selected").GetValue(instance);
         movingItem = (System.Boolean)typeof(Player).GetField("movingItem").GetValue(instance);
         sellingItem = (System.Boolean)typeof(Player).GetField("sellingItem").GetValue(instance);
         Hotbar = (Item[])typeof(Player).GetField("Hotbar").GetValue(instance);
         hotBarOBJs = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(Player).GetField("hotBarOBJs").GetValue(instance);
         hotBarBackOBJs = (System.Collections.Generic.List<UnityEngine.GameObject>)typeof(Player).GetField("hotBarBackOBJs").GetValue(instance);
         ammoText = (TMPro.TMP_Text)typeof(Player).GetField("ammoText").GetValue(instance);
         movingText = (TMPro.TMP_Text)typeof(Player).GetField("movingText").GetValue(instance);
         currState = (Player.State)typeof(Player).GetField("currState").GetValue(instance);
         PainThreshhold = (System.Single)typeof(Player).GetField("PainThreshhold").GetValue(instance);
         Pain = (System.Single)typeof(Player).GetField("Pain").GetValue(instance);
         HeadArmor = (System.Int32)typeof(Player).GetField("HeadArmor").GetValue(instance);
         LegArmor = (System.Int32)typeof(Player).GetField("LegArmor").GetValue(instance);
         ChestArmor = (System.Int32)typeof(Player).GetField("ChestArmor").GetValue(instance);
         ArmArmor = (System.Int32)typeof(Player).GetField("ArmArmor").GetValue(instance);
         disarmed = (System.Boolean)typeof(Player).GetField("disarmed").GetValue(instance);
         jumpHeight = (System.Single)typeof(Player).GetField("jumpHeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         gravity = (System.Single)typeof(Player).GetField("gravity", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         walkAudio = (UnityEngine.AudioSource)typeof(Player).GetField("walkAudio", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(Player).GetField("Dex").SetValue(component, Dex);
         typeof(Player).GetField("speed").SetValue(component, speed);
         typeof(Player).GetField("currSpeed").SetValue(component, currSpeed);
         typeof(Player).GetField("painSlider").SetValue(component, painSlider);
         typeof(Player).GetField("WaterSlider").SetValue(component, WaterSlider);
         typeof(Player).GetField("thirdPerson").SetValue(component, thirdPerson);
         typeof(Player).GetField("cam").SetValue(component, cam);
         typeof(Player).GetField("layerMask").SetValue(component, layerMask);
         typeof(Player).GetField("lookSpeed").SetValue(component, lookSpeed);
         typeof(Player).GetField("rotation").SetValue(component, rotation);
         typeof(Player).GetField("selectedHotbar").SetValue(component, selectedHotbar);
         typeof(Player).GetField("infoText").SetValue(component, infoText);
         typeof(Player).GetField("selected").SetValue(component, selected);
         typeof(Player).GetField("movingItem").SetValue(component, movingItem);
         typeof(Player).GetField("sellingItem").SetValue(component, sellingItem);
         typeof(Player).GetField("Hotbar").SetValue(component, Hotbar);
         typeof(Player).GetField("hotBarOBJs").SetValue(component, hotBarOBJs);
         typeof(Player).GetField("hotBarBackOBJs").SetValue(component, hotBarBackOBJs);
         typeof(Player).GetField("ammoText").SetValue(component, ammoText);
         typeof(Player).GetField("movingText").SetValue(component, movingText);
         typeof(Player).GetField("currState").SetValue(component, currState);
         typeof(Player).GetField("PainThreshhold").SetValue(component, PainThreshhold);
         typeof(Player).GetField("Pain").SetValue(component, Pain);
         typeof(Player).GetField("HeadArmor").SetValue(component, HeadArmor);
         typeof(Player).GetField("LegArmor").SetValue(component, LegArmor);
         typeof(Player).GetField("ChestArmor").SetValue(component, ChestArmor);
         typeof(Player).GetField("ArmArmor").SetValue(component, ArmArmor);
         typeof(Player).GetField("disarmed").SetValue(component, disarmed);
         typeof(Player).GetField("jumpHeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, jumpHeight);
         typeof(Player).GetField("gravity", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, gravity);
         typeof(Player).GetField("walkAudio", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, walkAudio);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}