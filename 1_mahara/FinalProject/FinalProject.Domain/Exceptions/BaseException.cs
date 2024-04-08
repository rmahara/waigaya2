namespace FinalProject.Domain.Exceptions
{
    /// <summary>
    /// 例外基底クラス
    /// </summary>
    public abstract class BaseException : Exception
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        public BaseException(string message) : base(message)
        { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="ex">元になった例外</param>
        public BaseException(string message, Exception ex) : base(message, ex)
        { }

        /// <summary>
        /// 区分
        /// </summary>
        public abstract ExceptionKind Kind { get; }

        /// <summary>
        /// 例外区分
        /// </summary>
        public enum ExceptionKind
        {
            Info,
            Warning,
            Error,
        }
    }
}
