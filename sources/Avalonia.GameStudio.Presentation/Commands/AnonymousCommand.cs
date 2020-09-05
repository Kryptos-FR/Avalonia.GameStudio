﻿using System;
using System.Threading.Tasks;

using Avalonia.GameStudio.Core.Extensions;

namespace Avalonia.GameStudio.Presentation.Commands
{
    /// <summary>
    /// An implementation of <see cref="CommandBase"/> that routes <see cref="Execute"/> calls to a given anonymous method.
    /// </summary>
    /// <seealso cref="AnonymousCommand{T}"/>
    public class AnonymousCommand : CommandBase
    {
        private readonly Func<bool>? canExecute;
        private readonly Action<object?> action;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousCommand"/> class.
        /// </summary>
        /// <param name="action">An anonymous method that will be called each time the command is executed.</param>
        /// <param name="canExecute">An anonymous method that will be called each time the command <see cref="CommandBase.CanExecute(object)"/> method is invoked.</param>
        public AnonymousCommand(Action action, Func<bool>? canExecute = null)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));
            this.action = x => action();
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousCommand"/> class.
        /// </summary>
        /// <param name="action">An anonymous method that will be called each time the command is executed.</param>
        /// <param name="canExecute">An anonymous method that will be called each time the command <see cref="CommandBase.CanExecute(object)"/> method is invoked.</param>
        public AnonymousCommand(Action<object?> action, Func<bool>? canExecute = null)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));
            this.action = action;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Executes the command, and thus the anonymous method provided to the constructor.
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        /// <seealso cref="AnonymousCommand{T}"/>
        public override void Execute(object? parameter)
        {
            action(parameter);
        }

        /// <summary>
        /// Indicates whether the command can be executed. Returns <c>true</c> if <see cref="CommandBase.IsEnabled"/> is <c>true</c> and either a <see cref="Func{Bool}"/>
        /// was provided to the constructor, and this function returns <c>true</c>, or no <see cref="Func{Bool}"/> was provided (or a <c>null</c> function).
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        /// <returns><c>true</c> if the command can be executed, <c>false</c> otherwise.</returns>
        public override bool CanExecute(object? parameter)
        {
            var result = base.CanExecute(parameter);
            return result && canExecute is not null ? canExecute() : result;
        }
    }

    /// <summary>
    /// An implementation of <see cref="CommandBase"/> that routes <see cref="AnonymousCommand.Execute(object)"/> calls to a given anonymous task.
    /// </summary>
    /// <seealso cref="AnonymousCommand{T}"/>
    public class AnonymousTaskCommand : AnonymousCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousCommand"/> class.
        /// </summary>
        /// <param name="task">A method returning a task that will be called each time the command is executed.</param>
        /// <param name="canExecute">An anonymous method that will be called each time the command <see cref="CommandBase.CanExecute(object)"/> method is invoked.</param>
        public AnonymousTaskCommand(Func<Task> task, Func<bool>? canExecute = null)
            : base(x => task().Forget(), canExecute)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));
        }
    }

    /// <summary>
    /// An implementation of <see cref="CommandBase"/> that routes <see cref="Execute"/> calls to a given anonymous method with a typed parameter.
    /// </summary>
    /// <typeparam name="T">The type of parameter to use with the command.</typeparam>
    /// <seealso cref="AnonymousCommand"/>
    public class AnonymousCommand<T> : CommandBase
    {
        private readonly Action<T?> action;
        private readonly Func<T?, bool>? canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousCommand{T}"/> class.
        /// </summary>
        /// <param name="action">An anonymous method with a typed parameter that will be called each time the command is executed.</param>
        /// <param name="canExecute">An anonymous method that will be called each time the command <see cref="CommandBase.CanExecute(object)"/> method is invoked.</param>
        public AnonymousCommand(Action<T?> action, Func<T?, bool>? canExecute = null)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));
            this.action = action;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Executes the command, and thus the anonymous method provided to the constructor.
        /// </summary>
        /// <seealso cref="AnonymousCommand"/>
        public override void Execute(object? parameter)
        {
            // allow to make the parameter optional: if not set it will fall back to the default value of the type (work for both class and value type)
            parameter ??= default(T);
            // check the type
            if ((typeof(T).IsValueType || parameter is not null) && parameter is not T)
                throw new ArgumentException(@"Unexpected parameter type in the command.", nameof(parameter));

            action((T)parameter);
        }

        /// <summary>
        /// Indicates whether the command can be executed. Returns <c>true</c> if <see cref="CommandBase.IsEnabled"/> is <c>true</c> and either a <see cref="Func{T, Bool}"/>
        /// was provided to the constructor, and this function returns <c>true</c>, or no <see cref="Func{T, Bool}"/> was provided (or a <c>null</c> function).
        /// </summary>
        /// <param name="parameter">The command parameter.</param>
        /// <returns><c>true</c> if the command can be executed, <c>false</c> otherwise.</returns>
        public override bool CanExecute(object? parameter)
        {
            parameter ??= default(T);
            if ((typeof(T).IsValueType || parameter is not null) && parameter is not T)
                throw new ArgumentException(@"Unexpected parameter type in the command.", nameof(parameter));

            var result = base.CanExecute(parameter);
            return result && canExecute is not null ? canExecute((T)parameter) : result;
        }
    }

    /// <summary>
    /// An implementation of <see cref="CommandBase"/> that routes <see cref="AnonymousCommand{T}.Execute(object)"/> calls to a given anonymous method with a typed parameter.
    /// </summary>
    /// <typeparam name="T">The type of parameter to use with the command.</typeparam>
    /// <seealso cref="AnonymousTaskCommand"/>
    public class AnonymousTaskCommand<T> : AnonymousCommand<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousCommand"/> class.
        /// </summary>
        /// <param name="task">A method with a typed parameter returning a task that will be called each time the command is executed.</param>
        /// <param name="canExecute">An anonymous method that will be called each time the command <see cref="CommandBase.CanExecute(object)"/> method is invoked.</param>
        public AnonymousTaskCommand(Func<T?, Task> task, Func<T?, bool>? canExecute = null)
            : base(x => task(x).Forget(), canExecute)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));
        }
    }
}
