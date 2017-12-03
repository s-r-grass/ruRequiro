using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Requiro
{
    class CacheFile
    {
        public string Path { get; set; }
        public long   Size { get; set; }
    }

    class CacheDirectory
    {
        public string Path { get; set; }

        public List<CacheDirectory> subDirectories { get; private set;  }
        public List<CacheFile> subFiles { get; private set; }

        // Assumes a valid path
        private void AddFile(CacheFile cf)
        {
            subFiles.Add(cf);
        }

        // Ditto
        private void AddDirectory(CacheDirectory cd)
        {
            subDirectories.Add(cd);
        }
    }  

    class DirectoryCache
    {
        private Dictionary<string, Dictionary<string, long>> m_Cache;

        public DirectoryCache()
        {
            m_Cache = new Dictionary<string, Dictionary<string, long>>();
        }

        public void AddPathFiles(string fullPath, Dictionary<string, long> directoryFiles)
        {
            if (!m_Cache.ContainsKey(fullPath))
            {
                m_Cache.Add(fullPath, directoryFiles);
            }
        }

        public void DeletePathFromPath(string parentPath, string childPath)
        {
            if (m_Cache.ContainsKey(parentPath))
            {
                if (m_Cache[parentPath].ContainsKey(childPath))
                {
                    m_Cache[parentPath].Remove(childPath);
                }
            }
        }



        public Dictionary<string, long> GetPathFiles(string fullPath)
        {
            if (HasPath(fullPath))
                return m_Cache[fullPath];
            else
                return null;
        }

        public bool HasPath(string fullPath)
        {
            return m_Cache.ContainsKey(fullPath);
        }
    }
}
