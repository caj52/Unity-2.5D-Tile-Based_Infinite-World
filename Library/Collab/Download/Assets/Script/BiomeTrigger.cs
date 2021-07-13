
using UnityEngine;

public class BiomeTrigger : MonoBehaviour
{
    public CapsuleCollider player;
    public MeshCollider meshc;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<CapsuleCollider>();
       // meshc = transform.GetComponent<MeshCollider>();
    }
    
    public void OnTriggerEnter(Collider player)
    {
        meshc.enabled = true;
    }
    public void OnTriggerExit(Collider player)
    {
        meshc.enabled = false;
    }
}
