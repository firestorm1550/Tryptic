using UnityEngine;
using UnityEngine.UI;


[ExecuteAlways]
[RequireComponent(typeof(GridLayoutGroup))]
public class EditorGridController : MonoBehaviour
{
    public RectTransform myRectTransform;
    public GridLayoutGroup gridLayoutGroup;


    private void Awake()
    {
        if(Application.isPlaying)
            gridLayoutGroup.spacing = -gridLayoutGroup.cellSize;
    }

    // Update is called once per frame
    void Update()
    {
        gridLayoutGroup.cellSize = myRectTransform.rect.size;
    }
}
