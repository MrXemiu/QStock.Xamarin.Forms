using MvvmCross.Plugins.Messenger;

namespace QStock.Xamarin.Core.Models.Messages
{
    public class AfterExecuteRequestMsg : MvxMessage
    {
        #region Public Constructors

        public AfterExecuteRequestMsg(object sender) : base(sender)
        {
        }

        #endregion Public Constructors
    }
}