using UnityEngine;
public class MainStart : MonoBehaviour
{

    public void Start()
    {
         Debug.Log("True Game Start");
         StartCoroutine(WorldInit.Instance.CreateWorldMesh());
    }
}
