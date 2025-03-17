using BIS.Managers;
using UnityEngine;

namespace BIS.UI
{
    public class SceneUI : UIBase
    {
        public override bool Init()
        {
            if (base.Init() == false)
                return false;


            Manager.UI.SetCanvas(gameObject, false);
            return true;
        }
    }
}
