using Unity.VisualScripting;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    private int depth = 1;

    [SerializeField]private int max = 4;
    
    
    void Start()
    {
        if(max>=1 && max!= depth)   
        GenerateNextFractual();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateNextFractual()
    {


        float parentSize = gameObject.transform.localScale.x;
        float childSize = parentSize *=0.5f;

        float offset = (float)(parentSize * 0.5 + childSize);

        Vector3[] directions =
        {
            transform.up, -transform.up, transform.forward, -transform.forward, transform.right, - transform.right
        };


        foreach(Vector3 direction in directions)
        {
            Vector3 spawnPoint = transform.position + direction * offset;

            GameObject childObj = Instantiate(gameObject, spawnPoint, transform.rotation);

            childObj.transform.localScale = Vector3.one * childSize;

            childObj.GetComponent<Fractal>().SetDepth(depth+1);
        }

        //GameObject tempCube1 = Instantiate(tempCube, tempCube.transform.position + TempVect, tempCube.transform.rotation );
        //tempCube1.GetComponent<Fractal>().SetMax(max + 1);
        //GameObject tempCube2 = Instantiate(tempCube, tempCube.transform.position + -TempVect, tempCube.transform.rotation );

        //TempVect = tempCube.transform.up * parentSize;

        //GameObject tempCube3 = Instantiate(tempCube, tempCube.transform.position + TempVect, tempCube.transform.rotation);
        //GameObject tempCube4 = Instantiate(tempCube, tempCube.transform.position + -TempVect, tempCube.transform.rotation);

        //TempVect = tempCube.transform.right * parentSize;

        //GameObject tempCube5 = Instantiate(tempCube, tempCube.transform.position + TempVect, tempCube.transform.rotation);
        //GameObject tempCube6 = Instantiate(tempCube, tempCube.transform.position + -TempVect, tempCube.transform.rotation);










    }

    void SetDepth(int depth)
    {
        this.depth = depth;
    }
}
