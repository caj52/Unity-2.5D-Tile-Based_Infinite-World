using UnityEngine;
public class Initilizations : MonoBehaviour
{
    public OverWorldTextureManager overWorldTextureManager;
    public OverWorldMesh overWorldMesh;
    public OceanManager oceanManager;
    public WorldInit worldInit;
    public HeightMapManager heightMapManager;
    public OverWorldObjectManager overWorldObjectManager;
    public void Start()
    {
        Init();
    }

    private void Init()
    {
        Debug.Log("Game Init");
        ObjectTypes.Init();
        worldInit.Init();
        overWorldMesh.Init();
        oceanManager.Init();
        overWorldTextureManager.Init();
        heightMapManager.Init();
        overWorldObjectManager.Init();
        StartCoroutine(worldInit.CreateWorldMesh());
    }
}
