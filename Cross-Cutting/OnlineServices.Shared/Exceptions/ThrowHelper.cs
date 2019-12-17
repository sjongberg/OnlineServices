using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Serilog;

namespace OnlineServices.Shared.Exceptions
{
    public static class ThrowHelper
    {
        public static void WithLog(Exception exception, ILogger iLogger)
        {
            if (iLogger is null)
                WithDebug(new ArgumentNullException($"{nameof(iLogger)} is null @ ThrowHelper.WithLog(Exception, ILogger)"));
            else
            {

                if (exception is null)
                    exception = new ArgumentNullException($"{nameof(exception)} is null @ ThrowHelper.WithLog(Exception, ILogger)");

                iLogger.Error(exception, exception.Source);
                throw exception;
            }
        }
        public static void WithDebug(Exception exception)
        {
            if (exception is null)
                exception = new ArgumentNullException($"{nameof(exception)} is null @ ThrowHelper.WithLog(Exception, ILogger)");

            Debug.WriteLine($"Exception source:{exception.Source}");
            Debug.WriteLine($"Exception message: {exception.Message}");

            throw exception;
        }
    }
}
