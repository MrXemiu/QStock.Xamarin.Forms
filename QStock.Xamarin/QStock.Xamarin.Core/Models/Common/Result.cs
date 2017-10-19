namespace QStock.Xamarin.Core.Models.Common
{
    public class Result
    {
        #region Public Properties

        public bool success { get; set; }

        public int resCode { get; set; }

        public string logMessage { get; set; }

        public string errorMessage { get; set; }

        #endregion Public Properties

        #region Public Constructors

        // constructor with default properties
        public Result()
        {
            success = true;
            resCode = 0;
            logMessage = "";
            errorMessage = "";
        }

        #endregion Public Constructors
    }
}