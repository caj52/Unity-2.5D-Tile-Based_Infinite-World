using UnityEngine;
public class Initilizations : MonoBehaviour
{
    public OverWorldTextureManager overWorldTextureManager;
    public OverWorldMesh overWorldMesh;
    public OceanManager oceanManager;
    public WorldInit worldInit;
    public HeightMapManager heightMapManager;
    public OverWorldObjectManager overWorldObjectManager;
    public Player player;
    public PlayerHealth playerHealth;
    public InteractionsPool interactionsPool;
    public QuickAccessInventory quickAccessInventory;
    public ToolBarSelectionHand toolBarSelectionHand;
    public InteractionPoolMouseSelection interactionPoolMouseSelection;
    public HUDTextBox hudDialogueBox;
    public HungerIcon hungerIcon;
    public void Start()
    {
        Init();
    }

    private void Init()
    {
        Debug.Log("Game Init");
        worldInit.Init();
        overWorldMesh.Init();
        oceanManager.Init();
        overWorldTextureManager.Init();
        heightMapManager.Init();
        overWorldObjectManager.Init();
        StartCoroutine(worldInit.CreateWorldMesh());
        playerHealth.Init();
        quickAccessInventory.Init();
        player.Init();
        interactionsPool.Init();
        toolBarSelectionHand.Init();
        interactionPoolMouseSelection.Init();
        hudDialogueBox.Init();
        hungerIcon.Init();
    }
}
