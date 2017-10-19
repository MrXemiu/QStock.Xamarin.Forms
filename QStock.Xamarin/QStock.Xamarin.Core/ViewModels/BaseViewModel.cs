using System;
using System.ComponentModel;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using QStock.Xamarin.Core.Models.Messages;

namespace QStock.Xamarin.Core.ViewModels
{
    public abstract class BaseViewModel<TParameter, TResult> : MvxViewModel<TParameter, TResult> where TParameter : class where TResult : class
    {
        #region Private Fields

        private IDisposable _afterExecuteToken;

        private IDisposable _beforeExecuteToken;

        private bool _isBusy;

        #endregion Private Fields

        #region Public Properties

        public string Description { get; protected set; }

        /// <summary>
        ///  Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        /// <value><c>true</c> if this instance is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        #endregion Public Properties

        #region Protected Constructors

        protected BaseViewModel(IMvxMessenger messenger)
        {
            _beforeExecuteToken = messenger.Subscribe<BeforeExecuteRequestMsg>(request => IsBusy = true);
            _afterExecuteToken = messenger.Subscribe<AfterExecuteRequestMsg>(request => IsBusy = false);

            PropertyChanged += OnPropertyChanged;
        }

        #endregion Protected Constructors

        #region Protected Methods

        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
        }

        #endregion Protected Methods

        #region Public Methods

        public void Cancel()
        {
            Close(this);
        }

        public abstract void Reset();

        #endregion Public Methods
    }
}