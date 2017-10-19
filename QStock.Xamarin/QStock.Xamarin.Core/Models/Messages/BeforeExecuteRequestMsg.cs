using MvvmCross.Plugins.Messenger;

namespace QStock.Xamarin.Core.Models.Messages
{
    public class BeforeExecuteRequestMsg : MvxMessage
    {
        #region Public Constructors

        public BeforeExecuteRequestMsg(object sender) : base(sender)
        {
        }

        #endregion Public Constructors
    }
}