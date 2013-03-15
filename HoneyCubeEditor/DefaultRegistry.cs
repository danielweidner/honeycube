﻿#region Using Statements

using System;
using System.Windows.Forms;
using HoneyCube.Editor.Commands;
using HoneyCube.Editor.Events;
using HoneyCube.Editor.Presenter;
using HoneyCube.Editor.Services;
using HoneyCube.Editor.Views;
using StructureMap.Configuration.DSL;
using HoneyCube.Editor.Input;

#endregion

namespace HoneyCube.Editor
{
    /// <summary>
    /// The DefaultRegistry contains all methods and grammars to configurate the 
    /// StructureMap container.
    /// </summary>
    public class DefaultRegistry : Registry
    {
        /// <summary>
        /// Public constructor. Creates the default registry used to setup the
        /// IoC container.
        /// </summary>
        public DefaultRegistry()
        {
            #region Core Modules

            // For all objects implementing the generic IEventHandler interface...
            IfTypeMatches(type =>
            {
                Type handlerType = typeof(IEventHandler<>);

                foreach (Type interfaceType in handlerType.GetInterfaces())
                {
                    if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == handlerType)
                        return true;
                }

                return false;
            })

            // ...register each event handler on the mediator
            .InterceptWith((context, handler) =>
            {
                IEventPublisher eventPublisher = context.GetInstance<IEventPublisher>();
                eventPublisher.RegisterHandlers(handler);
                return handler;
            });

            For<ApplicationContext>()
                .Singleton()
                .Use<AppContext>();

            For<IMouseEventPublisher>()
                .Singleton()
                .Use<MouseMessageFilter>();

            For<IAppHub>()
                .Singleton()
                .Use<AppHub>();

            For<ICommandMap>()
                .Singleton()
                .Use<DefaultCommandMap>();

            For<IEventPublisher>()
                .Use<EventPublisher>();

            For<ICommandHistory<IUndoableCommand>>()
                .Use(() => new CommandHistory());

            #endregion

            #region Presenter Implementations

            For<IAppWindowPresenter>()
                .Use<AppWindowPresenter>();

            For<IAppMenuPresenter>()
                .Use<MenuCommandExecuter>();

            For<IAppLogPresenter>()
                .Use<AppLogPresenter>();
            
            #endregion

            #region View Implementations

            For<IAppWindow>()
                .Use<AppWindow>()
                .OnCreation((context, view) => 
                {
                    IAppMenuPresenter menuPresenter = context.GetInstance<IAppMenuPresenter>();
                    MenuStrip menu = menuPresenter.View as MenuStrip;

                    // Load application menu
                    if (menu != null)
                        view.MainMenuStrip = menu;
                });

            For<IAppMenu>()
                .Use<AppMenu>();

            For<IAppLogWindow>()
                .Use<AppLogWindow>();

            For<SaveFileDialog>()
                .Singleton();

            #endregion
        }
    }
}
