#region Using Statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

#endregion

namespace HoneyCube.Editor.Commands
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ChangePropertyCommand<T> : UICommand
    {
        #region Fields

        private Component _component;

        private Func<T> _getter;
        private Action<T> _setter;

        #endregion

        #region Properties

        /// <summary>
        /// TODO
        /// </summary>
        public Component Component
        {
            get { return _component; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public EventHandler ValueChanged;

        #endregion

        #region Constructor

        /// <summary>
        /// TODO: Allow to change more than one property per inheriting class
        /// </summary>
        /// <param name="property"></param>
        /// <param name="component"></param>
        public ChangePropertyCommand(string property, Component component)
        {
            _component = component;

            CreateDelegates(property);
        }

        /// <summary>
        /// TODO
        /// </summary>
        private void CreateDelegates(string propertyName)
        {
            PropertyInfo property = _component.GetType().GetProperty(propertyName);

            if (property != null)
            {
                if (property.PropertyType.Equals(typeof(T)))
                {
                    MethodInfo get = property.GetGetMethod();
                    MethodInfo set = property.GetSetMethod();

                    if (get != null && get.IsPublic && set != null && set.IsPublic)
                    {
                        _getter = (Func<T>)Delegate.CreateDelegate(typeof(Func<T>), _component, get);
                        _setter = (Action<T>)Delegate.CreateDelegate(typeof(Action<T>), _component, set);
                    }
                    else
                    {
                        throw new ArgumentException("The specified property is not publicly accessible");
                    }
                }
                else
                {
                    throw new ArgumentException("The specified property is of the wrong type");
                }
            }
            else
            {
                throw new ArgumentException("The specified component does not have a property named " + propertyName);
            }
                
        }

        #endregion

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public T GetPropertyValue()
        {
            return _getter();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="newValue"></param>
        public void SetPropertyValue(T newValue)
        {
            T current = GetPropertyValue();

            if (!current.Equals(newValue))
            {
                _setter(newValue);
                OnValueChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }
    }
}
