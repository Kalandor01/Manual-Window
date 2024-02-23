namespace CleanWpfApp
{
    [FriendAccessAllowed]
    internal static class CriticalExceptions
    {
        // these are all the exceptions considered critical by PreSharp
        [FriendAccessAllowed]
        internal static bool IsCriticalException(Exception ex)
        {
            ex = Unwrap(ex);

            return ex is NullReferenceException ||
                   ex is StackOverflowException ||
                   ex is OutOfMemoryException ||
                   ex is ThreadAbortException ||
                   ex is System.Runtime.InteropServices.SEHException ||
                   ex is System.Security.SecurityException;
        }

        // these are exceptions that we should treat as critical when they
        // arise during callbacks into application code
        [FriendAccessAllowed]
        internal static bool IsCriticalApplicationException(Exception ex)
        {
            ex = Unwrap(ex);

            return ex is StackOverflowException ||
                   ex is OutOfMemoryException ||
                   ex is ThreadAbortException ||
                   ex is System.Security.SecurityException;
        }

        [FriendAccessAllowed]
        internal static Exception Unwrap(Exception ex)
        {
            // for certain types of exceptions, we care more about the inner
            // exception
            while (ex.InnerException != null &&
                    (ex is System.Reflection.TargetInvocationException
                    ))
            {
                ex = ex.InnerException;
            }

            return ex;
        }
    }
}
