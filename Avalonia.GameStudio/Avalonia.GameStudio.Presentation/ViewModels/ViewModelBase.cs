using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Avalonia.GameStudio.Presentation.ViewModels
{
    /// <summary>
    /// This abstract class represents a basic view model, implementing <see cref="INotifyPropertyChanging"/> and <see cref="INotifyPropertyChanged"/> and providing
    /// a set of <b>SetValue</b> helper methods to easly update a property and trigger the change notifications.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanging, INotifyPropertyChanged
    {
#if DEBUG
        private readonly List<string> changingProperties = new List<string>();
#endif

        /// <summary>
        /// A collection of property names that are dependent. For each entry of this collection, if the key property name is notified
        /// as being changed, then the property names in the value will also be notified as being changed.
        /// </summary>
        protected readonly Dictionary<string, string[]> DependentProperties = new Dictionary<string, string[]>();

        protected ViewModelBase()
        {
        }

        /// <summary>
        /// Sets the value of a field to the given value. Both values are compared with the default <see cref="EqualityComparer{T}"/>, and if they are equals,
        /// this method does nothing. If they are different, the <see cref="PropertyChanging"/> event will be raised first, then the field value will be modified,
        /// and finally the <see cref="PropertyChanged"/> event will be raised.
        /// </summary>
        /// <typeparam name="T">The type of the field.</typeparam>
        /// <param name="field">A reference to the field to set.</param>
        /// <param name="value">The new value to set.</param>
        /// <param name="propertyName">The name of the property that must be notified as changing/changed. Can use <see cref="CallerMemberNameAttribute"/>.</param>
        /// <returns><c>True</c> if the field was modified and events were raised, <c>False</c> if the new value was equal to the old one and nothing was done.</returns>
        protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            return SetValue(ref field, value, null, propertyName);
        }

        /// <summary>
        /// Sets the value of a field to the given value. Both values are compared with the default <see cref="EqualityComparer{T}"/>, and if they are equals,
        /// this method does nothing. If they are different, the <see cref="PropertyChanging"/> event will be raised first, then the field value will be modified.
        /// The given update action will be executed and finally the <see cref="PropertyChanged"/> event will be raised.
        /// </summary>
        /// <typeparam name="T">The type of the field.</typeparam>
        /// <param name="field">A reference to the field to set.</param>
        /// <param name="value">The new value to set.</param>
        /// <param name="updateAction">The update action to execute after setting the value. Can be <c>null</c>.</param>
        /// <param name="propertyName">The name of the property that must be notified as changing/changed. Can use <see cref="CallerMemberNameAttribute"/>.</param>
        /// <returns><c>True</c> if the field was modified and events were raised, <c>False</c> if the new value was equal to the old one and nothing was done.</returns>
        protected virtual bool SetValue<T>(ref T field, T value, Action? updateAction, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value) == false)
            {
                OnPropertyChanging(propertyName);
                field = value;
                updateAction?.Invoke();
                OnPropertyChanged(propertyName);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Manages a property modification and its notifications. This method will invoke the provided update action. The <see cref="PropertyChanging"/>
        /// event will be raised prior to the update action, and the <see cref="PropertyChanged"/> event will be raised after.
        /// </summary>
        /// <param name="updateAction">The update action that will actually manage the update of the property.</param>
        /// <param name="propertyName">The name of the property that must be notified as changing/changed. Can use <see cref="CallerMemberNameAttribute"/>.</param>
        /// <returns>This method always returns<c>True</c> since it always performs the update.</returns>
        protected bool SetValue(Action? updateAction, [CallerMemberName] string propertyName = "")
        {
            return SetValue(null, updateAction, propertyName);
        }

        /// <summary>
        /// Manages a property modification and its notifications. The first parameter <see cref="hasChanged"/> should indicate whether the property
        /// should actuallybe updated. If this parameter is <c>True</c>, it will invoke the provided update action. The <see cref="PropertyChanging"/>
        /// event will be raised prior to the update action, and the <see cref="PropertyChanged"/> event will be raised after.
        /// </summary>
        /// <param name="hasChanged">A boolean that indicates whether the update must be actually done. If <c>null</c>, the update is always done.</param>
        /// <param name="updateAction">The update action that will actually manage the update of the property.</param>
        /// <param name="propertyName">The name of the property that must be notified as changing/changed. Can use <see cref="CallerMemberNameAttribute"/>.</param>
        /// <returns>The value provided in the <see cref="hasChanged"/> argument.</returns>
        protected bool SetValue(bool hasChanged, Action? updateAction, [CallerMemberName] string propertyName = "")
        {
            return SetValue(() => hasChanged, updateAction, propertyName);
        }

        /// <summary>
        /// Manages a property modification and its notifications. A function is provided to check whether the new value is different from the current one.
        /// This function will be invoked by this method, and if it returns <c>True</c>, it will invoke the provided update action. The <see cref="PropertyChanging"/>
        /// event will be raised prior to the update action, and the <see cref="PropertyChanged"/> event will be raised after.
        /// </summary>
        /// <param name="hasChangedFunction">A function that check if the new value is different and therefore if the update must be actually done.</param>
        /// <param name="updateAction">The update action that will actually manage the update of the property.</param>
        /// <param name="propertyName">The name of the property that must be notified as changing/changed. Can use <see cref="CallerMemberNameAttribute"/>.</param>
        /// <returns><c>True</c> if the update was done and events were raised, <c>False</c> if <see cref="hasChangedFunction"/> is not <c>null</c> and returned false.</returns>
        protected virtual bool SetValue(Func<bool>? hasChangedFunction, Action? updateAction, [CallerMemberName] string propertyName = "")
        {
            var hasChanged = true;
            if (hasChangedFunction != null)
            {
                hasChanged = hasChangedFunction();
            }
            if (hasChanged)
            {
                OnPropertyChanging(propertyName);
                updateAction?.Invoke();
                OnPropertyChanged(propertyName);
            }
            return hasChanged;
        }

        /// <summary>
        /// This method will raise the <see cref="PropertyChanging"/> for the property name passed as argument.
        /// </summary>
        /// <param name="propertyName">The name of the property that is changing.</param>
        protected virtual void OnPropertyChanging(string propertyName)
        {
            var propertyChanging = PropertyChanging;
#if DEBUG
            if (changingProperties.Contains(propertyName))
                throw new InvalidOperationException($"OnPropertyChanging called twice for property '{propertyName}' without invoking OnPropertyChanged between calls.");

            changingProperties.Add(propertyName);
#endif

            propertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));

            if (DependentProperties.TryGetValue(propertyName, out string[]? dependentProperties))
                foreach (var dependentProperty in dependentProperties)
                    OnPropertyChanging(dependentProperty);
        }

        /// <summary>
        /// This method will raise the <see cref="PropertyChanged"/> for the property name passed as argument.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;

            if (DependentProperties.TryGetValue(propertyName, out string[]? dependentProperties))
                for (var i = dependentProperties.Length - 1; i >= 0; i--)
                    OnPropertyChanged(dependentProperties[i]);

            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

#if DEBUG
            if (!changingProperties.Contains(propertyName))
                throw new InvalidOperationException($"OnPropertyChanged called for property '{propertyName}' but OnPropertyChanging was not invoked before.");

            changingProperties.Remove(propertyName);
#endif
        }

        protected bool HasPropertyChangingSubscriber => PropertyChanging != null;

        protected bool HasPropertyChangedSubscriber => PropertyChanged != null;

        /// <inheritdoc/>
        public event PropertyChangingEventHandler? PropertyChanging;

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
