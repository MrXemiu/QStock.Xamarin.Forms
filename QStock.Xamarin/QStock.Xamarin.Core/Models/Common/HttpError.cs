namespace QStock.Xamarin.Core.Models.Common
{
    /// <summary>
    ///  Defines a serializable container for storing error information. This information is stored
    ///  as key/value pairs. The dictionary keys to look up standard error information are available
    ///  on the <see cref="T:System.Web.Http.HttpErrorKeys" /> type.
    /// </summary>
    public sealed class HttpError
    {
        #region Public Properties

        /// <summary>
        ///  Gets or sets the high-level, user-visible message explaining the cause of the error.
        ///  Information carried in this field should be considered public in that it will go over
        ///  the wire regardless of the <see cref="T:System.Web.Http.IncludeErrorDetailPolicy" />. As
        ///  a result care should be taken not to disclose sensitive information about the server or
        ///  the application.
        /// </summary>
        /// <returns>
        ///  The high-level, user-visible message explaining the cause of the error. Information
        ///  carried in this field should be considered public in that it will go over the wire
        ///  regardless of the <see cref="T:System.Web.Http.IncludeErrorDetailPolicy" />. As a result
        ///  care should be taken not to disclose sensitive information about the server or the application.
        /// </returns>
        public string Message { get; set; }

        /// <summary>
        ///  Gets the <see cref="P:System.Web.Http.HttpError.ModelState" /> containing information
        ///  about the errors that occurred during model binding.
        /// </summary>
        /// <returns>
        ///  The <see cref="P:System.Web.Http.HttpError.ModelState" /> containing information about
        ///  the errors that occurred during model binding.
        /// </returns>
        public HttpError ModelState { get; set; }

        /// <summary>
        ///  Gets or sets a detailed description of the error intended for the developer to
        ///  understand exactly what failed.
        /// </summary>
        /// <returns>
        ///  A detailed description of the error intended for the developer to understand exactly
        ///  what failed.
        /// </returns>
        public string MessageDetail { get; set; }

        /// <summary>
        ///  Gets or sets the message of the <see cref="T:System.Exception" /> if available.
        /// </summary>
        /// <returns>The message of the <see cref="T:System.Exception" /> if available.</returns>
        public string ExceptionMessage { get; set; }

        /// <summary>
        ///  Gets or sets the type of the <see cref="T:System.Exception" /> if available.
        /// </summary>
        /// <returns>The type of the <see cref="T:System.Exception" /> if available.</returns>
        public string ExceptionType { get; set; }

        /// <summary>
        ///  Gets or sets the stack trace information associated with this instance if available.
        /// </summary>
        /// <returns>The stack trace information associated with this instance if available.</returns>
        public string StackTrace { get; set; }

        /// <summary>
        ///  Gets the inner <see cref="T:System.Exception" /> associated with this instance if available.
        /// </summary>
        /// <returns>
        ///  The inner <see cref="T:System.Exception" /> associated with this instance if available.
        /// </returns>
        public HttpError InnerException { get; set; }

        #endregion Public Properties
    }
}