using UnityEngine;

namespace Engine.Scripts.Common.Extensions
{
    public static class MethodExtensionForMonoBehaviourTransform
    {
        public static T GetOrAddComponent<T> (this Component child) where T: Component
        {
            return child.GetComponent<T>() ?? child.gameObject.AddComponent<T>();
        }
    }
}
