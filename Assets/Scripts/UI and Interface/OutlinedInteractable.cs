
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace ClayTargetShooting
{
    public class OutlinedInteractable : Interactable
    {
        
        [SerializeField]
        public UnityEvent onInteractEvent;
        private Outline _outline;
        void Start()
        {
            _outline = gameObject.AddComponent<Outline>();

            _outline.OutlineMode = Outline.Mode.OutlineAll;
            _outline.OutlineColor = Color.yellow;
            _outline.OutlineWidth = 5f;
            _outline.enabled = false;
        }
        public override void Interact()
        {
            onInteractEvent.Invoke();
        }

        public override void OnEndFoundAction()
        {
            _outline.enabled = false;
        }

        public override void OnFoundAction()
        {
            _outline.enabled = true;
        }
    }
}
