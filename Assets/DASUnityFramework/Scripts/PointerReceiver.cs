using UnityEngine;
using UnityEngine.EventSystems;

namespace DASUnityFramework.Scripts
{
    public interface IPointerReceiver : IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler, IDragHandler 
    {
        
    }
}