using UnityEngine;

public class CellDisplayer : MonoBehaviour
{
    RaycastHit hit;
    Vector3 point = new Vector3();


    [field: SerializeField] public GameObject Cell { get; set; }
    // x je 45,5 - -25,5
    // y je 83,5 - 4,5
    // z je 44 - -32

    private void Awake()
    {

    }
    private void Start()
    {
        GenerateCells();
    }
    void GenerateCells()
    {
        // floatové hodnoty vynásobím 10 abych nemusel používat float v cyklu
        // projdu x
        for (float i = 45.5f; i > -28.5f; i -= 0.25f)
        {
            //projdu z
            for (float j = 44f; j > -32f; j -= 0.25f)
            {

                GenerateCellDown(i, 83.5f, j );
                GenerateCellUp(i, 4.5f, j);


            }

        }
    }
    void GenerateCellDown(float x, float y, float z)
    {      
             
        if (Physics.Raycast(new Vector3(x, y, z), Vector3.down, out hit) && y > 4.5f)
        {
            point = hit.point;
            
            Instantiate(Cell, point, Quaternion.identity);
            GenerateCellDown(x, point.y - 0.25f, z);
        }
        return;

    }
    void GenerateCellUp(float x, float y, float z)
    {        

        if (Physics.Raycast(new Vector3(x, y, z), Vector3.up, out hit) && y < 83.5f)
        {
            point = hit.point;

            Instantiate(Cell, point, Quaternion.identity);
            GenerateCellUp(x, point.y + 0.25f, z);
        }
        return;

    }
    //


}
