using System.IO;
using System.Collections.Generic;
using System;

namespace ShaderlabVS
{
    public class ShaderlabVSFileReference : IDisposable
    {
        private static readonly char[] sDirectorySeparators = { '/', '\\' };

        private static readonly Dictionary<string, ShaderlabVSFileReference> allFiles = new Dictionary<string, ShaderlabVSFileReference>();

        private readonly List<ShaderlabVSFileReference> headers = new List<ShaderlabVSFileReference>();
        private readonly string path;
        private readonly string canonicalPath;
        private readonly string canonicalName;
        private FileSystemWatcher fileSysWatcher;

        public string CanonicalName { get { return canonicalName; } }
        public string CanonicalPath { get { return canonicalPath; } }
        public List<ShaderlabVSFileReference> Headers { get { return headers; } }

        public ShaderlabVSFileReference(string path, string canonicalPath, string canonicalName)
        {
            this.path = path;
            this.canonicalPath = canonicalPath;
            this.canonicalName = canonicalName;
            this.fileSysWatcher = new FileSystemWatcher(this.path);
            fileSysWatcher.Changed += new FileSystemEventHandler(OnProcess);
            fileSysWatcher.Created += new FileSystemEventHandler(OnProcess);
            fileSysWatcher.Deleted += new FileSystemEventHandler(OnProcess);
            fileSysWatcher.Renamed += new RenamedEventHandler(OnRenamed);
            fileSysWatcher.EnableRaisingEvents = true;
        }


        ~ShaderlabVSFileReference()
        {
            Dispose(false);
        }

        private static void OnProcess(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                OnCreated(source, e);
            }
            else if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                OnChanged(source, e);
            }
            else if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                OnDeleted(source, e);
            }
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
        }

        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
        }

        public static ShaderlabVSFileReference Get(string path)
        {
            ShaderlabVSFileReference r;
            if (!allFiles.TryGetValue(path, out r))
            {
                string canonicalPath = path.ToLower();
                int index = canonicalPath.LastIndexOfAny(sDirectorySeparators);
                if (index >= 0 && index < canonicalPath.Length - 1)
                {
                    string canonicalName = canonicalPath.Substring(index + 1);
                    r = new ShaderlabVSFileReference(path, canonicalPath, canonicalName);
                }
            }
            return r;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                if (fileSysWatcher != null)
                {
                    fileSysWatcher.Dispose();
                    fileSysWatcher = null;
                }
                headers.Clear();
                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~ShaderlabVSFileReference() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            //GC.SuppressFinalize(this);
        }
        #endregion
    }
}
