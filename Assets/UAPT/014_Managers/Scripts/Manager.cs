using BIS.Managers;
using UnityEngine;

namespace BIS.Managers
{
    public class Manager : MonoBehaviour
    {
        private static Manager s_instacne;
        private static Manager Instacne
        {
            get
            {
                Init();
                return s_instacne;
            }
        }

        private ResourceManager _resource = new ResourceManager();
        private UIManager _ui = new UIManager();

        public static ResourceManager Resource { get { return Instacne._resource; } }
        public static UIManager UI { get { return Instacne._ui; } }


        private static void Init()
        {
            if (s_instacne == null)
            {
                GameObject go = GameObject.Find("@Managers");
                if (go == null)
                {
                    go = new GameObject { name = "@Managers" };
                    go.AddComponent<Manager>();
                }

                DontDestroyOnLoad(go);

                //√ ±‚»≠
                s_instacne = go.GetComponent<Manager>();
            }
        }
    }

}
