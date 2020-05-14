/*
    eduEx - Extensions for .NET

    Copyright: 2020 The Commons Conservancy eduVPN Programme
    SPDX-License-Identifier: GPL-3.0+
*/

using System;
using System.IO;
using System.Threading;

namespace eduEx.Async
{
    public static class Extensions
    {
        public static int Read(this Stream stream, byte[] buffer, int offset, int count, CancellationToken ct)
        {
            var task = stream.ReadAsync(buffer, offset, count, ct);
            try { task.Wait(ct); }
            catch (AggregateException ex) { throw ex.InnerException; }
            return task.Result;
        }

        public static void Write(this Stream stream, byte[] buffer, int offset, int count, CancellationToken ct)
        {
            var task = stream.WriteAsync(buffer, offset, count, ct);
            try { task.Wait(ct); }
            catch (AggregateException ex) { throw ex.InnerException; }
        }

        public static int Read(this TextReader reader, char[] buffer, int index, int count, CancellationToken ct)
        {
            var task = reader.ReadAsync(buffer, index, count);
            try { task.Wait(ct); }
            catch (AggregateException ex) { throw ex.InnerException; }
            return task.Result;
        }

        public static int ReadBlock(this TextReader reader, char[] buffer, int index, int count, CancellationToken ct)
        {
            var task = reader.ReadBlockAsync(buffer, index, count);
            try { task.Wait(ct); }
            catch (AggregateException ex) { throw ex.InnerException; }
            return task.Result;
        }

        public static string ReadLine(this TextReader reader, CancellationToken ct)
        {
            var task = reader.ReadLineAsync();
            try { task.Wait(ct); }
            catch (AggregateException ex) { throw ex.InnerException; }
            return task.Result;
        }

        public static string ReadToEnd(this TextReader reader, CancellationToken ct)
        {
            var task = reader.ReadToEndAsync();
            try { task.Wait(ct); }
            catch (AggregateException ex) { throw ex.InnerException; }
            return task.Result;
        }
    }
}
