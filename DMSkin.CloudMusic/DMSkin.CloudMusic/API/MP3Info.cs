using Shell32;
using System;
using System.Diagnostics;

namespace DMSkin.CloudMusic
{
    /// <summary>
    /// Windows Shell32.dll を参照し、データを取得するためのクラス
    /// </summary>
    public class MP3Info
    {
        public string trackName; // トラック名
        public string Artist;    // アーティスト名
        public string Album;     // アルバム名
        public string time;　　　// 時間

        public MP3Info()
        {
            trackName = null;
            Artist    = null;
            Album     = null;
            time      = null;
        }
        
        /// <summary>
        /// MP3 の情報を取得します。
        /// </summary>
        public  bool GetMP3Info(string myDirectory, string myFile)
        {
            Folder folder = null;
            FolderItem folderItem;

            try
            {
                Type wShell = Type.GetTypeFromProgID("Shell.Application");
                object wshInstance = Activator.CreateInstance(wShell);

                folder = (Folder)wShell.InvokeMember("NameSpace",
                                                      System.Reflection.BindingFlags.InvokeMethod,
                                                      null,
                                                      wshInstance,
                                                      new object[] { myDirectory }
                                                     );

                folderItem = folder.ParseName(myFile);
            }
            catch
            {
                return false;
            }

            //////////////////////////////////////////////////////////
            // Shell COM を 叩いて情報開示
            //////////////////////////////////////////////////////////
            trackName = folder.GetDetailsOf(folderItem, 21);
            Artist    = folder.GetDetailsOf(folderItem, 20);
            Album     = folder.GetDetailsOf(folderItem, 14);
            time      = folder.GetDetailsOf(folderItem, 27);

            Debug.WriteLine(folder.GetDetailsOf(folderItem, 21)); // [DEBUG] trackName
            Debug.WriteLine(folder.GetDetailsOf(folderItem, 20)); // [DEBUG] Artist
            Debug.WriteLine(folder.GetDetailsOf(folderItem, 14)); // [DEBUG] Album
            Debug.WriteLine(folder.GetDetailsOf(folderItem, 27)); // [DEBUG] Time

            return true;
        }
    }
}
