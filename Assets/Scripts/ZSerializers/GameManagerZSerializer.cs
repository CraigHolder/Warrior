[System.Serializable]
public sealed class GameManagerZSerializer : ZSerializer.Internal.ZSerializer
{
    public GameManager.GameState state;
    public GameManager.GameState prevState;
    public TMPro.TMP_Text WinText;
    public Player player;
    public System.Int32 Gold;
    public System.Collections.Generic.List<Enemy> enemies;
    public System.Collections.Generic.List<Enemy> knockedEnemies;
    public System.Collections.Generic.List<Enemy> surrenderedEnemies;
    public System.Int32 kills;
    public System.Int32 unconscious;
    public System.Int32 surrendered;
    public System.Int32 saveNum;
    public TMPro.TMP_Text controlText;
    public UnityEngine.GameObject solar;
    public TMPro.TMP_Text goldText;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public GameManagerZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         state = (GameManager.GameState)typeof(GameManager).GetField("state").GetValue(instance);
         prevState = (GameManager.GameState)typeof(GameManager).GetField("prevState").GetValue(instance);
         WinText = (TMPro.TMP_Text)typeof(GameManager).GetField("WinText").GetValue(instance);
         player = (Player)typeof(GameManager).GetField("player").GetValue(instance);
         Gold = (System.Int32)typeof(GameManager).GetField("Gold").GetValue(instance);
         enemies = (System.Collections.Generic.List<Enemy>)typeof(GameManager).GetField("enemies").GetValue(instance);
         knockedEnemies = (System.Collections.Generic.List<Enemy>)typeof(GameManager).GetField("knockedEnemies").GetValue(instance);
         surrenderedEnemies = (System.Collections.Generic.List<Enemy>)typeof(GameManager).GetField("surrenderedEnemies").GetValue(instance);
         kills = (System.Int32)typeof(GameManager).GetField("kills").GetValue(instance);
         unconscious = (System.Int32)typeof(GameManager).GetField("unconscious").GetValue(instance);
         surrendered = (System.Int32)typeof(GameManager).GetField("surrendered").GetValue(instance);
         saveNum = (System.Int32)typeof(GameManager).GetField("saveNum").GetValue(instance);
         controlText = (TMPro.TMP_Text)typeof(GameManager).GetField("controlText").GetValue(instance);
         solar = (UnityEngine.GameObject)typeof(GameManager).GetField("solar").GetValue(instance);
         goldText = (TMPro.TMP_Text)typeof(GameManager).GetField("goldText", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(GameManager).GetField("state").SetValue(component, state);
         typeof(GameManager).GetField("prevState").SetValue(component, prevState);
         typeof(GameManager).GetField("WinText").SetValue(component, WinText);
         typeof(GameManager).GetField("player").SetValue(component, player);
         typeof(GameManager).GetField("Gold").SetValue(component, Gold);
         typeof(GameManager).GetField("enemies").SetValue(component, enemies);
         typeof(GameManager).GetField("knockedEnemies").SetValue(component, knockedEnemies);
         typeof(GameManager).GetField("surrenderedEnemies").SetValue(component, surrenderedEnemies);
         typeof(GameManager).GetField("kills").SetValue(component, kills);
         typeof(GameManager).GetField("unconscious").SetValue(component, unconscious);
         typeof(GameManager).GetField("surrendered").SetValue(component, surrendered);
         typeof(GameManager).GetField("saveNum").SetValue(component, saveNum);
         typeof(GameManager).GetField("controlText").SetValue(component, controlText);
         typeof(GameManager).GetField("solar").SetValue(component, solar);
         typeof(GameManager).GetField("goldText", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, goldText);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}