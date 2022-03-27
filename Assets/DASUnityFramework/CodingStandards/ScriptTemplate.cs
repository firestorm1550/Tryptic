using System;
using UnityEngine;

namespace DASUnityFramework.CodingStandards
{
    public class ScriptTemplate : MonoBehaviour
    {
        //========== Public Constants =====================================================================================
        public const int PublicConstant = 1;
    
        //========== Private Constants ====================================================================================
        private const int PrivateConstant = 1;
    
        //========== Public Static Properties =============================================================================
        public static int PublicStaticProperty => 1;
    
        //========== Private Static Properties ============================================================================
        private static int PrivateStaticProperty => 1;
    
        //========== Public Static Fields =================================================================================
        public static int PublicStaticField;
    
        //========== Private Static Fields ================================================================================
        private static int PrivateStaticField;
    
        //========== Public Properties ====================================================================================
        public int PublicProperty => 1;
    
        //========== Private Properties ===================================================================================
        private int PrivateProperty => 1;
    
        //========== Serialized Fields ====================================================================================
        public int publicSerializedField;
        [SerializeField] private int privateSerializedField;
    
        //========== Public Fields ========================================================================================
        [NonSerialized] public int PublicNonSerializedField;//this being capitalized is a little odd, but it seems to be the C# standard.
    
        //========== Private Fields =======================================================================================
        private int _privateField;
    
        //========== Unity Life-Cycle Methods =============================================================================
        private void Awake()
        {
        
        }
    
        private void Start()
        {
        
        }

        private void OnEnable()
        {
        
        }

        private void OnDisable()
        {
        
        }

        private void Update()
        {
        
        }
    
        private void LateUpdate()
        {
        
        }

        private void FixedUpdate()
        {
        
        }

        private void OnDestroy()
        {
        
        }
    
        //these are a subset of public methods. They are the methods used in the unity editor
        //========== Event Listener Methods ===============================================================================
        public void OnClickTheButton()
        {
        
        }

        public void OnToggleValueChanged(bool value)
        {
        
        }
    
        //========== Public Static Methods ================================================================================
        public static void PublicStaticMethod(int param)
        {
        
        }
    
        //========== Private Static Methods ===============================================================================
        private static void PrivateStaticMethod(int param)
        {
        
        }
    
        //========== Public Methods =======================================================================================
        public void PublicMethod(int param)
        {
        
        }
    
        //========== Private Methods ======================================================================================
        public void PrivateMethod(int param)
        {
        
        }
    }
}
