using System;

namespace Patterns
{
    // 1:M
    // instance is changed -> anothers are evented
    // pull-, push-model
    // ways of implementation: 
    // - delegates (1:1), 
    // - events (does not require results from subscribers; pull-model?), 
    // - interfaces, 
    // - IObserver/IObservable(pushbased)
    #region Interfaces
    interface IObserver<T>
    {
        void OnChange(IObservable<T> sender, T info);
    }

    interface IObservable<T>
    {
        void Subscribe(IObserver<T> observer);
        void Unsubscribe(IObserver<T> observer);
        void Notify();
    }
    #endregion

    #region Delegates
    public class SomeClassforDelegate<T>
    {
        private T _smth;

        public T Smth
        {
            get
            {
                return _smth;
            }
            set
            {
                _smth = value;
                OnSmthChange(value);
            }
        }

        public Action<T> SmthChange { get; set; }

        protected virtual void OnSmthChange(T value)
        {
            SmthChange?.Invoke(value);
        }
    }

    public abstract class BaseObserverforDelegate<T, U> where T : SomeClassforDelegate<U>
    {
        public void Register(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            obj.SmthChange += SmthChange;
        }
        
        public void UnRegister(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            obj.SmthChange -= SmthChange;
        }
        
        protected abstract void SmthChange(U info);
    }
    #endregion
}
