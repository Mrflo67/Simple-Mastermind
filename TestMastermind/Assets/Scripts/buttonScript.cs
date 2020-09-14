using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public GameObject objectToInstantiate;

    public void testInstantiate()
    {
        Instantiate(objectToInstantiate);
    }
}
