using UnityEngine;

namespace BIS.Define
{
    public static class Define
    {
        public const float UIDuration = 0.5f;
        public enum EUIEventType
        {
            DOWN,
            MOVE,
            ENTER,
            EXIT,
            CLICK,
            FLOAT
        }

    }
    public enum EMainTabbar
    {
        MISSION,
        SKILL,
        APPEARANCE,
        PLAYGROUND,
        PROGRESSION
    }
    public enum EModelType
    {
        Int,
        Float,
        Bool
    }

    public enum EUIEvent    
    {
        Click,
        PointerDown,
        PointerUp,
        Drag,
        PointerEnter,
        PointerExit
    }
    public enum EScene
    {
        Unknown,
        TitleScene,
        GameScene
    }

    public enum ERarity
    {

    }
}

