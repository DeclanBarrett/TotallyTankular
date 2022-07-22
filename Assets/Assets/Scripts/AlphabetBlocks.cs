using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetBlocks : MonoBehaviour
{

    public GameObject[] alphaBlocksGraphics;
    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, alphaBlocksGraphics.Length - 1);
        GameObject alphaBlock = Instantiate(alphaBlocksGraphics[i], this.transform);
        alphaBlock.transform.localScale = new Vector3( 1f, 1f, 1f);
    }
}
